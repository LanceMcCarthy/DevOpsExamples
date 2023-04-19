import { Component } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent {
    public projectName = 'Kendo UI for Angular';
    public items: any[] = [
      { text: 'Home' },
    ];
}



