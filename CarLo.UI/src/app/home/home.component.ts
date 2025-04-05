import { Component, OnInit } from '@angular/core';
import { CarloService } from '../service/carlo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service : CarloService) {}

  userName : string | undefined;

  ngOnInit(): void {
    this.userName = this.service.loginResult.userName;
  }
}
