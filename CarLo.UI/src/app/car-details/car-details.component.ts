import { Component, OnInit } from '@angular/core';
import { CarloService } from '../service/carlo.service';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {

  constructor(private service : CarloService, private router: ActivatedRoute) {}

  isUser : boolean | undefined;
  isAdmin : boolean | undefined;

  rentUser = new FormGroup({
    fullName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    phoneNo: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    address: new FormControl('', [Validators.required, Validators.maxLength(255)]),
    noOfDays: new FormControl('', [Validators.required, Validators.min(1) ,Validators.max(15)]),
    licenseNo: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10)])
  });

  quantity : boolean = true;
  car : any;
  category : any;

  ngOnInit(): void {
    this.service.getCarById(this.router.snapshot.params['id']).subscribe((result)=> {
      this.car = result;
      if(result.carAvailability == 0)
      {
        this.quantity = false;
      }
      this.service.getAllCategories().subscribe((categories) => {
        this.category = categories.find((c: { carCategoryId: any; }) => c.carCategoryId == result.carCategoryEntityId);
      })
    });
    this.isUser = this.service.loginResult.userEmail;
    this.isAdmin = this.service.loginResult.userIsAdmin;
  }

  rentCar()
  {
    const newRentalAgreement = {
      fullName : this.rentUser.value.fullName,
      phoneNo : this.rentUser.value.phoneNo,
      address : this.rentUser.value.address,
      noOfDays : Number(this.rentUser.value.noOfDays),
      licenseNo : this.rentUser.value.licenseNo,
      carDetailsEntityId : Number(this.router.snapshot.params['id'])
    }

    const confirmed = window.confirm('You can find your agreement on Rental Agreement Tab. Click OK to proceed');
    if(confirmed)
    {
      this.service.addAgreement(newRentalAgreement).subscribe((result)=>{
        this.service.updateQuantity(newRentalAgreement.carDetailsEntityId, 1).subscribe();
        location.reload();
      })
    }
  }

}
