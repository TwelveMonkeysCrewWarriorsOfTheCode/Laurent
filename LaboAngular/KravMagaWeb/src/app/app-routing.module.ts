import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConnectionComponent } from './Components/connection/connection.component';
import { InscriptionComponent } from './Components/inscription/inscription.component';  
import { MembersListComponent } from './Components/members-list/members-list.component';
import { HomeAdminComponent } from './Components/home-admin/home-admin.component';
import { HomeUserComponent } from './Components/home-user/home-user.component';
import { HeaderComponent } from './Components/header/header.component';
import { MemberProfilComponent } from './Components/member-profil/member-profil.component';
import { HistoryComponent } from './Components/history/history.component';

const routes: Routes = [
  {path : "inscription", component : InscriptionComponent},
  {path : "connection", component : ConnectionComponent},
  {path : "header", component : HeaderComponent},
  {path : "members-list", component : MembersListComponent},
  {path : "home-admin", component : HomeAdminComponent},
  {path : "home-user", component : HomeUserComponent},
  {path : "member-profil", component : MemberProfilComponent},
  {path : "history", component : HistoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
