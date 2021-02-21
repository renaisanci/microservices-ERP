import { CrudServiceBase } from 'src/app/shared/services/crud-service-base';
import { Funil } from './../../../models/funil';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class FunilService extends CrudServiceBase<Funil> {

  constructor(protected http: HttpClient )
  {
    super(http, `${environment.apiUrl}/funil`);
  }
}
