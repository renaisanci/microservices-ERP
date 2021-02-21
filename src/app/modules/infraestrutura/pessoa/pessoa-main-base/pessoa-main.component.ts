import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HelperService } from 'src/app/shared/services/helper-service.service';
import { PessoaFisicaService } from '../pessoa-fisica.service';
import { PessoaJuridicaService } from '../pessoa-juridica.service';

@Component({
  selector: 'dbcorp-pessoa-main',
  templateUrl: './pessoa-main.component.html',
  styleUrls: ['./pessoa-main.component.css']
})
export class PessoaMainComponent implements OnInit {
  itensExcluir: any;
  daodosFiltros: any;

  constructor(
    private pessoaFisicaService: PessoaFisicaService,
    private pessoaJuridicaService: PessoaJuridicaService
  ) {}

  ngOnInit() {}

  excluirItens() {
    this.pessoaFisicaService.eventEmitterExcluirPessoa();
  }

  refreshData() {
    if (localStorage.getItem('opcaoPesquisa') === 'pf') {
      this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(
        this.daodosFiltros['Nome'],
        this.daodosFiltros['Sobrenome'],
        this.daodosFiltros['Cpf']
      );
    } else {
      console.log(this.daodosFiltros);
      this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(
        this.daodosFiltros['NomeFantasia'],
        this.daodosFiltros['Cnpj'],
        this.daodosFiltros['RazaoSocial']
      );
    }
  }

  recebeDadosFiltro(filtrosPfPj) {
    this.daodosFiltros = filtrosPfPj;
    // console.log(fiters);
  }
}
