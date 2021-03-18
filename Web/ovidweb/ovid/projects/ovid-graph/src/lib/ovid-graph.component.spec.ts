import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OvidGraphComponent } from './ovid-graph.component';

describe('OvidGraphComponent', () => {
  let component: OvidGraphComponent;
  let fixture: ComponentFixture<OvidGraphComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OvidGraphComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OvidGraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
