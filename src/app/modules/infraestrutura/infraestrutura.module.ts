import { PessoaListComponent } from './pessoa/pessoa-list-grid/pessoa-list.component';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PessoaFilterServerComponent } from './pessoa/pessoa-filter-server/pessoa-filter-server.component';
import { PessoaMainComponent } from './pessoa/pessoa-main-base/pessoa-main.component';
import { PessoaComponent } from './pessoa/pessoa-form-new/pessoa.component';
import { MaterialModule } from 'src/app/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { InfraestruturaRoutingModule } from './infraestrutura.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { DxDataGridModule, DxTemplateModule, DxBulletModule } from 'devextreme-angular';
import { ToastrModule } from 'ngx-toastr';
import { InfraestruturaGuard } from './infraestrutura.guard';
import { PessoaFisicaComponent } from './pessoa/pessoa-filter-server/pf/pessoa-fisica.component';
import { PessoaJuridicaComponent } from './pessoa/pessoa-filter-server/pj/pessoa-juridica.component';

// import ngx-translate and the http loader
import {  HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { PessoaFisicaAddComponent } from './pessoa/pessoa-form-new/pf/pessoa-fisica-add.component';
import { PessoaJuridicaAddComponent } from './pessoa/pessoa-form-new/pj/pessoa-juridica-add.component';
import { TextMaskModule } from 'angular2-text-mask';
import { MatDialogRef, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';




@NgModule({
  declarations:
  [
    PessoaListComponent,
    PessoaMainComponent,
    PessoaComponent,
    PessoaFilterServerComponent,
    PessoaFisicaComponent,
    PessoaJuridicaComponent,
    PessoaFisicaAddComponent,
    PessoaJuridicaAddComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    InfraestruturaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    ToastrModule.forRoot(),
    TextMaskModule,

    TranslateModule.forChild({
      loader: {
          provide: TranslateLoader,
          useFactory: (HttpLoaderFactory),
          deps: [HttpClient]
      },
      isolate: false
})
  ],
  entryComponents : [
    PessoaListComponent,
    PessoaComponent,
    PessoaFilterServerComponent,
    PessoaFisicaComponent,
    PessoaJuridicaComponent,
    PessoaFisicaAddComponent,
    PessoaJuridicaAddComponent

  ],
  providers: [InfraestruturaGuard ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
})
export class InfraestruturaModule { }
// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
