import { HelperService } from 'src/app/shared/services/helper-service.service';
import { NgModule } from '@angular/core';
import { AccordionLinkDirective } from './directives/accordion/accordionlink.directive';
import { AccordionAnchorDirective } from './directives/accordion/accordionanchor.directive';
import { AccordionDirective } from './directives/accordion/accordion.directive';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material-module';
import { ListComponent } from './controls/list/list.component';
import { LocalNumberPipe } from './pipes/local-number.pipe';
import { LocalDatePipe } from './pipes/local-date.pipe';

// import ngx-translate and the http loader
import { HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TabComponent } from './controls/tab/tab.component';
import { FormComponent } from './controls/form/form.component';
import { FlexModule, FlexLayoutModule } from '@angular/flex-layout';
import { SaveButtonComponent } from './controls/buttons/save-button/save-button.component';
import { DeleteButtonComponent } from './controls/buttons/delete-button/delete-button.component';
import { ButtonComponent } from './controls/buttons/button/button.component';
import { SearchButtonComponent } from './controls/buttons/search-button/search-button.component';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { CancelButtonComponent } from './controls/buttons/cancel-button/cancel-button.component';

import {
  DxSelectBoxModule,
  DxCheckBoxModule,
  DxTextBoxModule,
  DxDateBoxModule,
  DxButtonModule,
  DxValidatorModule,
  DxValidationSummaryModule
} from 'devextreme-angular';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TextInputComponent } from './controls/inputs/text-input/text-input.component';
import { NewFormComponent } from './controls/form/new-form/new-form.component';





@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    ListComponent,
    LocalDatePipe,
    LocalNumberPipe,
    TabComponent,
    FormComponent,
    SaveButtonComponent,
    DeleteButtonComponent,
    ButtonComponent,
    SearchButtonComponent,
    CancelButtonComponent,
    TextInputComponent,
    NewFormComponent
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    ListComponent,
    FormComponent,
    LocalDatePipe,
    LocalNumberPipe,
    TabComponent,
    SaveButtonComponent,
    DeleteButtonComponent,
    ButtonComponent,
    SearchButtonComponent,
    CancelButtonComponent,
    MaterialModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    DxTextBoxModule,
    DxDateBoxModule,
    DxButtonModule,
    DxValidatorModule,
    DxValidationSummaryModule,
    TextInputComponent,
    NewFormComponent
  ],

  entryComponents: [
    ListComponent,
    TabComponent,
    FormComponent,
    SaveButtonComponent,
    DeleteButtonComponent,
    ButtonComponent,
    CancelButtonComponent,
    SearchButtonComponent,
    TextInputComponent,
    NewFormComponent
  ],
  imports: [

    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    MaterialModule,
    PerfectScrollbarModule,
    FlexLayoutModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    DxTextBoxModule,
    DxDateBoxModule,
    DxButtonModule,
    DxValidatorModule,
    DxValidationSummaryModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: false
    })
  ],
  providers: [HelperService]
})
export class SharedModule {}

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
