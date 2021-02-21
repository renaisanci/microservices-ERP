import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {
  @Input() caption: string;
  @Input() icon: string;
  @Input() tipoBtn: string;
  @Input() disable = false;
  @Input() loading = false;
  @Input() colorButton = 'primary';
  @Input() typeButton = 'submit';

  constructor() { }

  ngOnInit() {
  }

}
