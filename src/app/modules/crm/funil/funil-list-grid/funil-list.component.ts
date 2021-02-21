import { Component, OnInit } from '@angular/core';
import { FunilComponent } from '../funil-form-new/funil.component';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material';
import { HelperService } from 'src/app/shared/services/helper-service.service';

@Component({
  selector: 'dbcorp-funil-list',
  templateUrl: './funil-list.component.html',
  styleUrls: ['./funil-list.component.css']
})
export class FunilListGridComponent implements OnInit {

  columns: any[];
  ds: any[];
  localeIdioma = localStorage.getItem('language');

  constructor(
    private toastr: ToastrService,
    public dialog: MatDialog,
    private sos: HelperService

  ) { }

  ngOnInit() {
  }

  loadState = () => {

  }
  saveState = state => {


  }

  cellClickHandler(e) {
    if (e.columnIndex === 1) {
      this.sos.openModalComponenType(FunilComponent, e.data, 'dbcorp-funil');
    }
  }

  setStyle(e) {
    if (e.rowType === 'data') {
      if (e.column.dataField === 'Id') {
        e.cellElement.className = 'btn btn-link';
        e.cellElement.style = 'display: table-cell;  text-align: left;';
      } else if (e.column.index > 0) {
        // quando aplica esste style, nao se consegue selecionar o valor da cell, caso queira copiar
        //  e.cellElement.style = ' pointer-events: none;';
      }
    }
  }

}
