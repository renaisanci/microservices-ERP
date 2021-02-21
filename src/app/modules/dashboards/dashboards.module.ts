import { ChartsModule } from 'ng2-charts';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '../../material-module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DashboardRoutingModule } from './dashboards.routing';
import { Dashboard2Component } from './dashboard2/dashboard2.component';
import { DashboardGuard } from './dashboard.guard';
import { Dashboard1Component } from './dashboard1/dashboard1.component';
import { ChartistModule } from 'ng-chartist';

@NgModule({
  declarations:
  [
    Dashboard1Component,
    Dashboard2Component
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    DashboardRoutingModule,
    ChartistModule,
    ChartsModule,
  ],
  providers: [
    DashboardGuard
  ]

})
export class DashboardsModule { }




