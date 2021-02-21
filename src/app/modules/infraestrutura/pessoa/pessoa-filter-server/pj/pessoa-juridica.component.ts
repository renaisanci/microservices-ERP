import { HelperService } from './../../../../../shared/services/helper-service.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';

@Component({
  selector: 'dbcorp-pessoa-juridica',
  templateUrl: './pessoa-juridica.component.html',
  styleUrls: ['./pessoa-juridica.component.css']
})
export class PessoaJuridicaComponent implements OnInit {
  public form: FormGroup;

  @Output() formPj = new EventEmitter();


  constructor(private fb: FormBuilder, private sos: HelperService) { }

  ngOnInit() {
    this.validationForm();
       // emit o formulario para o pai
       this.formPj.emit(this.form);
  }


  validationForm() {


    this.form = this.fb.group({
       Cnpj:  [null, Validators.compose([CustomValidators.number, this.sos.isValidCnpj()])],

      NomeFantasia:  [null],
      RazaoSocial:    [null]
      // date:   [null, Validators.compose([Validators.required, CustomValidators.date]) ],

      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });

  }

}
