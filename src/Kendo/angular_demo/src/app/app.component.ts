import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <button
        kendoButton
      >
        User Settings
      </button>
  `,
  standalone: false
})
export class AppComponent {
  title = 'angular_demo';
}
