import { Component, OnInit } from '@angular/core';
import { SpinnerService } from 'src/resources/services/shared/spinner.service';

@Component({
  selector: 'app-spinner',
  template: `
    <div class="overlay" *ngIf="isLoading$ | async">
      <div class="lds-grid">
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
    </div>
  `,
  styleUrls: ['./spinner.component.css'],
})
export class SpinnerComponent implements OnInit {
  isLoading$ = this.spinnerService.isLoading$;
  constructor(private spinnerService: SpinnerService) { }

  ngOnInit(): void {
  }
}
