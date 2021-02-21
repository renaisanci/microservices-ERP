import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { User } from '../../../models/user';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import * as _ from 'lodash';

@Injectable({ providedIn: 'root' })
export class UserService {


  userChanged = new EventEmitter<Observable<User[]>>();

    constructor(private http: HttpClient) { }

    getAll(): Observable<User[]> {
        return this.http.get<User[]>(`${environment.apiUrl}/auth`);
    }

    getById(id: number) {
        return this.http.get(`${environment.apiUrl}/users/${id}`);
    }

    register(user: User) {
        return this.http.post(`${environment.apiUrl}/auth/register`, user)
        .pipe(map(data => _.values(data)),
        tap( data => this.userChanged.emit(this.getAll())));
    }

    update(user: User) {
        return this.http.put(`${environment.apiUrl}/users/${user.Id}`, user);
    }
    delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/users/${id}`);
    }
}
