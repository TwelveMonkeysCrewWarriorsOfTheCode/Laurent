import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() menuList! : Link []

  constructor() { }

  ngOnInit(): void {
  }

}

export class Link {
  title! : string
  url? : string
  isChildrenVisible? : boolean
}
