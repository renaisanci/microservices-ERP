
import { MediaMatcher } from '@angular/cdk/layout';
import {
  ChangeDetectorRef,
  Component,
  OnDestroy,
  AfterViewInit,
  OnInit
} from '@angular/core';
import * as $ from 'jquery';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { MenuItems } from 'src/mock/menu/menu-items';
import { AuthenticationService } from '../../authentication/authentication.service';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';
import { SessionLocalService } from 'src/app/shared/services/session-locale.service';
import { registerLocaleData } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import {_} from '@biesbjerg/ngx-translate-extract/dist/utils/utils';
import { DateAdapter } from '@angular/material';




/** @title Responsive sidenav */
@Component({
  selector: 'dbcorp-main-layout',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnDestroy, AfterViewInit, OnInit {

  today = new Date();
  val = 123.45;

  currentUser: User;
  mobileQuery: MediaQueryList;
  dir = 'ltr';
  dbcorp: boolean;
  green: boolean;
  blue: boolean;
  dark: boolean;
  minisidebar: boolean;
  boxed: boolean;
  danger: boolean;
  showHide: boolean;
  sidebarOpened;
  lanBr: boolean;
  lanEs: boolean;
  lanUs: boolean;

  public config: PerfectScrollbarConfigInterface = {};
  private _mobileQueryListener: () => void;
  public  dateFooter = new Date().getFullYear();
  dadosts$: Observable<String[]>;


  constructor(

    private authenticationService: AuthenticationService,
    private localService: SessionLocalService,
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    public menuItems: MenuItems,
    private translate: TranslateService,
    private adapter: DateAdapter<any>
  ) {



    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // this.mobileQuery.addListener(this._mobileQueryListener );
     this.mobileQuery.addEventListener('resize', this._mobileQueryListener );

  }

  ngOnDestroy(): void {
   //  this.mobileQuery.removeListener( this._mobileQueryListener);
    this.mobileQuery.removeEventListener('resize', this._mobileQueryListener);
  }
  ngAfterViewInit() {

    (<any>$('.srh-btn, .cl-srh-btn')).on('click', function() {
      (<any>$('.app-search')).toggle(200);
    });


  }

  ngOnInit() {
   if(localStorage.getItem('language') === null) {
              // default PT
            localStorage.setItem('language', 'pt');
   }
    // buscar no banco o idioma gravado ou ao selecionar grava no local storage e regarrega;
    switch(localStorage.getItem('language')) {
      case 'pt': {
        this.registraConfRegionais('pt');


         break;
      }
      case 'en': {
        this.registraConfRegionais('en');
         break;
      }
      case 'es': {
        this.registraConfRegionais('es');
        this.adapter.setLocale('es');
         break;
      }
      default: {
        this.registraConfRegionais('pt');
         break;
      }
   }
  }


  languageBr() {

    localStorage.setItem('language', 'pt');
    location.reload();
  }

  languageEs() {

    localStorage.setItem('language', 'es');
    location.reload();
  }

  languageUs() {
    localStorage.setItem('language', 'en');
    location.reload();
  }


  registraConfRegionais(language){

    this.registerCulture(language);
    this.translate.use(language);


    switch(language) {
      case 'pt': {
        this.lanEs = false;
        this.lanUs = false;
        this.lanBr = true;
         break;
      }
      case 'en': {
        this.lanEs = false;
        this.lanUs = true;
        this.lanBr = false;
         break;
      }
      case 'es': {
        this.lanEs = true;
        this.lanUs = false;
        this.lanBr = false;
         break;
      }
      default: {
        this.lanEs = false;
        this.lanUs = false;
        this.lanBr = true;
         break;
      }
   }

  }


  private registerCulture(culture: string) {
    if (!culture) {
      return;
    }
    this.localService.locale = culture;
    const localeId = culture;

    this.localeInitializer(localeId).then(() => {
      this.today = new Date();
      this.val++;
    });
  }

  localeInitializer(localeId: string): Promise<any> {
    return import(
      /* webpackInclude: /(pt|en|es)\.js$/ */
      `@angular/common/locales/${localeId}.js`
      ).then(module => registerLocaleData(module.default));
  }




  // @HostListener('document:click')
  // clickout() {
  //   alert('clicou fora');
  //   }

  // Mini sidebar
}

