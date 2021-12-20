import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BeltService {

  private apiURL : string ='https://localhost:7256/api/belts'

  constructor(private http : HttpClient) { }

  beltList(): Observable<belt[]>{
    return this.http.get<belt[]>(this.apiURL)
  }
}

export interface belt {
  id : number
  beltColor : string
}