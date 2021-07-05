import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Patient } from "./patient";

@Injectable({
  providedIn: 'root'
})
export class PatientsService {
  private apiURL = "https://localhost:44392/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private httpClient: HttpClient) { }

  getPatients(): Observable<Patient[]> {
    return this.httpClient.get<Patient[]>(this.apiURL + '/patient')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getPatient(id): Observable<Patient> {
    return this.httpClient.get<Patient>(this.apiURL + '/patient/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createPatient(patient): Observable<Patient> {
    return this.httpClient.post<Patient>(this.apiURL + '/patient/', JSON.stringify(patient), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updatePatient(id, patient): Observable<Patient> {
    return this.httpClient.put<Patient>(this.apiURL + '/patient/' + id, JSON.stringify(patient), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deletePatient(id) {
    return this.httpClient.delete<Patient>(this.apiURL + '/patient/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }
  errorHandler(error) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
