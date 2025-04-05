import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnApprovalComponent } from './return-approval.component';

describe('ReturnApprovalComponent', () => {
  let component: ReturnApprovalComponent;
  let fixture: ComponentFixture<ReturnApprovalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReturnApprovalComponent]
    });
    fixture = TestBed.createComponent(ReturnApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
