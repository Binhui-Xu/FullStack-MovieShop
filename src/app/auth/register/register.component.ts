import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { Register } from 'src/app/shared/models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  invalidRegister: boolean | undefined;
  returnUrl?: string;
  userRegister:Register={
    email: '',
    password:'',
    firstName:'',
    lastName:'',
    dateOfBirth:''
  };

  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => this.returnUrl = params.returnUrl || '/login');
  }

  register(){
    console.log('button was click');
    //call login method in auth service
    this.authService.register(this.userRegister)
      .subscribe((response) => {
        if (response) {
          //if auth service returns true, redirect to home page
          this.router.navigate([this.returnUrl]);

        } else {
          //stay on the same page and show error message saying un/pw is invalid
          this.invalidRegister = true;
        }
      }, 
      (err: any) => { 
      this.invalidRegister = true, console.log(err); 
      }
    );
  }
}
