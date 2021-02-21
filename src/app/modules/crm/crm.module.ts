import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { DxDataGridModule, DxTemplateModule, DxBulletModule, DevExtremeModule } from 'devextreme-angular';
import { ToastrModule } from 'ngx-toastr';
// import ngx-translate and the http loader
import {  HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TextMaskModule } from 'angular2-text-mask';
import { CrmRoutingModule } from './crm.routing';
import { CrmGuard } from './crm.guard';
import { NegociosMainComponent } from './negocios/negocios-main-base/negocios-main.component';
import { NegociosListComponent } from './negocios/negocios-list-grid/negocios-list.component';
import { NegociosFunilComponent } from './negocios/negocios-funil-kanban/negocios-funil.component';
import { DragulaModule } from 'ng2-dragula';
import { NgScrollbarModule } from 'ngx-scrollbar';
import { NegociosAddComponent } from './negocios/negocios-form-new/negocios-add.component';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { FunilMainComponent } from './funil/funil-main-base/funil-main.component';
import { FunilFilterServerComponent } from './funil/funil-filter-server/funil-filter-server.component';
import { FunilComponent } from './funil/funil-form-new/funil.component';
import { FunilListGridComponent } from './funil/funil-list-grid/funil-list.component';



@NgModule({
  declarations:
  [
      NegociosMainComponent,
      NegociosListComponent,
      NegociosFunilComponent,
      NegociosAddComponent,
      FunilMainComponent,
      FunilFilterServerComponent,
      FunilComponent,
      FunilListGridComponent
    ],
  imports: [

    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    NgScrollbarModule,
    CrmRoutingModule,
    DevExtremeModule,
    FormsModule,
    PerfectScrollbarModule,
    ReactiveFormsModule,
    ScrollingModule,
    SharedModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    ToastrModule.forRoot(),
    TextMaskModule,
    DragulaModule.forRoot(),
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
    NegociosMainComponent,
    NegociosListComponent,
    NegociosFunilComponent,
    FunilComponent,
    FunilMainComponent

  ],
  providers: [CrmGuard  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
})
export class CrmModule { }
// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
