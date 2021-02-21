import { AuthGuard } from './core/guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './core/layouts/main/main.component';
import { BlankComponent } from './core/layouts/blank/blank.component';
const appRoutes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        redirectTo: '/inicio/inicio1',
        pathMatch: 'full', canActivate: [AuthGuard]
      },
      {
        path: 'inicio',
        loadChildren: './modules/inicio/inicio.module#InicioModule',
        canActivate: [AuthGuard]
      },
      {
      path: 'dashboards',
      loadChildren: './modules/dashboards/dashboards.module#DashboardsModule',
      canActivate: [AuthGuard]
      },
      { path: 'controleacesso',
        loadChildren: './modules/controle-acesso/controle-acesso.module#ControleAcessoModule',
        canActivate: [AuthGuard]
      },
      { path: 'infraestrutura',
        loadChildren: './modules/infraestrutura/infraestrutura.module#InfraestruturaModule',
        canActivate: [AuthGuard]
      },
      { path: 'crm',
        loadChildren: './modules/crm/crm.module#CrmModule',
        canActivate: [AuthGuard]
      }
    ],
  },
    {
      path: '',
      component: BlankComponent,
      children: [
        {
          path: 'authentication',
          loadChildren:
            './core/authentication/authentication.module#AuthenticationModule'
        }
      ]
    },
  ];
  @NgModule({
      imports: [RouterModule.forRoot(appRoutes , {useHash: false }) ],
      exports: [RouterModule ]
  })

  export class  AppRoutingModule { }
