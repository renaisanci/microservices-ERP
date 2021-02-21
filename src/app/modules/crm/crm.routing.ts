import { FunilMainComponent } from './funil/funil-main-base/funil-main.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrmGuard } from './crm.guard';
import { NegociosMainComponent } from './negocios/negocios-main-base/negocios-main.component';





const crmRoutes: Routes = [
  {
    path: '',  canActivateChild: [CrmGuard],
    children: [
      {
        path: 'negocios', component: NegociosMainComponent, data: {

          breadcrumb: [
            {
              label: 'CRM / Processos / Negócios',
              url: ''
            }
          ]
        },
      },

      {
        path: 'funil', component: FunilMainComponent, data: {

          breadcrumb: [
            {
              label: 'CRM / Cadastros / Funil',
              url: ''
            }
          ]
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(crmRoutes) ],
  exports: [RouterModule ]
})

export class  CrmRoutingModule { }
