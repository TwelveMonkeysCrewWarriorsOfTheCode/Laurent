import { Component, OnInit } from '@angular/core';
import { BeLogged } from 'src/app/Services/log-in.service';

@Component({
  selector: 'app-home-user',
  templateUrl: './home-user.component.html',
  styleUrls: ['./home-user.component.scss']
})
export class HomeUserComponent implements OnInit {

  beLogged? : BeLogged
  
  constructor() {
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") || '');
   }

  ngOnInit(): void {
  }

}
