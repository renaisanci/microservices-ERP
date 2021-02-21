import { PessoaComponent } from './../pessoa-form-new/pessoa.component';

import { PessoaJuridica } from './../../../../models/pesssoa-juridica';
import { PessoaFisica } from './../../../../models/pessoa-fisica';
import { PessoaJuridicaService } from './../pessoa-juridica.service';
import { PessoaFisicaService } from './../pessoa-fisica.service';

import DataSource from 'devextreme/data/data_source';
import {
  Component,
  OnInit,
  ViewChild,
  Output,
  EventEmitter,
  TemplateRef,
  Input,
  OnDestroy
} from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { of, Subscription } from 'rxjs';
import { DxDataGridComponent } from 'devextreme-angular';
import { MatDialog } from '@angular/material';
import { HelperService } from 'src/app/shared/services/helper-service.service';
import { AutoUnsubscribe } from 'ngx-auto-unsubscribe';

@AutoUnsubscribe()
@Component({
  selector: 'dbcorp-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.css']
})
export class PessoaListComponent implements OnInit, OnDestroy {
  dataSource: DataSource;
  @ViewChild('gridPessoas') dataGrid: DxDataGridComponent;

  @Input() modalPessoaFormNovo: TemplateRef<any>;

  dsPessoaFisica: PessoaFisica[];
  dsPessoaJuridica: PessoaJuridica[];
  columns: any[];
  dsPessoas: any[];
  localeIdioma = localStorage.getItem('language');
  gridLoad: boolean;
  opcaoPesquisa: string;
  @Output() itensExcluir = new EventEmitter();
  @Output() dadosFiltro = new EventEmitter();

  columnsPf: any[] = [
    { dataField: 'Id', caption: 'Id', dataType: 'string', fixed: true },
    { dataField: 'Nome', caption: 'Nome' },
    { dataField: 'Sobrenome', caption: 'Sobrenome' },
    { dataField: 'Cpf', caption: 'CPF' },
    { dataField: 'Rg', caption: 'RG' },
    { dataField: 'DtNascimento', caption: 'Dt. Nascimento', dataType: 'string' }
  ];

  columnsPj: any[] = [
    { dataField: 'Id', caption: 'Id', dataType: 'string', fixed: true },
    { dataField: 'NomeFantasia', caption: 'Nome Fantasia' },
    { dataField: 'RazaoSocial', caption: 'Razao Social' },
    { dataField: 'Cnpj', caption: 'CNPJ' },
    { dataField: 'InscEstadual', caption: 'Insc. Estadual' },
    { dataField: 'DtFundacao', caption: 'Dt. Fundação', dataType: 'string' }
  ];

  interval: Subscription;

  constructor(
    private pessoaFisicaService: PessoaFisicaService,
    private pessoaJuridicaService: PessoaJuridicaService,
    private toastr: ToastrService,
    public dialog: MatDialog,
    private sos: HelperService
  ) {}

  ngOnInit() {



    this.interval = this.pessoaFisicaService.invokSearchPesssoaFisica.subscribe(
      paramPf => {
        this.searchPessoaFisica(paramPf.nome, paramPf.sobrenome, paramPf.cpf);
      }
    );

    this.pessoaFisicaService.invokExcluirPesssoa.subscribe(paramPf => {
      this.excluirPessoa();
    });

    this.pessoaJuridicaService.invokSearchPesssoaJuridica.subscribe(paramPj => {
      this.searchPessoaJuridica(
        paramPj.nomeFantasia,
        paramPj.cnpj,
        paramPj.razaoSocial
      );
    });
  }

  // pega os dados do GRID
  getSelectedRowsData() {
    console.log(this.dataGrid.instance.getSelectedRowsData());
  }

  searchPessoaFisica(
    nome: string = null,
    sobrenome: string = null,
    cpf: string = null
  ) {
    this.dsPessoas = [];


    localStorage.setItem('opcaoPesquisa', 'pf');
    localStorage.setItem('pesquisando', 'true');
    this.dadosFiltro.emit({ Nome: nome, Sobrenome: sobrenome, Cpf: cpf });


    const grid = this.dataGrid;

    this.pessoaFisicaService
      .searchFilterPessoFisica(nome, sobrenome, cpf)
      .pipe(
        catchError(err => {
          this.toastr.error('Erros ao listar Pessoas Fisicas ', err);
          return of([]);
        })
      )
      .subscribe(pf => {
        this.dsPessoas = this.dsPessoaFisica = pf;


        // if (localStorage.getItem('gridStatepf') == null){
        this.columns = this.columnsPf;
        setTimeout(() => {
          grid.instance.state(JSON.parse(localStorage.getItem('gridStatepf')));
          grid.instance.refresh();
        });
        // fecha o modal de pesquisa após a consulta
        this.sos.closeModal('dbcorp-pessoa-filter-server');
      });
  }

