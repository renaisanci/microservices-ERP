import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-cancel-button',
  templateUrl: './cancel-button.component.html',
  styleUrls: ['./cancel-button.component.css']
})
export class CancelButtonComponent implements OnInit {
  @Input() disable = false;
  @Input() loading = false;

  constructor() { }

  ngOnInit() {
  }

}
