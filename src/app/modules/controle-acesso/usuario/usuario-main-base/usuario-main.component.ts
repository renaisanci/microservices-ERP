import { MatDialog } from '@angular/material';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { UsuarioComponent } from '../usuario-form-new/usuario.component';


@Component({
  selector: 'app-usuario-main',
  templateUrl: './usuario-main.component.html',
  styleUrls: ['./usuario-main.component.css']
})
export class UsuarioMainComponent implements OnInit {


  constructor( public dialog: MatDialog) { }

  ngOnInit() {
  }


}
