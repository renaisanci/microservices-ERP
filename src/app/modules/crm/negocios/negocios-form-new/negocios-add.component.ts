import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dbcorp-negocios-add',
  templateUrl: './negocios-add.component.html',
  styleUrls: ['./negocios-add.component.css']
})
export class NegociosAddComponent implements OnInit {

  customTitleMomalFormNovo = 'Negócio';

  constructor() { }

  ngOnInit() {
  }

  recebeDadosUpdate(dados: any = null) {

  }

}
