import { MatDialogRef } from '@angular/material/dialog';
import { HelperService } from './../../../../shared/services/helper-service.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PessoaFisicaService } from '../pessoa-fisica.service';
import { PessoaJuridicaService } from '../pessoa-juridica.service';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'dbcorp-pessoa-filter-server',
  templateUrl: './pessoa-filter-server.component.html',
  styleUrls: ['./pessoa-filter-server.component.css']
})
export class PessoaFilterServerComponent implements OnInit {
  loading = false;
  submitted = false;

  @ViewChild('tabGroupFilterPessoa') tabGroupFilterPessoa;
  formSearch: FormGroup;

  constructor(
    private sos: HelperService,
    private pessoaFisicaService: PessoaFisicaService,
    private pessoaJuridicaService: PessoaJuridicaService,
    private toastr: ToastrService


  ) {}

  ngOnInit() {}

  recebeForm(form) {
    this.formSearch = form;

  }

  pesquisar() {


    this.loading = true;
    // if( this.formSearch.pristine );


    if (this.sos.getTabId(this.tabGroupFilterPessoa) === 'tabPfFilter') {



      this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(
        this.sos.tryEmptyToNull(this.formSearch.controls['Nome'].value),
        this.sos.tryEmptyToNull(this.formSearch.controls['Sobrenome'].value),
        this.sos.tryEmptyToNull(this.formSearch.controls['Cpf'].value)
      );

      // if (
      //   this.formSearch.controls['Nome'].value == null &&
      //   this.formSearch.controls['Sobrenome'].value == null &&
      //   this.formSearch.controls['Cpf'].value == null
      // ) {

      //   console.log(this.formSearch.value);
      //   this.toastr.warning('Preencha algum dos campos.', 'Pesquisa Pessoa Física');
      //   this.loading = false;
      // } else {
      //   this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(
      //     this.sos.tryEmptyToNull(this.formSearch.controls['Nome'].value),
      //     this.sos.tryEmptyToNull(this.formSearch.controls['Sobrenome'].value),
      //     this.sos.tryEmptyToNull(this.formSearch.controls['Cpf'].value)
      //   );
      //   this.loading = false;
      // }
    } else {

      this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(
        this.sos.tryEmptyToNull(this.formSearch.controls['NomeFantasia'].value),
        this.sos.tryEmptyToNull(this.formSearch.controls['Cnpj'].value),
        this.sos.tryEmptyToNull(this.formSearch.controls['RazaoSocial'].value)
      );


      // if (
      //   this.formSearch.controls['NomeFantasia'].value == null &&
      //   this.formSearch.controls['Cnpj'].value == null &&
      //   this.formSearch.controls['RazaoSocial'].value  == null
      // ) {
      //   this.toastr.warning('Preencha algum dos campos.', 'Pesquisa Pessoa Jurídicas');
      //   this.loading = false;
      // } else {
      //   this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(
      //     this.sos.tryEmptyToNull(this.formSearch.controls['NomeFantasia'].value),
      //     this.sos.tryEmptyToNull(this.formSearch.controls['Cnpj'].value),
      //     this.sos.tryEmptyToNull(this.formSearch.controls['RazaoSocial'].value)
      //   );
      // }
    }
  }
}
