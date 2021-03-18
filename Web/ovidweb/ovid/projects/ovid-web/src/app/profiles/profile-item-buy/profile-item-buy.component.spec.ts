import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileItemBuyComponent } from './profile-item-buy.component';

describe('ProfileItemBuyComponent', () => {
  let component: ProfileItemBuyComponent;
  let fixture: ComponentFixture<ProfileItemBuyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileItemBuyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileItemBuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
