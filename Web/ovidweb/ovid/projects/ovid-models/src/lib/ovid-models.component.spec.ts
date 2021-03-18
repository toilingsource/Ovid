import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OvidModelsComponent } from './ovid-models.component';

describe('OvidModelsComponent', () => {
  let component: OvidModelsComponent;
  let fixture: ComponentFixture<OvidModelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OvidModelsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OvidModelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
