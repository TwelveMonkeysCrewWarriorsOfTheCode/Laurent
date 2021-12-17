import { Component, OnInit } from '@angular/core';
import { BeLogged } from 'src/app/Services/log-in.service';
import { Member, MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-member-profil',
  templateUrl: './member-profil.component.html',
  styleUrls: ['./member-profil.component.scss']
})
export class MemberProfilComponent implements OnInit {
  
  beLogged! : BeLogged
  member? : Member
  id! : number;

  constructor(private memberService : MemberService) { }

  ngOnInit(): void {
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") ?? 'null');
    this.id = this.beLogged.id;
    this.memberService.memberProfil(this.id).subscribe(mp => {
      console.log(mp);
      this.member = mp;
      console.log(this.member)
   });
  }

}
