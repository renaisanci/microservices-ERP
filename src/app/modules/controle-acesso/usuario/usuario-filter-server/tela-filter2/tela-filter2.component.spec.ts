import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaFilter2Component } from './tela-filter2.component';

describe('TelaFilter2Component', () => {
  let component: TelaFilter2Component;
  let fixture: ComponentFixture<TelaFilter2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TelaFilter2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TelaFilter2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
