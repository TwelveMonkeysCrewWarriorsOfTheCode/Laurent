import { Component } from '@angular/core';
import { Link } from './Components/header/header.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'KravMagaWeb';

  menuList : Link[] = [
    {title : "Inscription", url : "inscription"},
    {title : "Profil", url : 'profil'},
    {title : "Evenements", url : 'events'},
    {title : "Stage", url : 'stage'}
  ]
}
