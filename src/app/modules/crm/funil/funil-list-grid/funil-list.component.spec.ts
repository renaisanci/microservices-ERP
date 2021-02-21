import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FunilListGridComponent } from '../funil-list.component';

describe('FunilListGridComponent', () => {
  let component: FunilListGridComponent;
  let fixture: ComponentFixture<FunilListGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FunilListGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FunilListGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
