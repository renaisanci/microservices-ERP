import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Inicio1Component } from './inicio1/inicio1.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '../../material-module';
import {InicioRoutingModule } from './inicio.routing';
import { InicioGuard } from './inicio.guard';

@NgModule({
  declarations:
  [
    Inicio1Component
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    InicioRoutingModule,
  ],
  providers: [
    InicioGuard
  ]

})
export class InicioModule { }
