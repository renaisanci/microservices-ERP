import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-save-button',
  templateUrl: './save-button.component.html',
  styleUrls: ['./save-button.component.css']
})
export class SaveButtonComponent implements OnInit {
  @Input() disable = false;
  @Input() loading = false;


  constructor() { }

  ngOnInit() {
  }

}
