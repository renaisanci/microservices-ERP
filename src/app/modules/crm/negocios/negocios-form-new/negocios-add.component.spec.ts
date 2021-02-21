import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NegociosAddComponent } from './negocios-add.component';

describe('NegociosAddComponent', () => {
  let component: NegociosAddComponent;
  let fixture: ComponentFixture<NegociosAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NegociosAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NegociosAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
