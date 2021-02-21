import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InfraestruturaGuard } from './infraestrutura.guard';
import { PessoaMainComponent } from './pessoa/pessoa-main-base/pessoa-main.component';



const infraestruturaRoutes: Routes = [
  {
    path: '',  canActivateChild: [InfraestruturaGuard],
    children: [
      {
        path: 'pessoa', component: PessoaMainComponent, data: {

          breadcrumb: [
            {
              label: 'Infraestrutura / Pessoa',
              url: ''
            }
          ]
        },
      },

      {
        path: 'cliente', component: PessoaMainComponent, data: {

          breadcrumb: [
            {
              label: 'Infraestrutura / Cliente',
              url: ''
            }
          ]
        },
      },
      {
        path: 'fornecedor', component: PessoaMainComponent, data: {

          breadcrumb: [
            {
              label: 'Infraestrutura / Fornecedor',
              url: ''
            }
          ]
        },
      },
      {
        path: 'transportadora', component: PessoaMainComponent, data: {

          breadcrumb: [
            {
              label: 'Infraestrutura / Transportadora',
              url: ''
            }
          ]
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(infraestruturaRoutes) ],
  exports: [RouterModule ]
})

export class  InfraestruturaRoutingModule { }
