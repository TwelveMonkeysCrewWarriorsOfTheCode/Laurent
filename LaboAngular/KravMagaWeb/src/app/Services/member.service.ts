import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { BeLogged } from './log-in.service';

const httpOptions = {
  headers: new HttpHeaders( {'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  private apiURL : string ='https://localhost:7256/api/members'

  constructor(private http : HttpClient) { }

  addMember(data : any) {
    return this.http.put<BeLogged>(this.apiURL, data);
  }

  membersList(): Observable<Member[]> {
    return this.http.get<Member[]>(this.apiURL);
  }

  memberProfil(id : number): Observable<Member> {
    return this.http.get<Member>(this.apiURL+"/id?id="+id);
  }

  memberEdit(id : number) {
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
  authoristionID : number
  roleID : number
  beltID : number
  authorisationName : string
  roleDescription : string
  beltColor : string
}