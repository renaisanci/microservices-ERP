import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-delete-button',
  templateUrl: './delete-button.component.html',
  styleUrls: ['./delete-button.component.css']
})
export class DeleteButtonComponent implements OnInit {
  @Input() disable = false;
  @Input() loading = false;

  constructor() { }

  ngOnInit() {
  }

}
