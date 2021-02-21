import { DashboardGuard } from './dashboard.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Dashboard2Component } from './dashboard2/dashboard2.component';
import { Dashboard1Component } from './dashboard1/dashboard1.component';


const dashboardsRoutes: Routes = [
  {
    path: '',  canActivateChild: [DashboardGuard],
    children: [
      {
        path: 'dashboard1',
        component: Dashboard1Component,
        data: {

          breadcrumb: [
            {
              label: 'Dashboard > Cost Avoidence',
              url: ''
            }
          ]
        },
      },
      {
        path: 'dashboard2',
        component: Dashboard2Component,
        data: {

          breadcrumb: [
            {
              label: 'Dashboard > Saving',
              url: ''
            }
          ]
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardsRoutes) ],
  exports: [RouterModule ]
})

export class  DashboardRoutingModule { }
