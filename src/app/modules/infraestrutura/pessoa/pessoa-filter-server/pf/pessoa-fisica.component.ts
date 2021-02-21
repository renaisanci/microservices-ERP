import { HelperService } from './../../../../../shared/services/helper-service.service';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';

const password = new FormControl('', Validators.required);
const confirmPassword = new FormControl('', CustomValidators.equalTo(password));

@Component({
  selector: 'dbcorp-pessoa-fisica',
  templateUrl: './pessoa-fisica.component.html',
  styleUrls: ['./pessoa-fisica.component.css']
})


export class PessoaFisicaComponent implements OnInit {
  public form: FormGroup;

  @Output() formPf = new EventEmitter();

  constructor(private fb: FormBuilder, private sos: HelperService) { }

  ngOnInit() {


           this.validationForm();
           // emit o formulario para o pai
           this.formPf.emit(this.form);
  }


  validationForm() {


    this.form = this.fb.group({
       Nome:  [null, Validators.compose([ Validators.minLength(3)])],
      Cpf: [null, Validators.compose([CustomValidators.number,
       // this.sos.isValidCpf()
      ])
      ],
      Sobrenome:  [null],
      // range:  [null, Validators.compose([Validators.required, CustomValidators.range([5, 9])])],
      // url:    [null, Validators.compose([Validators.required, CustomValidators.url])],
      // date:   [null, Validators.compose([Validators.required, CustomValidators.date]) ],

      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });

  }
}
