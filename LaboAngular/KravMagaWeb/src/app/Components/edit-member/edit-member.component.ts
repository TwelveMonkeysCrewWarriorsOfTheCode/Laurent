import { Component, OnInit } from '@angular/core';
import { authorisation, AuthorisationService } from 'src/app/Services/authorisation.service';
import { BeLogged } from 'src/app/Services/log-in.service';
import { Member, MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
  styleUrls: ['./edit-member.component.scss']
})
export class EditMemberComponent implements OnInit {

  beLogged! : BeLogged
  member? : Member
  id! : number;

  constructor(private memberService : MemberService) { }

  ngOnInit(): void {
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") ?? 'null');
    this.id = this.beLogged.id;
    this.memberService.memberEdit(this.id).subscribe((resultat) => {this.member = resultat})
    
  }

}
