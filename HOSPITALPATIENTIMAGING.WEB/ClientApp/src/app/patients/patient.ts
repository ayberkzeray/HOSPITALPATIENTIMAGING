export interface Patient {
  id: number;
  policlinicCode: number;
  doctorID: number;
  firstName: string;
  lastName: string;
  birthDate: string;
  visitDate: string;
  scheduledVisitDate: string;
  patientNote: string;
  genderId: number;
  identificationNumber: number;
  phone: number;
}
