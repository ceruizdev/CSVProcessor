import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SesionGuard } from 'src/resources/guards/sesion/sesion.guard';
import { CSVProcessorComponent } from './components/csvprocessor/csvprocessor.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  { path: '', component: CSVProcessorComponent, canActivate: [SesionGuard] },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
