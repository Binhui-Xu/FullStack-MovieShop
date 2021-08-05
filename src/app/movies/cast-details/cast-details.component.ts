import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ApiService } from 'src/app/core/services/api.service';
import { CastDetail } from 'src/app/shared/models/castDetail';
import { Cast } from 'src/app/shared/models/Movie';
import { environment } from 'src/environments/environment';
// import * as internal from 'stream';

@Component({
  selector: 'app-cast-details',
  templateUrl: './cast-details.component.html',
  styleUrls: ['./cast-details.component.css']
})
export class CastDetailsComponent implements OnInit {

  cast!:CastDetail;
  id!:number;
  constructor(private http:HttpClient,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(p => {
      this.id = +p.get('id')!;
      console.log(this.id);
      this.getCastById(this.id)
        .subscribe(c => {
          this.cast = c;
          console.log(this.cast);
        })
    });
  }
  getCastById(id:number){
    return this.http.get(`${environment.apiUrl}`+'cast/'+id)
    .pipe(map(resp=>resp as CastDetail));
  }
}
