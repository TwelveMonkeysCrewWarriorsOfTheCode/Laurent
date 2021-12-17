import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders( {'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  private apiURL : string ='https://localhost:7256/api/LogIn'

  isConnected : boolean = false
  isBeLogged : BeLogged = JSON.parse(localStorage.getItem("beLogged") ?? 'null')
  isConnectedSubject : BehaviorSubject<boolean> = new BehaviorSubject<boolean>(JSON.parse(localStorage.getItem("isConnected") ?? 'false'))
  isBeLoggedSubject : BehaviorSubject<BeLogged> = new BehaviorSubject<BeLogged>(JSON.parse(localStorage.getItem("isBeLogged") ?? 'null'))

  emitSubject() {
    this.isConnectedSubject.next(this.isConnected)
    this.isBeLoggedSubject.next(this.isBeLogged)
  }

  constructor(private http : HttpClient) { }

  logIn(data : any): Observable<BeLogged> {
    return this.http.post<BeLogged>(this.apiURL, data)
  }

  connected() {
    this.isConnected = true;
    localStorage.setItem("isConnected", JSON.stringify(true));
    this.isBeLogged = JSON.parse(localStorage.getItem("beLogged") ?? 'null')
    console.log(this.isBeLogged)
    localStorage.setItem("isBeLogged", JSON.stringify(this.isBeLogged))
    this.emitSubject()
  }

  disconnected() {
    this.isConnected = false
    localStorage.removeItem("isConnected")
    localStorage.removeItem("isBeLogged")
    this.emitSubject()
  }
}

export interface LogIn {
  email : string
  password : string 
}

export interface BeLogged {
  id : number
  email : string
  lastName : string
  firstName : string
  authorisationID : number
  logOk : boolean
}