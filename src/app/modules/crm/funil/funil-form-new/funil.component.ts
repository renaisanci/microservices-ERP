import { HelperService } from './../../../../shared/services/helper-service.service';
import { Funil } from './../../../../models/funil';
import { MaskBase } from './../../../../shared/services/mask-base';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';

@Component({
  selector: 'dbcorp-funil',
  templateUrl: './funil.component.html',
  styleUrls: ['./funil.component.css']
})
export class FunilComponent extends MaskBase  implements OnInit {
  customTitleMomalFormNovo = 'Funil';
  @Input() dadosUpdateFunil: any;
  form: FormGroup;
  submitted = false;




  constructor(    private formBuilder: FormBuilder,     private sos: HelperService) {      super();  }

  ngOnInit() {

    this.validationForm();

  }

  recebeDadosUpdate(dados: any = null) {
    this.dadosUpdateFunil = dados;

  }

  onSubmit() {
    this.submitted = true;
    // here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loadingSalvar = true;





  }


  validationForm(dados: any = null) {
    this.form = this.formBuilder.group({
      Funil: [null, Validators.compose([Validators.required])],
    });
  }


}
