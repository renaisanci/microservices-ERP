import { environment } from './../../../../environments/environment';
import { Pessoa } from './../../../models/pessoa';
import { HttpClient } from '@angular/common/http';
import { CrudServiceBase } from './../../../shared/services/crud-service-base';
import { Injectable, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PessoaService extends CrudServiceBase<Pessoa> {
  invokeonSearchPesssoa = new EventEmitter();
  subsVar: Subscription;

  constructor(protected http: HttpClient ) {
    super(http, `${environment.apiUrl}/pessoa`);
  }

  onSearchPesssoa(tipoPessoa: string) {
    this.invokeonSearchPesssoa.emit(tipoPessoa);
  }

}
