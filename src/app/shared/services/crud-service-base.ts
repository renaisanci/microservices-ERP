import { HttpClient } from '@angular/common/http';
import { delay, tap, take, map } from 'rxjs/operators';
import { EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';
import * as _ from 'lodash';

export class CrudServiceBase<T> {



  public objChanged = new EventEmitter<Observable<T[]>>();

  constructor(protected http: HttpClient, private API_URL) { }


  getAll(): Observable<T[]> {
    // console.log(this.API_URL);
    return this.http.get<T>(this.API_URL)
      .pipe(map(data => _.values(data)));
    // , tap(console.log));
  }

  getByID(id) {
    return this.http.get<T>(`${this.API_URL}/${id}`).pipe(take(1));

  }

  create(objData: T) {
    // para criar um novo registro não enviar Id mesmo que seja null
    // necessário devido a validação estar sendo usada para inserir e editar
    delete objData['Id'];
    return this.http.post(this.API_URL, objData).pipe(map(data => _.values(data), take(1)),
      tap(() => this.objChanged.emit(this.getAll())));
  }

  private update(objData: T) {
    return this.http.put(`${this.API_URL}/${objData['Id']}`, objData).pipe(map(data => _.values(data), take(1)),
      tap(() => this.objChanged.emit(this.getAll())));
  }

  save(objData: T) {
    if (objData['Id'] === null) {
      return this.create(objData);
    }
    return this.update(objData);
  }

  remove(id) {

    return this.http.delete(`${this.API_URL}/${id}`).pipe(take(1),
    tap(() => this.objChanged.emit(this.getAll())));


  }
}
