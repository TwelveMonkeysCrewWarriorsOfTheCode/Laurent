import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BeLogged, LogInService } from 'src/app/Services/log-in.service';
import { MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-inscription',
  templateUrl: './inscription.component.html',
  styleUrls: ['./inscription.component.scss']
})
export class InscriptionComponent implements OnInit {

  beLogged! : BeLogged
  
  registerForm! : FormGroup
  submitted : boolean = false;

  constructor(private inscriptionData : MemberService, private router : Router, private connection : LogInService, private formBuilder : FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email : ['', [Validators.required, Validators.email]],
      password : ['',[Validators.required,Validators.pattern('^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\\D*\\d)[A-Za-z\\d!$%@#£€*?&]{8,}$')]],
      confirm_password : ['',[Validators.required]],
      lastName : ['',[Validators.required,Validators.minLength(2)]],
      firstName : ['',[Validators.required,Validators.minLength(2)]],
      birthday : ['',Validators.required,Validators],
      adress : ['',[Validators.required,Validators.minLength(10)]],
      phone : ['',Validators.required],
    },
    {
      validator : this.PasswordMatch('password', 'confirm_password')
    });
  }

  getInscriptionFormData(data : any){
    this.submitted = true;
    if(!this.registerForm.invalid)
    {
      this.inscriptionData.addMember(data).subscribe((result) => {
        this.beLogged = result
        console.log(result);
        console.log(this.beLogged);
        localStorage.setItem('beLogged', JSON.stringify(this.beLogged));
        if(this.beLogged.logOk) {this.connection.connected()};
        (!this.beLogged.logOk)? location.reload():(this.beLogged.authorisationID === 2)? this.router.navigate(["/home-admin"]) :this.router.navigate(["/home-user"]);
      });
      console.log("valide")
      return;
    }
    else
    {
      console.log("invalide")
    }

  }
  get f() { return this.registerForm.controls; }

  PasswordMatch(password : string, confirm_password : string){
    return(formGroup : FormGroup) => {
      const pass = formGroup.controls[password];
      const confirm_pass = formGroup.controls[confirm_password];
      
      if(confirm_pass.errors && !confirm_pass.errors.passwordMatch) {return} 

      (pass.value !== confirm_pass.value)?confirm_pass.setErrors({passwordMatch:true}) : confirm_pass.setErrors(null);
    }

  }

}
