import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dbcorp-funil-filter-server',
  templateUrl: './funil-filter-server.component.html',
  styleUrls: ['./funil-filter-server.component.css']
})
export class FunilFilterServerComponent implements OnInit {
  loading = false;
  submitted = false;
  constructor() { }

  ngOnInit() {
  }

  pesquisar() {
    this.loading = true;

   }

}
