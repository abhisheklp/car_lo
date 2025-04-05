import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarloService {

  constructor(private http : HttpClient) { }
  url = "https://localhost:44381";

  // To store the userName, userEmail, isAdmin details
  public loginResult : any;

  // Logout Functionality
  public showLogoutButton: boolean = false;

  // Account service to handle the Login and SignUp API
  signUp(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/authenticate/signup`, data);
  }

  login(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/authenticate/login`, data)
    .pipe(
      tap( response => {
        this.loginResult = response;
      })
    )
  }
  
  logout() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/authenticate/logout`);
  }

  // Category service to get the all category and add the category
  getAllCategories() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/category`);
  }

  addCategory(data : any) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/category`, data);
  }

  // car service to fullfill all the crud functionalities
  addCar(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/car`, data);
  }

  updateQuantity(id : number, decQuantity : number) : Observable<any>
  {
    return this.http.patch<any>(`${this.url}/car/${id}/${decQuantity}`, {});
  }

  updateCar(data : any) : Observable<any>
  {
    return this.http.put<any>(`${this.url}/car/`, data);
  }

  getCarById(id : number) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/car/${id}`);
  }

  getAllCars() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/car`);
  }

  getCarsByCategoryId(categoryId : number) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/car/category/${categoryId}`);
  }

  searchCar(query : string) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/car/search/?query=${query}`);
  }

  deleteCarById(id : number) : Observable<any>
  {
    return this.http.delete<any>(`${this.url}/car/${id}`);
  }

  //agreement service to fullfill all the crud functionalities
  getAllAgreements() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/agreement`);
  }

  addAgreement (data : any) : Observable<any>
  {
    console.log(data)
    return this.http.post<any>(`${this.url}/agreement`, data);
  }

  acceptAgreement(id : number) : Observable<any>
  {
    return this.http.patch<any>(`${this.url}/agreement/${id}`, {});
  }

  updateAgreement(data : any) : Observable<any>
  {
    return this.http.put<any>(`${this.url}/agreement/`, data);
  }

  deleteAgreement(id : number) : Observable<any>
  {
    return this.http.delete<any>(`${this.url}/agreement/${id}`);
  }

  //return request service to fullfill all the crud functionalities
  getAllReturnRequest() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/return`);
  }

  addReturnRequest (data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/return`, data);
  }

  updateReturnRequest(data : any) : Observable<any>
  {
    return this.http.put<any>(`${this.url}/return/`, data);
  }
}
