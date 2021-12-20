import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscriber } from 'rxjs';
import { BeLogged, LogInService } from 'src/app/Services/log-in.service';


@Component({
  selector: 'app-connection',
  templateUrl: './connection.component.html',
  styleUrls: ['./connection.component.scss']
})
export class ConnectionComponent implements OnInit {

  beLogged? : BeLogged

  constructor(private connectionData : LogInService, private router:Router) { }

  ngOnInit(): void {
    
  }

  getConnectionFormData(data : any){

    //this.beLogged = JSON.parse(localStorage.getItem("beLogged") || 'null');
    //this.connectionData.isBeLoggedSubject.subscribe((value : BeLogged) => {this.beLogged = value}) 
      console.log(this.beLogged)
      console.log(this.beLogged?.logOk)
      this.connectionData.logIn(data).subscribe((result) => {
      this.beLogged = result;
      localStorage.setItem('beLogged', JSON.stringify(this.beLogged))
      console.log(localStorage.getItem('beLogged'));
      if(this.beLogged.logOk) {this.connectionData.connected()};
      (!this.beLogged.logOk)? this.router.navigate(["/connection"]):(this.beLogged.authorisationID === 2)? this.router.navigate(["/home-admin"]) :this.router.navigate(["/home-user"]);
    })
  }
}
