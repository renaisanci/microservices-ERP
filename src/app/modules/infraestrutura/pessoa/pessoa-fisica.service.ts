import { Injectable, EventEmitter } from '@angular/core';
import { CrudServiceBase } from 'src/app/shared/services/crud-service-base';
import { PessoaFisica } from 'src/app/models/pessoa-fisica';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take, map, tap } from 'rxjs/operators';
import { Subscription, Observable, Subject, BehaviorSubject } from 'rxjs';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class PessoaFisicaService extends CrudServiceBase<PessoaFisica> {
  invokSearchPesssoaFisica = new EventEmitter();
  invokExcluirPesssoa = new EventEmitter();
  subsVarPf: Subscription;

  private data = new BehaviorSubject('');
  currentData = this.data.asObservable();


  constructor(protected http: HttpClient ) {
    super(http, `${environment.apiUrl}/pessoaFisica`);
  }


  getAll() {
    return this.searchFilterPessoFisica();
   }

  eventEmitterSearchPesssoaFisica(nome: string=null, sobrenome: string=null, cpf: string=null) {

    this.invokSearchPesssoaFisica.emit({ nome: nome, sobrenome: sobrenome, cpf: cpf });


  }
  searchFilterPessoFisica(nome: string= null, sobrenome: string= null, cpf: string= null): Observable<PessoaFisica[]>  {
    return this.http.get<PessoaFisica>(`${environment.apiUrl}/pessoaFisica/${nome}/${sobrenome}/${cpf}`).pipe(take(1),
    map(data => _.values( data)));
    // , tap(console.log));
  }


  eventEmitterExcluirPessoa() {
    this.invokExcluirPesssoa.emit();
  }


}
