import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CSVProcessorComponent } from './components/csvprocessor/csvprocessor.component';

const routes: Routes = [
  { path: '', component: CSVProcessorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
