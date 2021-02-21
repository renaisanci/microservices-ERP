import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NegociosListComponent } from './negocios-list.component';

describe('NegociosListComponent', () => {
  let component: NegociosListComponent;
  let fixture: ComponentFixture<NegociosListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NegociosListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NegociosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
