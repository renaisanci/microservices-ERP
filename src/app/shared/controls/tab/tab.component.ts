import { Tabs } from './tabs';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'dbcorp-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.css']
})
export class TabComponent implements OnInit {

  @Input()  tabs: Tabs[];

  constructor() { }

  ngOnInit() {
  }

}
