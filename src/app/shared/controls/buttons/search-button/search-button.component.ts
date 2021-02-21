import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-search-button',
  templateUrl: './search-button.component.html',
  styleUrls: ['./search-button.component.css']
})
export class SearchButtonComponent implements OnInit {
  @Input() disable = false;
  @Input() loading = false;
  constructor() { }

  ngOnInit() {
  }

}
