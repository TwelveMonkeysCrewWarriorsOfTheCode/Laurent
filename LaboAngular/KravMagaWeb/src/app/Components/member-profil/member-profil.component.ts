import { Component, OnInit } from '@angular/core';
import { belt, BeltService } from 'src/app/Services/belt.service';
import { BeLogged } from 'src/app/Services/log-in.service';
import { Member, MemberService } from 'src/app/Services/member.service';
import { role, RoleService } from 'src/app/Services/role.service';

@Component({
  selector: 'app-member-profil',
  templateUrl: './member-profil.component.html',
  styleUrls: ['./member-profil.component.scss']
})
export class MemberProfilComponent implements OnInit {
  
  beLogged! : BeLogged
  member? : Member
  id! : number;
  beltList! : belt[]
  roleList! : role[]

  constructor(private memberService : MemberService, private beltService : BeltService, private roleService : RoleService) { }

  ngOnInit(): void {
    this.beLogged = JSON.parse(localStorage.getItem("beLogged") ?? 'null');
    this.id = this.beLogged.id;
    this.memberService.memberProfil(this.id).subscribe(mp => {
      console.log(mp);
      this.member = mp;
      console.log(this.member)
   });

    this.beltService.beltList().subscribe((result) => {
    this.beltList = result;
    console.log(this.beltList)  
    this.beltList.forEach(beltItem => {
      if(beltItem.id == this.member?.id)
      {
        this.member.beltColor = beltItem.beltColor;
      }
    });

    });

    this.roleService.roleList().subscribe((result) => {
      this.roleList = result;
      console.log(this.roleList)
      this.roleList.forEach(roleItem => {
        if(roleItem.id == this.member?.id)
        {
          this.member.roleDescription = roleItem.roleName;
        }
      })

    })

  }
}
