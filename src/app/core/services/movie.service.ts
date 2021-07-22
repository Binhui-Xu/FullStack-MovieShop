import { Injectable } from '@angular/core';
import { Moviecard } from 'src/app/shared/models/moviecard';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Movie } from 'src/app/shared/models/Movie';
@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http:HttpClient) { }

   getTopRevenueMovies():Observable<Moviecard[]> {
    //make an Ajax HTTP call to API https://localhost:37783/api/Movies/toprevenue
    //return a Json array with four properties
    return this.http.get( `${environment.apiUrl}`+'Movies/toprevenue')
    .pipe(map(resp=>resp as Moviecard[]));
  }

  getMovieDetails(id:number) :Observable<Movie>
  {
    return this.http.get(`${environment.apiUrl}`+'movies/'+id)
    .pipe(map(resp=>resp as Movie));

  }
}
