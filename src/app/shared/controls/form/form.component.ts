import { Component, OnInit, Inject, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'dbcorp-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit, AfterViewInit {

  @Output() dataUpdateForm: EventEmitter<any> = new EventEmitter<any>();



  constructor( @Inject(MAT_DIALOG_DATA) public _data: any ) {

  }

  ngOnInit() {

    // will log the entire data object
    // console.log(this._data);
     this.dataUpdateForm.emit(this._data);
  }


  ngAfterViewInit() {
    // (<any>$('#inputPesquisaPadrao')).toggle(200);
    // (<any>$('.dx-datagrid-header-panel')).toggle(200);

    // (<any>$('#inputPesquisaPadrao .dx-datagrid-search-panel')).remove();
    // (<any>$('.dx-datagrid-search-panel')).prependTo(<any>($('#inputPesquisaPadrao')));
    // (<any>$('#btnSalve')).prependTo(<any>($('#contentButtonformGenerics')));
    // (<any>$('#btnDelete')).prependTo(<any>($('#contentButtonformGenerics')));
    // (<any>$('#btnCancel')).prependTo(<any>($('#contentButtonformGenerics')));


  }


}
