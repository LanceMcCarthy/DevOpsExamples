import { Component } from '@angular/core';

@Component({
    selector: 'app-chart',
    templateUrl: './chart.component.html'
})
export class ChartComponent {
    public series = [
        { category: 'EUROPE', value: 0.3 },
        { category: 'NORTH AMERIKA', value: 0.23 },
        { category: 'AUSTRALIA', value: 0.18 },
        { category: 'ASIA', value: 0.15 },
        { category: 'SOUTH AMERIKA', value: 0.09 },
        { category: 'AFRICA', value: 0.05 }
    ];
}
