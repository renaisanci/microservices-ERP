import { Injectable, ViewChild, TemplateRef, ComponentRef, Type, ElementRef } from '@angular/core';
import { AbstractControl, Validators } from '@angular/forms';
import { SessionLocalService } from './session-locale.service';
import { MatDialog } from '@angular/material';
import { ComponentType } from '@angular/cdk/overlay/typings';


@Injectable({
  providedIn: 'root'
})
export class HelperService {
  constructor(private sessionLocalService: SessionLocalService,   public dialog: MatDialog) { }

  // Pega id da tab ativa
  getTabId(viewChild: ViewChild) {
    return viewChild['_tabs']['_results'][viewChild['selectedIndex']]['_viewContainerRef'].element.nativeElement.id;
  }

 // retorna o nome do selector de um TemplateRef
  getNameSelectorTemplateRef(templateComponent: TemplateRef<any> | ComponentType<any>): string {
    return   templateComponent['_def']['element']['template']['lastRenderRootNode']['element']['name'];
  }

  // retorna o nome do selector de um component
 // getNameSelectorComponentRef(templateComponent: ComponentRef<any>): string {
    // const decorators: any[] = (<any>templateComponent).__annotations__;
    // const componentDecorator = decorators && decorators.find(d => d.ngMetadataName === templateComponent.name);
    // return componentDecorator && componentDecorator.selector;
  // return Reflect.getOwnPropertyDescriptor(templateComponent, '__annotations__').value[0].selector;
   // console.log(templateComponent['__annotations__']);
   // console.log('dbcorp-' + templateComponent.name.substring(0, templateComponent.name.length - 9).toLowerCase());

 //  console.log( templateComponent.name.toString())
 //  console.log(Object.getOwnPropertyNames(templateComponent));

 //  console.log( 'dbcorp-' + templateComponent.name.substring(0, templateComponent.name.length - 9).toLowerCase() + ' >> criando modal');
    // necessario fazer essa concatenação para manter o padrão de pegar o nome do selector
    // 9 igual a palavra component q é padrão quando se cria um component
  //   return   'dbcorp-' + templateComponent.name.substring(0, templateComponent.name.length - 9).toLowerCase();
 // }

  // fecha o modal pelo id que foi registrado na abertura
  closeModal(modalNameSelectorComponent: string) {
    const matRef = this.dialog.getDialogById(modalNameSelectorComponent);

    if (matRef === undefined) { return; }

   // console.log(modalNameSelectorComponent + ' >> fechando modal');
   // console.log(matRef.id);
      matRef.close();

  }

// recebe um coponent como parametro para abrir no modal
  openModalComponenType(component: ComponentType<any>, obj: any, name: string) {

  //  console.log(name + ' >> cria modal');

      const dialogRefCt = this.dialog.open(component, {
       id: name,
        data: obj,
        disableClose: true
      });
      dialogRefCt.afterClosed().subscribe(result => {
       // console.log(`Dialog openModalComponenType: ${result}`);
      });
    }

// recebe um TemplateRef como parametro para abrir no modal
  openModalTemplateRef(templateComponent: TemplateRef<any>, obj, name:string) {

    const dialogRef = this.dialog.open(templateComponent, {
      id: name,
      data: obj,
      disableClose: true

    });
    dialogRef.afterClosed().subscribe(result => {
     // console.log(`Dialog openModalTemplateRef: ${result}`);
    });
  }

  /**
    * Valida se o CPF é valido. Deve-se ser informado o cpf sem máscara.
   */
  isValidCpf() {
    return (control: AbstractControl): Validators => {
      const cpf = control.value;
      if (cpf) {
        let numbers, digits, sum, i, result, equalDigits;
        equalDigits = 1;
        if (cpf.length < 11) {
          return null;
        }

        for (i = 0; i < cpf.length - 1; i++) {
          if (cpf.charAt(i) !== cpf.charAt(i + 1)) {
            equalDigits = 0;
            break;
          }
        }

        if (!equalDigits) {
          numbers = cpf.substring(0, 9);
          digits = cpf.substring(9);
          sum = 0;
          for (i = 10; i > 1; i--) {
            sum += numbers.charAt(10 - i) * i;
          }

          result = sum % 11 < 2 ? 0 : 11 - (sum % 11);

          if (result !== Number(digits.charAt(0))) {
            return { cpfNotValid: true };
          }
          numbers = cpf.substring(0, 10);
          sum = 0;

          for (i = 11; i > 1; i--) {
            sum += numbers.charAt(11 - i) * i;
          }
          result = sum % 11 < 2 ? 0 : 11 - (sum % 11);

          if (result !== Number(digits.charAt(1))) {
            return { cpfNotValid: true };
          }
          return null;
        } else {
          return { cpfNotValid: true };
        }
      }
      return null;
    };
  }


  /**
    * Valida se o CNPJ é valido. Deve-se ser informado o CNPJ sem máscara.
   */
  isValidCnpj() {
    return (control: AbstractControl): Validators => {
      const cnpj = control.value;

      if (cnpj) {

        if (cnpj.length < 14) {
          return { cnpjNotValid: true };
        }

        // Elimina CNPJs invalidos conhecidos
        if (cnpj == "00000000000000" ||
          cnpj == "11111111111111" ||
          cnpj == "22222222222222" ||
          cnpj == "33333333333333" ||
          cnpj == "44444444444444" ||
          cnpj == "55555555555555" ||
          cnpj == "66666666666666" ||
          cnpj == "77777777777777" ||
          cnpj == "88888888888888" ||
          cnpj == "99999999999999")
          return { cnpjNotValid: true };

        // Valida DVs
        let tamanho = cnpj.length - 2
        let numeros = cnpj.substring(0, tamanho);
        let digitos = cnpj.substring(tamanho);
        let soma = 0;
        let pos = tamanho - 7;
        for (let i = tamanho; i >= 1; i--) {
          soma += numeros.charAt(tamanho - i) * pos--;
          if (pos < 2) {
            pos = 9;
          }
        }
        let resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
          return { cnpjNotValid: true };
        }

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (let i = tamanho; i >= 1; i--) {
          soma += numeros.charAt(tamanho - i) * pos--;
          if (pos < 2) {
            pos = 9;
          }
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) {
          return { cnpjNotValid: true };

        }
        return null;

      }
      return null;
    };
  }


  tryEmptyToNull(obj: any) {
    return obj === '' ? null : obj;
  }


  tryDateLocale(date: any) {

    if (date == null) {return; }
    if (this.sessionLocalService.locale === 'en') {
      return new Date(date.split('/')[2], date.split('/')[0] - 1 , date.split('/')[1] , 0);

    } else if (this.sessionLocalService.locale === 'es') {

      return new Date(date.split('/')[2], date.split('/')[1] - 1, date.split('/')[0], 0);

    } else if (this.sessionLocalService.locale === 'pt') {

      return new Date(date.split('/')[2], date.split('/')[1] - 1, date.split('/')[0], 0);
    }

  }


}

