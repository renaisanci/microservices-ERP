import { TemplateRef } from '@angular/core';

export interface FormBase {

  showHideHeaderGroupGrid(): void;

  showInputSearchGrid(): void;

  exportExcel(): void;

  openModalFilter(templateComponent:  TemplateRef<any>): void;

  openModalFormNovo(templateComponent:  TemplateRef<any>): void;
}
