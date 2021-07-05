import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Patient } from "../patient";
import { PatientsService } from "../patients.service";
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  id: number;
  patient: Patient;
  constructor(
    public patientsService: PatientsService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['patientid'];
    this.patientsService.getPatient(this.id).subscribe((data: Patient) => {
      this.patient = data;
    });
  }

}
