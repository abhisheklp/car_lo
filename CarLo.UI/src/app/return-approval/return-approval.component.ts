import { Component, OnInit } from '@angular/core';
import { CarloService } from '../service/carlo.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-return-approval',
  templateUrl: './return-approval.component.html',
  styleUrls: ['./return-approval.component.css']
})
export class ReturnApprovalComponent implements OnInit {

  getRemarks : FormGroup;

  constructor(private agreementService : CarloService, private formBuilder: FormBuilder) {
    this.getRemarks = this.formBuilder.group({
      remarks: ['', [Validators.required, Validators.maxLength(255)]],
    })
  }

  agreements : any;
  requestReturns : any;
  allReturnRequests : any;

  ngOnInit(): void {
    this.agreementService.getAllAgreements().subscribe((agreements) => {
      this.agreements = agreements;
  
      this.agreementService.getAllReturnRequest().subscribe((returnRequests) => {
        this.requestReturns = returnRequests;
  
        const combineData = (agreementItem: { agreementId: any; }) => {
          const matchingReturnRequest = this.requestReturns.find((returnRequestItem: { rentalAgreementEntityId: any; }) => {
            return returnRequestItem.rentalAgreementEntityId === agreementItem.agreementId;
          });
  
          if (matchingReturnRequest && !matchingReturnRequest.returnApproval) {
            return { ...agreementItem, ...matchingReturnRequest };
          }else {
            return;
          }
        };
  
        this.allReturnRequests = this.agreements.map(combineData).filter(Boolean);
      });
    });
  }

  giveRemarks(returnRequestId : any, carDetailsEntityId : any)
  {
    const requestReturnData = {
      returnRequestId : returnRequestId,
      remarks : this.getRemarks.value.remarks
    }
    this.agreementService.updateReturnRequest(requestReturnData).subscribe((result) => {
      this.agreementService.updateQuantity(carDetailsEntityId, -1).subscribe();
      location.reload();
      window.alert('Car has been returned.');
    });
  }

}
