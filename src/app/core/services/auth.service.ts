import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { Register } from 'src/app/shared/models/register';
import { User } from 'src/app/shared/models/User';
import { ApiService } from './api.service';
import { JwtStorageService } from './jwt-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private user!:User;

  // private -: can only be used inside this class to push data
  private currentUserSubject=new BehaviorSubject<User>({} as User);
  //public -: any component can subscribe to this subject and get the data
  public currentUser=this.currentUserSubject.asObservable();
  private isAuthenticatedSubject=new BehaviorSubject<boolean>(false);
  //u can use this subject to check whether user is authenticated so that if true hide login/register buttons in header
  public isAuthenticated=this.isAuthenticatedSubject.asObservable();


  constructor(private apiService:ApiService) { }

  register(userRegister:Register):Observable<boolean>{
    return this.apiService.create('account/register',userRegister)
    .pipe(map(response => {
      if(response){
        console.log("register success");
        return true;
      }
      console.log("register fail");
      return false;
    }));
  }
  
  
  //take un/pw from login component and post it to API service that will post to API
  login(userLogin:Login):Observable<boolean>{
    return this.apiService.create('account/login',userLogin)
    .pipe(map(response => {
      if(response){
        //save it to local storage
        this.populateUserInfo();
        localStorage.setItem('token',response.token);
        return true;
      }
      return false;
    }));
  }

  logout(){
    //remove the token from local stroage and change the subjects to default values
    localStorage.removeItem('token');
    // this.jwtStorageService.destoryToken();
    this.currentUserSubject.next({} as User);
    this.isAuthenticatedSubject.next(false);
  }

  populateUserInfo(){
    //get the token from localstorage and decode it and get the user info such as email, firstname, lastname etc to show in the header
    var token=localStorage.getItem('token');
    if(token){
      //decode the token
      var decodedToken=new JwtHelperService().decodeToken(token)
      this.user=decodedToken;

      //pushing data to the observables
      this.currentUserSubject.next(this.user);
      this.isAuthenticatedSubject.next(true);
    }
  }
}
