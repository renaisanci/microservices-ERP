import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dbcorp-funil-main',
  templateUrl: './funil-main.component.html',
  styleUrls: ['./funil-main.component.css']
})
export class FunilMainComponent implements OnInit {

  daodosFiltros: any;

  constructor() { }

  ngOnInit() {
  }


  excluirItens() {

  }

  refreshData() {

  }

  recebeDadosFiltro(filtros) {
    this.daodosFiltros = filtros;
    // console.log(fiters);
  }

}
