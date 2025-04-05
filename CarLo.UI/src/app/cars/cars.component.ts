import { Component, OnInit } from '@angular/core';
import { CarloService } from '../service/carlo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  constructor(private service : CarloService, private router : Router) {}

  isAdmin : boolean | undefined;
  alert : boolean | undefined;
  selectedCategoryName : any | undefined;
  searchQuery: string = "";

  // arrays
  categories : any[] | undefined;
  cars : any[] = [];

  // for sorting
  sortBy: string = 'name';
  sortDirection: string = 'asc';

  ngOnInit(): void {
    this.service.getAllCategories().subscribe( (result) =>
    {
      this.categories = result;
    });

    this.service.getAllCars().subscribe( (result) =>
    {
      this.cars = result;
    });

    this.isAdmin = this.service.loginResult.userIsAdmin;
  }

  deleteCar(id : number)
  {
    this.service.deleteCarById(id).subscribe( (result) =>{
      setTimeout(() => {
        location.reload();
        this.alert = true;
      }, 20);
    });
  }

  onCategoryClick(category: any) 
  {
    if (category.carCategoryId) {
      this.service.getCarsByCategoryId(category.carCategoryId).subscribe((result)=>{
        this.cars = result;
        this.selectedCategoryName = category.carCategoryName;
      });
    }
    else
    {
      setTimeout(() => {
        location.reload();
      }, 20);
    }
  }

  onSearch()
  {
    if(this.searchQuery) {
      this.service.searchCar(this.searchQuery).subscribe((result)=>{
        this.cars = result;
      })
    }
    else
    {
      setTimeout(() => {
        location.reload();
      }, 20);
    }
  }

  clearSearchQuery()
  {
    this.searchQuery = '';
  }

  closeAlert()
  {
    this.alert = false;
  }

  // Sorting of products
  sortByMakerName()
  {
    this.sortBy = 'carBrandName';
    this.sortDirection = 'asc';
    this.performSorting();
  }

  sortByPrice()
  {
    this.sortBy = 'rentalPrice';
    this.sortDirection = 'asc';
    this.performSorting();
  }

  sortByModelName()
  {
    this.sortBy = 'carModelName';
    this.sortDirection = 'asc';
    this.performSorting();
  }

  performSorting() {
    this.cars.sort((a, b) => {
      if (this.sortDirection === 'asc') {
        if (a[this.sortBy] > b[this.sortBy]) {
          return 1;
        } else if (a[this.sortBy] < b[this.sortBy]) {
          return -1;
        } else {
          return 0;
        }
      } else {
        if (b[this.sortBy] > a[this.sortBy]) {
          return 1;
        } else if (b[this.sortBy] < a[this.sortBy]) {
          return -1;
        } else {
          return 0;
        }
      }
    });
  }

}
