import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { MainComponent } from './Components/main/main.component';
import { InscriptionComponent } from './Components/inscription/inscription.component';
import { ConnectionComponent } from './Components/connection/connection.component';
import { MembersListComponent } from './Components/members-list/members-list.component';
import { HomeAdminComponent } from './Components/home-admin/home-admin.component';
import { HomeUserComponent } from './Components/home-user/home-user.component';
import { MemberProfilComponent } from './Components/member-profil/member-profil.component';
import { HistoryComponent } from './Components/history/history.component';
import { FooterComponent } from './Components/footer/footer.component';
import { EditMemberComponent } from './Components/edit-member/edit-member.component';
import { InstructorComponent } from './Components/instructor/instructor.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    InscriptionComponent,
    ConnectionComponent,
    MembersListComponent,
    HomeAdminComponent,
    HomeUserComponent,
    MemberProfilComponent,
    HistoryComponent,
    FooterComponent,
    EditMemberComponent,
    InstructorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
