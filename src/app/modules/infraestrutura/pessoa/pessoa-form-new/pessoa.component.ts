import { HelperService } from './../../../../shared/services/helper-service.service';
import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';
import { Tabs } from 'src/app/shared/controls/tab/tabs';
import { MatTabChangeEvent } from '@angular/material/tabs/typings/tab-group';
import { Router } from '@angular/router';

@Component({
  selector: 'dbcorp-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit, AfterViewInit {
  // tabLoadTimes: Date[] = [];
  @ViewChild('tabGroupPessoa') tabGroupPessoa;
  @Input() dadosUpdatePessoa: any;
  componentPessoa = 'rdbPf';
  disabledCompPessoa = false;
  customTitleMomalFormNovo = 'Cadastro de Pessoa';


  constructor( private router: Router) { }

  ngOnInit() {


    switch ((this.router.url.split('/')[2])) {
      case 'pessoa': {

        this.customTitleMomalFormNovo = 'Cadastro de Pessoa';
        break;
      }
      case 'cliente': {
        this.customTitleMomalFormNovo = 'Cadastro de Cliente';
        break;
      }
      case 'fornecedor': {
        this.customTitleMomalFormNovo = 'Cadastro de Fornecedor';
        break;
      }
      case 'transportadora': {
        this.customTitleMomalFormNovo = 'Cadastro de Transportadora';
        break;
      }
      default: {
        this.customTitleMomalFormNovo = 'Cadastro de Pessoa';
        break;
      }
    }

  }

  recebeDadosUpdate(dados: any = null) {
    this.dadosUpdatePessoa = dados;
    if (this.dadosUpdatePessoa['Cpf'] === undefined && this.dadosUpdatePessoa['Cnpj'] === undefined) {
      this.disabledCompPessoa = false;
      this.componentPessoa = 'rdbPf';
    } else if (this.dadosUpdatePessoa['Cpf'] === undefined && this.dadosUpdatePessoa['Cnpj'] != undefined) {
      this.disabledCompPessoa = true;
      this.componentPessoa = 'rdbPj';
      console.log('02');
    } else if (this.dadosUpdatePessoa['Cnpj'] === undefined && this.dadosUpdatePessoa['Cpf'] != undefined) {
      this.disabledCompPessoa = true;
      this.componentPessoa = 'rdbPf';
    }
  }


  ngAfterViewInit() {


  }


  // getTimeLoaded(index: number) {
  //   if (!this.tabLoadTimes[index]) {
  //     this.tabLoadTimes[index] = new Date();
  //   }

  //   return this.tabLoadTimes[index];
  // }





}
