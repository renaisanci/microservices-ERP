import { Component, OnInit } from '@angular/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';


@Component({
  selector: 'dbcorp-negocios-main',
  templateUrl: './negocios-main.component.html',
  styleUrls: ['./negocios-main.component.css']
})
export class NegociosMainComponent implements OnInit {
  public config: PerfectScrollbarConfigInterface = {suppressScrollX :true , suppressScrollY:true, useBothWheelAxes:true };
  itensExcluir: any;
  daodosFiltros: any;


  constructor() { }

  ngOnInit() {
  }


  excluirItens() {

  }

  refreshData() {

  }


}
