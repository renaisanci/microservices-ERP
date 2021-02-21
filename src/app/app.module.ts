
import { FilterByPipe } from './shared/pipes/filter-menu.pipe';
import { SharedModule } from './shared/shared.module';
import { MenuItems } from '../mock/menu/menu-items';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './core/layouts/header/header.component';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SpinnerComponent } from './core/layouts/spinner/spinner.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './material-module';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { BlankComponent } from './core/layouts/blank/blank.component';
import { MainComponent } from './core/layouts/main/main.component';
import { SidebarComponent } from './core/layouts/sidebar/sidebar.component';
import { AuthGuard } from './core/guards/auth.guard';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import {NgDynamicBreadcrumbModule} from 'ng-dynamic-breadcrumb';
import { CustomFormsModule } from 'ngx-custom-validators';
import { NgxFlagIconCssModule } from 'ngx-flag-icon-css';

import ptBr from '@angular/common/locales/pt'; // necessário a partir do Angular v5
import { registerLocaleData, LocationStrategy, HashLocationStrategy } from '@angular/common'; // necessário a partir do Angular v5
registerLocaleData(ptBr); // necessário a partir do Angular v5

// import ngx-translate and the http loader
import {  HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { MAT_DIALOG_DATA, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';



const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelSpeed: 2,
  wheelPropagation: true
};


@NgModule({
  declarations: [

    HeaderComponent,
    SidebarComponent,
    SpinnerComponent,
    BlankComponent,
    MainComponent,
    AppComponent,
    FilterByPipe
  ],
  imports: [
    BrowserModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    BrowserAnimationsModule,
    PerfectScrollbarModule,
    FormsModule,
    HttpClientModule,
    SharedModule,
    FlexLayoutModule,
    MaterialModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    NgDynamicBreadcrumbModule,
    CustomFormsModule,
    NgxFlagIconCssModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  }),


  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    {provide: PERFECT_SCROLLBAR_CONFIG, useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG},
    { provide: LOCALE_ID, useValue: 'pt' },

    {provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: MAT_DIALOG_DATA,
      useValue: {} },
    MenuItems,
    AuthGuard
  ],
   exports: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }


// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
