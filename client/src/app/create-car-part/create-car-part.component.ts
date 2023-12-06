import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-car-part',
  templateUrl: './create-car-part.component.html',
  styleUrls: ['./create-car-part.component.css']
})
export class CreateCarPartComponent implements OnInit {
  model: any = {}

  constructor(
    private http: HttpClient,
    private route: Router) { }

  ngOnInit(): void {
  }

  createCarPart() {
    this.http.post('http://localhost:5198/api/CarPart', this.model).subscribe(
      response => { this.home() },
      error => {console.log(error)}
    );
  }

  cancel() {
    this.home();
    console.log("Cancel create post");
  }

  home() {
    this.route.navigate(["/"]);
  }

}
