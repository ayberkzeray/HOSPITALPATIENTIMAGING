import { Component, OnInit } from '@angular/core';
import { Patient } from "../patient";
import { PatientsService } from "../patients.service";
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  patients: Patient[] = [];

  constructor(public patientsService: PatientsService) { }

  ngOnInit(): void {
    this.patientsService.getPatients().subscribe((data: Patient[]) => {
      this.patients = data;
    });
  }

  deletePatient(id) {
    this.patientsService.deletePatient(id).subscribe(res => {
      this.patients = this.patients.filter(item => item.id !== id);
    });
  }

}
