import { BlankComponent } from './../layouts/blank/blank.component';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './signin/signin.component';
import { NgModule } from '@angular/core';
 const authenticationRoutes: Routes = [
  {
    path: '',

    children: [
      {
        path: 'signin',
        component: SigninComponent
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(authenticationRoutes) ],
  exports: [RouterModule ]
})

export class  AuthenticationRoutingModule {}
