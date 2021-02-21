 import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ControleAcessoRoutingModule } from './controle-acesso.routing';
import { ControleAcessoGuard } from './controle-acesso.guard';
import { MatTreeModule, MatDatepickerModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { SharedModule } from 'src/app/shared/shared.module';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { DxDataGridModule,
  DxBulletModule,
  DxTemplateModule } from 'devextreme-angular';
import { ToastrModule } from 'ngx-toastr';
import { UsuarioComponent } from './usuario/usuario-form-new/usuario.component';
import { ListUsuarioComponent } from './usuario/usuario-list-grid/list-usuario.component';
import { UsuarioMainComponent } from './usuario/usuario-main-base/usuario-main.component';
import { UsuarioFilterServerComponent } from './usuario/usuario-filter-server/usuario-filter-server.component';
import { TelaFilter2Component } from './usuario/usuario-filter-server/tela-filter2/tela-filter2.component';
import { TelaFilter1Component } from './usuario/usuario-filter-server/tela-filter1/tela-filter1.component';


@NgModule({
  declarations: [
    UsuarioComponent,
    ListUsuarioComponent,
    UsuarioMainComponent,
    UsuarioFilterServerComponent,
    TelaFilter1Component,
    TelaFilter2Component
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    ControleAcessoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTreeModule,
    MatDatepickerModule,
    SharedModule,
    NgMultiSelectDropDownModule.forRoot(),
    CollapseModule.forRoot(),
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    ToastrModule.forRoot()
  ],
  entryComponents : [
    ListUsuarioComponent,
    UsuarioComponent,
    UsuarioFilterServerComponent, TelaFilter1Component, TelaFilter2Component],
  providers: [ControleAcessoGuard, UsuarioFilterServerComponent ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  exports: [
    UsuarioFilterServerComponent
 ]
})
export class ControleAcessoModule { }
