import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Genre } from 'src/app/shared/models/Movie';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private http:HttpClient) { }

  getGenreList():Observable<Genre[]>{
    return this.http.get(`${environment.apiUrl}`+'Genre')
    .pipe(map(resp=>resp as Genre[]))
  }
}
