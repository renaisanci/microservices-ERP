import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaFilter1Component } from './tela-filter1.component';

describe('TelaFilter1Component', () => {
  let component: TelaFilter1Component;
  let fixture: ComponentFixture<TelaFilter1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TelaFilter1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TelaFilter1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
