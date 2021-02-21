import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ControleAcessoGuard } from './controle-acesso.guard';
import { UsuarioMainComponent } from './usuario/usuario-main-base/usuario-main.component';



const controleAcessoRoutes: Routes = [
  {
    path: '',  canActivateChild: [ControleAcessoGuard],
    children: [
      {
        path: 'usuario',
        component: UsuarioMainComponent,
        data: {

          breadcrumb: [
            {
              label: 'Controle de acesso / Usuário',
              url: ''
            }
          ]
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(controleAcessoRoutes) ],
  exports: [RouterModule ]
})

export class  ControleAcessoRoutingModule { }
