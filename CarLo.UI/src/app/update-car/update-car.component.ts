import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CarloService } from '../service/carlo.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.css']
})
export class UpdateCarComponent implements OnInit {

  updateCar : FormGroup;
  categories : any[] | undefined;

  constructor(private carService : CarloService, private router : Router, private route : ActivatedRoute, private formBuilder: FormBuilder) {
    this.updateCar = this.formBuilder.group({
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

    this.carService.getCarById(this.route.snapshot.params['id']).subscribe( (result : any) =>{
      this.updateCar.patchValue({
        carBrandName : result['carBrandName'],
        carModelName : result['carModelName'],
        carDescription : result['carDescription'],
        carImageURL: result['carImageURL'],
        carCategoryEntityId : result['carCategoryEntityId'],
        carAvailability : result['carAvailability'],
        rentalPrice : result['rentalPrice']
      })
    });
  }


  updateCarInventery(){
    if(this.updateCar.valid)
    {
      const formData = new FormData();
      formData.append('carId', this.route.snapshot.params['id']);
      formData.append('carBrandName', this.updateCar.value.carBrandName);
      formData.append('carModelName', this.updateCar.value.carModelName);
      formData.append('carDescription', this.updateCar.value.carDescription);
      formData.append('carImageURL', this.updateCar.value.carImageURL);
      formData.append('carCategoryEntityId', this.updateCar.value.carCategoryEntityId);
      formData.append('carAvailability', this.updateCar.value.carAvailability);
      formData.append('rentalPrice', this.updateCar.value.rentalPrice);

      this.carService.updateCar(formData).subscribe( (result) =>{
        if(result)
        {
          setTimeout(() => {
            this.router.navigate(["/cars"]);
          }, 20);
        }
      })
    }
  }

}
