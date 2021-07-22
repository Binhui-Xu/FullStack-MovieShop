import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { Moviecard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movies!: Moviecard[];
  constructor(private movieService:MovieService) { }

  ngOnInit(): void {
     //is a good place for a component to fetch its initail data 
     console.log('insaide home component');
     this.movieService.getTopRevenueMovies()
     .subscribe(m=>{
       this.movies=m;
       console.table(this.movies);
     })
  }
}
