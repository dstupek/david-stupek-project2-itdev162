import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  carParts: any;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get('http://localhost:5198/api/CarPart').subscribe(
      response => { this.carParts = response; },
      error => { console.log(error) }
    );
  }

  deleteCarPart(id: string){
  this.http.delete(`http://localhost:5198/api/CarPart/${id}`).subscribe(
      response => { this.home(); },
      error => { console.log(error) }
    )
  }

  home() {
    this.router.navigate(["/"]);
  }

}

