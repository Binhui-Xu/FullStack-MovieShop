import { Component, OnInit } from '@angular/core';
import { Genre } from 'src/app/shared/models/Movie';
import { User } from 'src/app/shared/models/User';
import { AuthService } from '../../services/auth.service';
import { GenreService } from '../../services/genre.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  genres!:Genre[];
  constructor(private genreService:GenreService, private authService:AuthService) { }

  isAuth!:boolean;
  user!:User;
  ngOnInit(): void {
    this.genreService.getGenreList()
     .subscribe(g=>{
       this.genres=g;
      //  console.table(this.genres);
     })
    this.authService.isAuthenticated.subscribe(
      data=>{
        this.isAuth=data;
        console.log(this.isAuth);
      });
    this.authService.currentUser.subscribe(
      data=>{
      this.user=data;
      console.log(this.user);
    });
  }
}
