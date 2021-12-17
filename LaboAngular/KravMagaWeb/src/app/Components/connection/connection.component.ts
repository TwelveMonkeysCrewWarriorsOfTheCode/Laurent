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
      this.connectionData.logIn(data).subscribe((result) => {
      this.beLogged = result;
      localStorage.setItem('beLogged', JSON.stringify(this.beLogged))
      console.log(localStorage.getItem('beLogged'));
      if(this.beLogged.logOk) {this.connectionData.connected()} 
      (!this.beLogged.logOk)? location.reload():(this.beLogged.authorisationID === 2)? this.router.navigate(["/home-admin"]) :this.router.navigate(["/home-user"]);
    })
  }
}
