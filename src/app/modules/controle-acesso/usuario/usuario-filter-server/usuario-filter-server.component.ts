import { TabComponent } from './../../../../shared/controls/tab/tab.component';
import { Tabs } from './../../../../shared/controls/tab/tabs';
import { Component, OnInit } from '@angular/core';
import { TelaFilter1Component } from './tela-filter1/tela-filter1.component';
import { TelaFilter2Component } from './tela-filter2/tela-filter2.component';

@Component({
  selector: 'app-usuario-filter-server',
  templateUrl: './usuario-filter-server.component.html',
  styleUrls: ['./usuario-filter-server.component.css']
})
export class UsuarioFilterServerComponent implements OnInit {
dynamicTabs: Array<Tabs> = [];
  constructor() { }

  ngOnInit() {
    this.dynamicTabs.push({label: 'Tela FIlter 1', component: TelaFilter1Component});
    this.dynamicTabs.push({label: 'Tela FIlter 2', component: TelaFilter2Component});
  }

  addComponentTab(tab: Tabs ) {
    this.dynamicTabs.push(tab);
  }
}
