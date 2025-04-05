import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CarloService } from '../service/carlo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {
  
  newCar : FormGroup;
  categories : any[] | undefined;
  // alert : boolean = false;

  constructor(private carService : CarloService, private router : Router, private formBuilder: FormBuilder) {
    this.newCar = this.formBuilder.group({
      carBrandName: ['', [Validators.required, Validators.maxLength(100)]],
      carModelName: ['', [Validators.required, Validators.maxLength(255)]],
      carDescription: ['', [Validators.required, Validators.maxLength(255)]],
      carImageURL: ['', Validators.required],
      carCategoryEntityId: ['', Validators.required],
      carAvailability: ['', Validators.required],
      rentalPrice: ['', Validators.required]
    });
  }
  
  ngOnInit(): void {
    this.carService.getAllCategories().subscribe( (result) =>
    {
      this.categories = result;
    });
  }

  addCarInventery()
  {
    console.warn(this.newCar.value);
    if(this.newCar.valid)
    {
      const formData = new FormData();
      formData.append('carBrandName', this.newCar.value.carBrandName);
      formData.append('carModelName', this.newCar.value.carModelName);
      formData.append('carDescription', this.newCar.value.carDescription);
      formData.append('carImageURL', this.newCar.value.carImageURL);
      formData.append('carCategoryEntityId', this.newCar.value.carCategoryEntityId);
      formData.append('carAvailability', this.newCar.value.carAvailability);
      formData.append('rentalPrice', this.newCar.value.rentalPrice);
    
      this.carService.addCar(formData).subscribe( (result) =>{
        if(result)
        {
          // this.alert = true;
          this.newCar.reset({});
          setTimeout(() => {
            this.router.navigate(["/cars"]);
          }, 3000);
        }
      });
    }
  }

}
