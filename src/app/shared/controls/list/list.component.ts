import { TranslateService } from '@ngx-translate/core';
import {
  Component,
  OnInit,
  AfterViewInit,
  TemplateRef,
  Input,
  ViewChild,
  Output,
  EventEmitter
} from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { FormBase } from '../../interfaces/formBase';
import { HelperService } from '../../services/helper-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'dbcorp-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, AfterViewInit, FormBase {
  @Input() modalFilter: TemplateRef<any>;
  @Input() modalFormNovo: TemplateRef<any>;
  @Input() customTitle: string;
  @Output() invokExcluirItens: EventEmitter<any> = new EventEmitter<any>();
  @Output() invokRefreshData: EventEmitter<any> = new EventEmitter<any>();


  constructor(
    public dialog: MatDialog,
    public translate: TranslateService,
    private sos: HelperService,
    private router: Router

  ) { }

  ngOnInit() {

    switch ((this.router.url.split('/')[2])) {
      case 'pessoa': {

        this.customTitle = 'Pessoa';
        break;
      }
      case 'cliente': {
        this.customTitle = 'Cliente';
        break;
      }
      case 'fornecedor': {
        this.customTitle = 'Fornecedor';
        break;
      }
      case 'transportadora': {
        this.customTitle = 'Transportadora';
        break;
      }
      default: {
        this.customTitle = this.customTitle;
        break;
      }
    }
  }


  ngAfterViewInit() {
    (<any>$('#inputPesquisaPadrao')).toggle(200);
    (<any>$('.dx-datagrid-header-panel')).toggle(200);

    (<any>$('#inputPesquisaPadrao .dx-datagrid-search-panel')).remove();
    (<any>$('.dx-datagrid-search-panel')).prependTo(<any>($('#inputPesquisaPadrao')));

   // (<any>$('#btnSalve')).prependTo(<any>($('#contentButtonformGenerics')));
  }

  showHideHeaderGroupGrid() {
    (<any>$('.dx-datagrid-header-panel')).toggle(200);
    (<any>$('.dx-button-content')).hide();
    (<any>$('.dx-toolbar-after')).hide();
  }

  showInputSearchGrid() {
    (<any>$('#inputPesquisaPadrao')).toggle(200);
  }

  exportExcel() {
    (<any>$('.dx-icon-export-excel-button')).click();
  }

  columnChooser() {
    (<any>$('.dx-icon-column-chooser')).click();
  }

  openModalFilter(templateComponent: TemplateRef<any>) {
    this.sos.openModalTemplateRef(templateComponent, null, this.sos.getNameSelectorTemplateRef(templateComponent));
  }

  openModalFormNovo(templateComponent: TemplateRef<any>) {
    this.sos.openModalTemplateRef(templateComponent, null, this.sos.getNameSelectorTemplateRef(templateComponent));
  }

  restaurarPadrao() {
    localStorage.removeItem('gridStatepf');
    localStorage.removeItem('gridStatepj');
  }

  deleteItems() {
    this.invokExcluirItens.emit();
  }

  refreshData() {
    this.invokRefreshData.emit();
  }
}
