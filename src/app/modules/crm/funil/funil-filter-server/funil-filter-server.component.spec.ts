import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FunilFilterServerComponent } from './funil-filter-server.component';

describe('FunilFilterServerComponent', () => {
  let component: FunilFilterServerComponent;
  let fixture: ComponentFixture<FunilFilterServerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FunilFilterServerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FunilFilterServerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
