import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FunilMainComponent } from './funil-main.component';

describe('FunilMainComponent', () => {
  let component: FunilMainComponent;
  let fixture: ComponentFixture<FunilMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FunilMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FunilMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
