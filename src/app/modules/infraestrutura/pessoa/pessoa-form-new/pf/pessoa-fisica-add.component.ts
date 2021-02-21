import { MaskBase } from './../../../../../shared/services/mask-base';
import { HelperService } from './../../../../../shared/services/helper-service.service';
import { Component, OnInit, Input, ViewChild, ViewContainerRef, AfterViewInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PessoaFisicaService } from '../../pessoa-fisica.service';
import { first } from 'rxjs/operators';
import { CustomValidators } from 'ngx-custom-validators';
import { DateAdapter } from '@angular/material';
import * as textMask from 'vanilla-text-mask/dist/vanillaTextMask.js';


@Component({
  selector: 'dbcorp-pessoa-fisica-add',
  templateUrl: './pessoa-fisica-add.component.html',
  styleUrls: ['./pessoa-fisica-add.component.css']
})

export class PessoaFisicaAddComponent extends MaskBase implements OnInit, AfterViewInit, OnDestroy {

  form: FormGroup;

  submitted = false;
  @Input() dadosUpdatePf: any;

  // necessário apra funcionar a mascara de data com datepicker do angular material
  @ViewChild('inputDtNascimento', { read: ViewContainerRef }) public inputDtNascimento;
  maskedInputController;



  constructor(
    private pessoaFisicaService: PessoaFisicaService,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private sos: HelperService,
    private dtAdapterMaterial: DateAdapter<any>

  ) {

    super();
    this.dtAdapterMaterial.setLocale(localStorage.getItem('language'));
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.maskedInputController = textMask.maskInput({
        inputElement: this.inputDtNascimento.element.nativeElement,
        mask: this.maskDate
      });
    });
  }

  ngOnInit() {

    //  console.log(this.dadosUpdatePf);

    this.validationForm(this.dadosUpdatePf);

  }


  onSubmit() {
    this.submitted = true;
    // here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loadingSalvar = true;

    console.log(this.form.value);

    this.pessoaFisicaService.save(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          setTimeout(() => this.toastr.success('Salvo com sucesso!', 'Cadastro de Pessoa Física'));
          this.loadingSalvar = false;

          // TODO colocar filtros da ultima consulta feita
          this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(null, null, null);
          this.sos.closeModal('dbcorp-pessoa');
        },
        error => {
          this.toastr.error(error, 'Erro no Cadastro de Pessoa Física. ');
          this.loadingSalvar = false;
        });

  }


  validationForm(dados: any = null) {

    this.form = this.fb.group({
      Id:[dados.Id],
      Nome: [dados.Nome, Validators.compose([Validators.required, Validators.minLength(3)])],
      Cpf: [dados.Cpf, Validators.compose([Validators.required,
      CustomValidators.number, Validators.pattern('[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}'),
      this.sos.isValidCpf()])],
      Sobrenome: [dados.Sobrenome, Validators.required],
      Rg: [dados.Rg],
      DtNascimento:  [this.sos.tryDateLocale(dados.DtNascimento)],
      // date:   [null, Validators.compose([Validators.required, CustomValidators.date]) ],
      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });


    console.log( this.form.value );


  }

  deleteRegistro() {
    this.pessoaFisicaService.remove(this.dadosUpdatePf.Id).subscribe(
      data => {
        setTimeout(() => this.toastr.success('Removido com sucesso!', 'Cadastro de Pessoa Física'));
        this.loadingDelete = false;
        this.pessoaFisicaService.eventEmitterSearchPesssoaFisica(null, null, null);
        this.sos.closeModal('dbcorp-pessoa');
      },
      error => {
        this.toastr.error(error, 'Erro ao remover Cadastro de Pessoa Física. ');
        this.loadingDelete = false;
      });
  }

  cancelarOperacao() {
  }

  ngOnDestroy() {
    this.maskedInputController.destroy();
  }
}
