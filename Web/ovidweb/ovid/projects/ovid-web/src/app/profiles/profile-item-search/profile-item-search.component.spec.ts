import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileItemSearchComponent } from './profile-item-search.component';

describe('ProfileItemSearchComponent', () => {
  let component: ProfileItemSearchComponent;
  let fixture: ComponentFixture<ProfileItemSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileItemSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileItemSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
