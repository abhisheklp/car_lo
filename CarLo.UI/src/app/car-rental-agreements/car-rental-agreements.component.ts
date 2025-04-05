import { Component, OnInit } from '@angular/core';
import { CarloService } from '../service/carlo.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-car-rental-agreements',
  templateUrl: './car-rental-agreements.component.html',
  styleUrls: ['./car-rental-agreements.component.css']
})

export class CarRentalAgreementsComponent implements OnInit{

  updateRentUser : FormGroup;

  constructor(private agreementService : CarloService, private formBuilder: FormBuilder) {
    this.updateRentUser = this.formBuilder.group({
      agreementId : [''],
      fullName: ['', [Validators.required, Validators.maxLength(50)]],
      phoneNo: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      address: ['', [Validators.required, Validators.maxLength(255)]],
      noOfDays: ['', [Validators.required, Validators.min(1) ,Validators.max(15)]],
      licenseNo: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      carDetailsEntityId : ['']
    });
  }

  isAdmin : boolean | undefined;

  agreements : any;
  cars : any;
  requestReturns : any;
  agreementofCars : any;

  selectedAgreement: any;
  // returnRequest : any = false;
  // returnApproval : any = false;

  ngOnInit(): void {
    this.agreementService.getAllAgreements().subscribe((agreement) => {
      this.agreements = agreement;

      //all cars
      this.agreementService.getAllCars().subscribe((car) => {
        this.cars = car;

        //all return request
        this.agreementService.getAllReturnRequest().subscribe((returnRequest) => {
          this.requestReturns = returnRequest;

          this.agreementofCars = this.agreements.map((agreementItem: { agreementId: any; carDetailsEntityId: any; }) => {
            const matchingCar = this.cars.find((carItem: { carId: any; }) => carItem.carId === agreementItem.carDetailsEntityId);
  
            // Find the matching return request based on a common column (if applicable)
            const matchingReturnRequest = this.requestReturns.find((returnRequestItem: { rentalAgreementEntityId: any; }) => {
              return returnRequestItem.rentalAgreementEntityId === agreementItem.agreementId; // Replace commonColumn with the actual common column name
            });

            // Combine data from agreements, cars, and return requests
            if (matchingCar && matchingReturnRequest) {
              return { ...agreementItem, ...matchingCar, ...matchingReturnRequest };
            } else if (matchingCar) {
              return { ...agreementItem, ...matchingCar };
            }
          });
        })
      });
    });
    this.isAdmin = this.agreementService.loginResult.userIsAdmin;
  }

  updateAgreement()
  {
    if(this.updateRentUser.valid)
    { 
      this.agreementService.updateAgreement(this.updateRentUser.value).subscribe( (result) =>{
        if(result)
        {
          setTimeout(() => {
            window.alert('Changes done successfully');
            location.reload();
          }, 20);
        }
      })
    }
  }

  setSelectedAgreement(agreement : any)
  {
    this.selectedAgreement = agreement;
    this.updateRentUser.patchValue({
      agreementId : this.selectedAgreement.agreementId,
      fullName: this.selectedAgreement.fullName,
      phoneNo: this.selectedAgreement.phoneNo,
      address: this.selectedAgreement.address,
      noOfDays: this.selectedAgreement.noOfDays,
      licenseNo: this.selectedAgreement.licenseNo,
      carDetailsEntityId : this.selectedAgreement.carDetailsEntityId
    });
  }

  requestForReturn(AgreementEntityId : number)
  {
    const requestReturnData = {
      rentalAgreementEntityId : AgreementEntityId,
      returnRequestGenerate : true
    }
    
    const confirmed = window.confirm('You are returning car earlier. Click OK to proceed');
    if(confirmed)
    {
      
    this.agreementService.addReturnRequest(requestReturnData).subscribe((result)=>{
      location.reload();
    });
    }
  }

  acceptAgreement(id : number){
    const confirmed = window.confirm('You cannot delete or update your agreement after accepting. Click OK to proceed');
    if(confirmed)
    {
      this.agreementService.acceptAgreement(id).subscribe((result)=>{
        location.reload();
      })
    }
  }

  deleteAgreement(agreementId : number, carId: number)
  {
    const confirmed = window.confirm('You are deleting agreement. Click OK to proceed');
    if(confirmed)
    {
      this.agreementService.deleteAgreement(agreementId).subscribe((result)=>{
        this.agreementService.updateQuantity(carId, -1).subscribe();
        location.reload();
      })
    }
  }

}
