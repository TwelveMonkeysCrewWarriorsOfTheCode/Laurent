import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders( {'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  private apiURL : string ='https://localhost:7256/api/members'

  constructor(private http : HttpClient) { }

  membersList(): Observable<Member[]> {
    return this.http.get<Member[]>(this.apiURL);
  }

  memberProfil(id : number): Observable<Member> {
    return this.http.get<Member>(this.apiURL+"/id?id="+id);
  }
}

export interface Member {
  id : number
  email : string
  lastName : string
  firstName : string
  birthDay : Date
  birthDayShort : string
  adress : string
  phone : string
}