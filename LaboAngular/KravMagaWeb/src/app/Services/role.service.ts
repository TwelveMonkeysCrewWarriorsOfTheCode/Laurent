import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private apiURL : string ='https://localhost:7256/api/roles'

  constructor(private http : HttpClient) { }

  roleList(): Observable<role[]> {
    return this.http.get<role[]>(this.apiURL)
  }
}

export interface role {
  id : number
  roleName : string
}
