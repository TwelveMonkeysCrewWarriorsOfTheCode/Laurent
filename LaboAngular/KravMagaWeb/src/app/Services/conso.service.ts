import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders( {'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class ConsoService {

  private baseUrl : string ="https://localhost:7256"

  constructor(
    private _client : HttpClient
  ) { }

  logIn(email : string, password : string ) {
    this._client.post(this.baseUrl,{ email: email, password : password}).subscribe()
  }

}

export interface infoLog {
  id : number
  lastName : string
  firstName : string
  email : string
  AuthorisationId : number
}

export interface logIn {
  email : string
  password : string
}

export class LogIn {
  
}