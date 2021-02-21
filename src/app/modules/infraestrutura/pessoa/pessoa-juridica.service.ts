import { PessoaJuridica } from './../../../models/pesssoa-juridica';
import { Injectable, EventEmitter } from '@angular/core';
import { CrudServiceBase } from 'src/app/shared/services/crud-service-base';
import { PessoaFisica } from 'src/app/models/pessoa-fisica';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take, map } from 'rxjs/operators';
import { Subscription, Observable } from 'rxjs';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class PessoaJuridicaService extends CrudServiceBase<PessoaJuridica> {
  invokSearchPesssoaJuridica = new EventEmitter();
  subsVarPj: Subscription;

  constructor(protected http: HttpClient) {
    super(http, `${environment.apiUrl}/pessoaJuridica`);
  }
  eventEmitterSearchPesssoaJuridica(
    nomeFantasia: string = null,
    cnpj: string = null,
    razaoSocial: string = null
  ) {
    this.invokSearchPesssoaJuridica.emit({ nomeFantasia, cnpj, razaoSocial });
  }

  getAll() {
    return this.searchFilterPessoJuridica();
  }

  searchFilterPessoJuridica(
    nomeFantasia: string = null,
    cnpj: string = null,
    razaoSocial: string = null
  ): Observable<PessoaJuridica[]> {
    return this.http
      .get<PessoaFisica>(
        `${
          environment.apiUrl
        }/pessoaJuridica/${nomeFantasia}/${cnpj}/${razaoSocial}`
      )
      .pipe(
        take(1),
        map(data => _.values(data))
      );
  }
}
