import { Component, OnInit } from '@angular/core';
import { Member, MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.scss']
})
export class MembersListComponent implements OnInit {

  memberList? : Member[];

  constructor(private memberService : MemberService) { }

  ngOnInit(): void {
      this.memberService.membersList().subscribe(members => {
      console.log(members);
      this.memberList = members;
      console.log(this.memberList)
      this.memberList.forEach(element => {
        console.log(typeof element.birthDay)
        console.log(typeof element.id)  
      });
    });
  }

}
