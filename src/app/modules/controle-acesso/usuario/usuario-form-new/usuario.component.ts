import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../user.service';
import { CustomValidators } from 'ngx-custom-validators';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent implements OnInit {

  registerForm: FormGroup;
  loading = false;
  submitted = false;


  constructor(
      private formBuilder: FormBuilder,
      private userService: UserService,
      private toastr: ToastrService
  ) {
    this.registerForm = new FormGroup({
       PrimeiroNome: new FormControl('', CustomValidators.range([5, 9])),
      PrimeiroNomeEmpty: new FormControl('', Validators.required)
  });


  }




  ngOnInit() {



    // stop

      // this.registerForm = this.formBuilder.group({
      //     PrimeiroNome: ['', Validators.required],
      //     UltimoNome: ['', Validators.required],
      //     Username: ['', Validators.required],
      //     Password: ['', [Validators.required, Validators.minLength(6)]]
      // });
  }



  onSubmit() {
      this.submitted = true;
  // here if form is invalid
      if (this.registerForm.invalid) {
          return;
      }

      this.loading = true;
      this.userService.register(this.registerForm.value)
          .pipe(first())
          .subscribe(
              data => {

                setTimeout(() =>     this.toastr.success( 'Registrado com sucesso!', 'Cadastro de Usuário'));

                this.loading = false;
              },
              error => {
                  this.toastr.error(error, 'Erro no Cadastro de Usuário. ' );
                  this.loading = false;
              });

  }
}