  searchPessoaJuridica(
    nomeFantasia: string,
    cnpj: string,
    razaoSocial: string
  ) {
    localStorage.setItem('opcaoPesquisa', 'pj');
    localStorage.setItem('pesquisando', 'true');
    this.dadosFiltro.emit({
      NomeFantasia: nomeFantasia,
      Cnpj: cnpj,
      RazaoSocial: razaoSocial
    });

    const grid = this.dataGrid;

    this.pessoaJuridicaService
      .searchFilterPessoJuridica(nomeFantasia, cnpj, razaoSocial)
      .pipe(
        catchError(err => {
          this.toastr.error('Erros ao listar Pessoas Jurídicas ', err);
          return of([]);
        })
      )
      .subscribe(pj => {
        this.dsPessoas = this.dsPessoaJuridica = pj;

        // if (localStorage.getItem('gridStatepj') == null){
        this.columns = this.columnsPj;
        // }
        setTimeout(() => {
          grid.instance.state(JSON.parse(localStorage.getItem('gridStatepj')));

          grid.instance.refresh();
        });

        // fecha o modal de pesquisa após a consulta
        this.sos.closeModal('dbcorp-pessoa-filter-server');
      });
  }
  onClick(e, data) {
    console.log(JSON.stringify(data.row.data));
  }

  loadState = () => {
    localStorage.setItem('pesquisando', 'false');

    return JSON.parse(
      localStorage.getItem(`gridState${localStorage.getItem('opcaoPesquisa')}`)
    );
  }
  saveState = state => {

    if (localStorage.getItem('pesquisando') === 'true') {
      localStorage.setItem('pesquisando', 'false');
      return;
    }

    state.opcaoPesquisa = localStorage.getItem('opcaoPesquisa');

    localStorage.setItem(
      `gridState${localStorage.getItem('opcaoPesquisa')}`,
      JSON.stringify(state)
    );
  }

  cellClickHandler(e) {
    if (e.columnIndex === 1) {
      this.sos.openModalComponenType(PessoaComponent, e.data, 'dbcorp-pessoa');
    }
  }

  setStyle(e) {
    if (e.rowType === 'data') {
      if (e.column.dataField === 'Id') {
        e.cellElement.className = 'btn btn-link';
        e.cellElement.style = 'display: table-cell;  text-align: left;';
      } else if (e.column.index > 0) {
        // quando aplica esste style, nao se consegue selecionar o valor da cell, caso queira copiar
        //  e.cellElement.style = ' pointer-events: none;';
      }
    }
  }

  excluirPessoa() {
    const self = this;
    this.dataGrid.instance.getSelectedRowsData().forEach(async function(value) {
      if (value['Cnpj'] === undefined) {
        await self.excluirPf(value['Id']);
        console.log(value);
      } else {
        await self.excluirPj(value['Id']);
        console.log(value);
      }
    });
  }

  excluirPf(id) {
    this.pessoaFisicaService.remove(id).subscribe(
      data => {
        setTimeout(() =>
          this.toastr.success(
            'Removido com sucesso!',
            'Cadastro de Pessoa Física'
          )
        );
        this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(
          null,
          null,
          null
        );
      },
      error => {
        this.toastr.error(error, 'Erro remover Pessoa Física. ');
      }
    );
  }

  excluirPj(id) {
    this.pessoaJuridicaService.remove(id).subscribe(
      data => {
        setTimeout(() =>
          this.toastr.success(
            'Removido com sucesso!',
            'Cadastro de Pessoa Jurídica'
          )
        );
        this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(
          null,
          null,
          null
        );
      },
      error => {
        this.toastr.error(error, 'Erro remover Pessoa Jurídica. ');
      }
    );
  }

  // manter esse method mesmo vazio para ocorrer o unsubcribe
  ngOnDestroy(): void {
  }
}
