import { Component, Input, OnInit } from '@angular/core';
import { BeLogged } from 'src/app/Services/log-in.service';

@Component({
  selector: 'app-home-admin',
  templateUrl: './home-admin.component.html',
  styleUrls: ['./home-admin.component.scss']
})
export class HomeAdminComponent implements OnInit {

  beLogged? : BeLogged

  constructor() { }

  ngOnInit(): void {
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") || '');
    console.log(this.beLogged)
    console.log(this.beLogged?.firstName)
  }

}
