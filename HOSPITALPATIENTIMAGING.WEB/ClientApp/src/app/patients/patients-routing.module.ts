import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  { path: 'patients', redirectTo: 'patients/list', pathMatch: 'full' },
  { path: 'patients/list', component: ListComponent },
  { path: 'patients/:patientid/details', component: DetailsComponent },
  { path: 'patients/create', component: CreateComponent },
  { path: 'patients/:patientid/edit', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientsRoutingModule { }
