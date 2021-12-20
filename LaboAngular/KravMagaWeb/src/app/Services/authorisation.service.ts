import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorisationService {

  private apiURL : string ='https://localhost:7256/api/authorisations'

  constructor(private http : HttpClient) { }

  authoristionList(): Observable<authorisation[]> {
    return this.http.get<authorisation[]>(this.apiURL)
  }
}

export interface authorisation {
  id : number
  authorisationType : string
}