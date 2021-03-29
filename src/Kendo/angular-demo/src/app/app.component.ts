import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Kendo UI for Angular demo';
  public onButtonClick(): void {
    console.log('Kendo Button Click');
  }
}
