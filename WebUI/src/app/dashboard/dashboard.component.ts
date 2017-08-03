import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {

	time: any;

	constructor(private http: HttpClient) {}

	ngOnInit():void {
		console.log("Initialized");
		this.getTime();
	}

	getTime():void {
		this.http.get("/api/sampleapi/time").subscribe(data => {
			this.time = (<any>data).time;
			setTimeout(() => { this.getTime() }, 1000);
		}, err => {
			this.time = "-- server is not answering --";
			setTimeout(() => { this.getTime() }, 1000);
		})
	}

}
