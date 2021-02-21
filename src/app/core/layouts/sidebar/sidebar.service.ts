import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Menu } from 'src/app/models/menu';
import * as _ from 'lodash';
import { map, tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {


  constructor(private http: HttpClient ) { }
  getMenu() {
    return this.http.get<Menu[]>(`${environment.apiUrl}/Menu`)
     .pipe(map(data => _.values( data)));

     // , tap(console.log));
  }

}
