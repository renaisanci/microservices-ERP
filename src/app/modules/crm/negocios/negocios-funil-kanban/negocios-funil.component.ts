import { Component } from '@angular/core';
import { FunilEtapa, Negocio } from './../../../../models/funil-etapa';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem
} from '@angular/cdk/drag-drop';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

@Component({
  selector: 'dbcorp-negocios-funil',
  templateUrl: './negocios-funil.component.html',
  styleUrls: ['./negocios-funil.component.scss']
})
export class NegociosFunilComponent {
  public config: PerfectScrollbarConfigInterface = {};

  shown: 'hover';

  todo = ['Get to work', 'Pick up groceries', 'Go home', 'Fall asleep'];

  done = ['Get up', 'Brush teeth', 'Take a shower', 'Check e-mail', 'Walk dog'];

  funilEtapa: FunilEtapa[] = [
    {
      FunilEtapaId: 1,
      NomeFunilEtapa: 'Cliente Potencial',

      Negocios: [
        {
          NegocioId: 1,
          FunilEtapaId: 1,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 01.'
        },
        {
          NegocioId: 2,
          FunilEtapaId: 1,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 02.'
        }
      ]
    },
    {
      FunilEtapaId: 2,
      NomeFunilEtapa: 'Contatado',

      Negocios: [
        {
          NegocioId: 3,
          FunilEtapaId: 2,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 04'
        },
        {
          NegocioId: 4,
          FunilEtapaId: 2,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 05'
        },
        {
          NegocioId: 5,
          FunilEtapaId: 2,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 06'
        },
        {
          NegocioId: 6,
          FunilEtapaId: 2,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 07'
        }
      ]
    },
    {
      FunilEtapaId: 3,
      NomeFunilEtapa: 'Reunião Agendada',

      Negocios: [
        {
          NegocioId: 7,
          FunilEtapaId: 3,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 08'
        },
        {
          NegocioId: 8,
          FunilEtapaId: 3,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 09'
        }
      ]
    },
    {
      FunilEtapaId: 4,
      NomeFunilEtapa: 'Proposta Feita',

      Negocios: [
        {
          NegocioId: 9,
          FunilEtapaId: 4,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 11'
        },
        {
          NegocioId: 10,
          FunilEtapaId: 4,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 12'
        }
      ]
    },

    {
      FunilEtapaId: 5,
      NomeFunilEtapa: 'Negociações Iniciada',

      Negocios: [
        {
          NegocioId: 11,
          FunilEtapaId: 5,
          Titulo: 'Launch new template',
          Organizacao: 'Empresa 13'
        }
      ]
    }
  ];

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );

      // console.log('moveItemInArray');
    } else {
      // console.log('transferArrayItem');

      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );

      console.log(
        'Id do Negocio >> ' +
          event.container.data[event.currentIndex]['NegocioId']
      );
      console.log(
        'Organizacao do Negocio >> ' +
          event.container.data[event.currentIndex]['Organizacao']
      );

      console.log(
        'O funil Etapa para onde vou mandar é >> ' + event.container.id
      );
    }
  }
}
