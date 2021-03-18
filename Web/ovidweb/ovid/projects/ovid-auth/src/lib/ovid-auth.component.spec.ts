import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OvidAuthComponent } from './ovid-auth.component';

describe('OvidAuthComponent', () => {
  let component: OvidAuthComponent;
  let fixture: ComponentFixture<OvidAuthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OvidAuthComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OvidAuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
