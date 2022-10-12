import { Component } from '@angular/core';
import { categories } from "./data.categories";
import { GridDataResult, PageChangeEvent } from "@progress/kendo-angular-grid";
import { SortDescriptor } from "@progress/kendo-data-query";
import { ProductService } from "./product.service";
import { Observable } from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ProductService]
})

export class AppComponent {
  // used for the DropDownList
  public dropDownItems = categories;
  public defaultItem = { text: 'Filter by Category', value: null };

  // used for the Grid
  public gridItems!: Observable<GridDataResult>;
  public pageSize: number = 10;
  public skip: number = 0;
  public sortDescriptor: SortDescriptor[] = [];
  // public filterDescriptor: FilterDescriptor[] = [];
  public filterTerm: number | null = null;

  public listItems: Array<string> = [
    "Albania",
    "Andorra",
    "Armenia",
    "Austria",
    "Azerbaijan",
    "Belarus",
    "Belgium",
    "Bosnia & Herzegovina",
    "Bulgaria",
    "Croatia",
    "Cyprus",
    "Czech Republic",
    "Denmark",
    "Estonia",
    "Finland",
    "France",
    "Georgia",
    "Germany",
    "Greece",
    "Hungary",
    "Iceland",
    "Ireland",
    "Italy",
    "Kosovo",
    "Latvia",
    "Liechtenstein",
    "Lithuania",
    "Luxembourg",
    "Macedonia",
    "Malta",
    "Moldova",
    "Monaco",
    "Montenegro",
    "Netherlands",
    "Norway",
    "Poland",
    "Portugal",
    "Romania",
    "Russia",
    "San Marino",
    "Serbia",
    "Slovakia",
    "Slovenia",
    "Spain",
    "Sweden",
    "Switzerland",
    "Turkey",
    "Ukraine",
    "United Kingdom",
    "Vatican City",
  ];

  constructor(private service: ProductService) {
      this.loadGridItems();
  }

  public pageChange(event: PageChangeEvent): void {
      this.skip = event.skip;
      this.loadGridItems();
  }

  private loadGridItems(): void {
      this.gridItems = this.service.getProducts(this.skip, this.pageSize, this.sortDescriptor, this.filterTerm);
  }

  public handleSortChange(descriptor: SortDescriptor[]): void {
      this.sortDescriptor = descriptor;
      this.loadGridItems();
  }

  public handleFilterChange(item: { text: string; value: number | null }): void {
      this.filterTerm = item.value;
      this.skip = 0;
      this.loadGridItems();
  }
}
