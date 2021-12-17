import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { observable } from 'rxjs';
import { BeLogged, LogInService } from 'src/app/Services/log-in.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  beLogged? : BeLogged
  isConnected! : boolean
  authorisation! : number

  constructor(private connectionData : LogInService) { }

  ngOnInit(): void {
    console.log('ok')
    
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") || 'null');
    console.log(this.beLogged)
    
    this.connectionData.isConnectedSubject.subscribe((value : boolean) => {this.isConnected = value} )  
    this.connectionData.isBeLoggedSubject.subscribe((value : BeLogged) => {this.beLogged = value}) 
  }

  LogOut(){
    localStorage.removeItem('beLogged');
    this.connectionData.disconnected();
    location.reload();
    console.log('ok')
  }

}

export class Link {
  title! : string
  url? : string
  isVisible? : boolean 
}
