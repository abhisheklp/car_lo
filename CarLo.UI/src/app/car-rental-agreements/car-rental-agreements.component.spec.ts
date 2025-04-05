import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAgreementsComponent } from './car-rental-agreements.component';

describe('CarRentalAgreementsComponent', () => {
  let component: CarRentalAgreementsComponent;
  let fixture: ComponentFixture<CarRentalAgreementsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarRentalAgreementsComponent]
    });
    fixture = TestBed.createComponent(CarRentalAgreementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
