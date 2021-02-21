import { Component, OnInit, Input, AfterViewInit, OnDestroy } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';
import { HelperService } from 'src/app/shared/services/helper-service.service';
import { ToastrService } from 'ngx-toastr';
import { DateAdapter } from '@angular/material';
import { PessoaJuridicaService } from '../../pessoa-juridica.service';
import { first } from 'rxjs/operators';
import { MaskBase } from 'src/app/shared/services/mask-base';

@Component({
  selector: 'dbcorp-pessoa-juridica-add',
  templateUrl: './pessoa-juridica-add.component.html',
  styleUrls: ['./pessoa-juridica-add.component.css']
})
export class PessoaJuridicaAddComponent extends MaskBase implements OnInit, AfterViewInit, OnDestroy {


  public form: FormGroup;
  submitted = false;
  @Input() dadosUpdatePj: any;


  constructor(

    private fb: FormBuilder,
    private sos: HelperService,
    private pessoaJuridicaService: PessoaJuridicaService,
    private toastr: ToastrService,
    private dtAdapterMaterial: DateAdapter<any>

    ) {
      super();
      this.dtAdapterMaterial.setLocale(localStorage.getItem('language'));
     }

  ngOnInit() {
    this.validationForm(this.dadosUpdatePj);
  // this.validationForm2();
  }

  onSubmit() {
    this.submitted = true;
// here if form is invalid
    if (this.form.invalid) {
        return;
    }
  //  this.form.removeControl('Id');

    console.log(this.form.value);

    this.loadingSalvar = true;
    this.pessoaJuridicaService.save(this.form.value)
        .pipe(first())
        .subscribe(
            data => {
              setTimeout(() => this.toastr.success( 'Salvo com sucesso!', 'Cadastro de Pessoa Jurídica'));
              this.loadingSalvar = false;
            this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(null, null, null);
            this.sos.closeModal('dbcorp-pessoa');
            },
            error => {
                this.toastr.error(error, 'Erro no Cadastro de Pessoa Jurídica. ' );
                this.loadingSalvar = false;
            });

          }


  validationForm(dados: any = null) {


    this.form = this.fb.group({
       Id: [dados.Id],
       Cnpj:  [dados.Cnpj, Validators.compose([CustomValidators.number, this.sos.isValidCnpj()])],

      NomeFantasia:  [dados.NomeFantasia, Validators.compose([Validators.required])],
      RazaoSocial:    [dados.RazaoSocial, Validators.compose([Validators.required])]


      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });

  }


  validationForm2() {


    this.form = this.fb.group({

       Cnpj:  [null, Validators.compose([CustomValidators.number, this.sos.isValidCnpj()])],

      NomeFantasia:  [null, Validators.compose([Validators.required])],
      RazaoSocial:    [null, Validators.compose([Validators.required])]


      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });

  }



  deleteRegistro() {

    this.pessoaJuridicaService.remove(this.dadosUpdatePj.Id).subscribe(
      data => {
        setTimeout(() => this.toastr.success('Removido com sucesso!', 'Cadastro de Pessoa Juridica'));
        this.loadingDelete = false;
        this.pessoaJuridicaService.eventEmitterSearchPesssoaJuridica(null, null, null);
        this.sos.closeModal('dbcorp-pessoa');
      },
      error => {
        this.toastr.error(error, 'Erro ao remover Cadastro de Pessoa Juridica. ');
        this.loadingDelete = false;
      });
  }

  cancelarOperacao() {
  }


  ngAfterViewInit(): void {

  }

  ngOnDestroy(): void {

  }

}
