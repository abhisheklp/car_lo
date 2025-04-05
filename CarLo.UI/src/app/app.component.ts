import { Component, OnInit } from '@angular/core';
import { CarloService } from './service/carlo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private service : CarloService) {}
  title = 'CarLo.com';

  ngOnInit(): void {
    const userDetails = localStorage.getItem('userDetails');
    if(userDetails)
    {
      this.service.loginResult=JSON.parse(userDetails);
    }
  }
  

}