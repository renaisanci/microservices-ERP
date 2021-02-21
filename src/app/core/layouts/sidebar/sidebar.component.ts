
import { SidebarService } from './sidebar.service';
import {
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
  Input
} from '@angular/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { MediaMatcher } from '@angular/cdk/layout';
import { AuthenticationService } from '../../authentication/authentication.service';
import { User } from 'src/app/models/user';
import { Observable, of } from 'rxjs';
import { Menu } from 'src/app/models/menu';
import { catchError, finalize } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { MatSidenav } from '@angular/material';




@Component({
  selector: 'dbcorp-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnDestroy, OnInit {

  @Input() sidNav: MatSidenav;


  currentUser: User;
  public config: PerfectScrollbarConfigInterface = {};
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;
  status = false;
  userFilter: any = { DescMenu: '' };
  filtro: string;

  statusd: any;

  // Usando esse padrão fica sob responsalidade do angular gerenciar no memory leaks
  menus$: Observable<Menu[]>;

  constructor(
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    private authenticationService: AuthenticationService,
    private sidebarService: SidebarService,
    private toastr: ToastrService

  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addEventListener('resize', this._mobileQueryListener );
  }


  clickEvent(x, p) {
    if ((<any>$('#' + x + p)).attr('class') === 'ng-star-inserted') {
      (<any>$('#' + x + p)).addClass('selected');
    } else {
      (<any>$('#' + x + p)).removeClass('selected');
    }
  }


  clickEventTela() {
    this.sidNav.close();


  }

  subclickEvent() {
    this.status = true;
  }

  ngOnInit() {
    this.menus$ =  this.sidebarService.getMenu().pipe(
      // map(),
      // tap(),
      // switchMap(),
      catchError(error => {
        console.error(error);
        this.toastr.error('Erro ao carregar Menu',  error);
        // this.error$.next(true);
        return of([]);
      })
    );

  }

  ngOnDestroy(): void {
    this.mobileQuery.removeEventListener('resize', this._mobileQueryListener);
  }




}
