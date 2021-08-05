import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //two way binding angularJS
  //one way binding
  //object here and use it in form, if you change object in view, 
  //the value will automatically changed here, similarlly, if make change
  //here, it will changed in view automatically.
  invalidLogin: boolean | undefined;
  returnUrl?: string;
  user?: User;
  userLogin: Login = {
    email: '',
    password: ''
  };
  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => this.returnUrl = params.returnUrl || '/');
  }
  login() {
    console.log('button was click');
    //call login method in auth service
    this.authService.login(this.userLogin)
      .subscribe((response) => {
        if (response) {
          //if auth service returns true, redirect to home page
          this.router.navigate([this.returnUrl]);

        } else {
          //stay on the same page and show error message saying un/pw is invalid
          this.invalidLogin = true;
        }
      }, 
      (err: any) => { 
        this.invalidLogin = true, console.log(err); 
      }
    );
  }
  //simply observing two way binding, just for testing
  get twoWayBindingInfo() { return JSON.stringify(this.userLogin) }
}


//login will send un/pw to authentication service, send it to API
//send back the token and Angular will save the token in localstorage
