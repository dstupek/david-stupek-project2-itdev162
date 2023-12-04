import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
//import { error } from 'console';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Car Part Store';
  CarParts: any;

  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
      //Load carparts to front end, throw error if unable
      this.http.get('http://localhost:5198/api/CarPart').subscribe(
        response => { this.CarParts = response; },
        error => { console.log(error)}
      );
  }
  refreshCarParts(): void {
    //refrshes carparts on frontend
    this.http.get('http://localhost:5198/api/CarPart').subscribe(
        response => { this.CarParts = response; },
        error => { console.log(error)}
      );
  }
  createCarPart(): void {
    console.log("create Car Part")
  }
  deleteCarPart(): void {
    console.log("delete Car Part")
  }
  updateCarPart(): void {
    console.log("update Car Part")
  }

}