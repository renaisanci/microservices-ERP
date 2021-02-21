import { InicioGuard } from './inicio.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Inicio1Component } from './inicio1/inicio1.component';

const inicioRoutes: Routes = [
  {
    path: '',  canActivateChild: [InicioGuard],
    children: [
      {
        path: 'inicio1',
        component: Inicio1Component,
        data: {

          breadcrumb: [
            {
              label: 'Inicio',
              url: ''
            }
          ]
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(inicioRoutes) ],
  exports: [RouterModule ]
})

export class  InicioRoutingModule { }
