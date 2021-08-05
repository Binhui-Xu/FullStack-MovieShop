import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private headers:HttpHeaders | undefined;

  constructor(protected http:HttpClient) { }

  //get item by id
  getItem(path:string,resource: string | number,option?: undefined):Observable<any>{
    return this.http.get(`${environment.apiUrl}${path}`+resource)
    .pipe(map(resp=>{resp as any}))
  }
  //getting array of json objects
  getList(path:string):Observable<any[]>{
    return this.http.get(`${environment.apiUrl}${path}`)
    .pipe(map(resp=>resp as any[]))
  }
  //post something
  create(path:string,resource: Login,options?: undefined):Observable<any>{
    return this.http
    .post(`${environment.apiUrl}${path}`,resource,{headers:this.headers})
    .pipe(map(resp=>resp));
  }
}
