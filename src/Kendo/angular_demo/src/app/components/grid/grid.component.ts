import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { products } from '../../common/products';
import { Product } from '../../common/product-model';

@Component({
    selector: 'app-grid.component',
    templateUrl: './grid.component.html'
})
export class GridComponent {
    public gridData: Product[] = products;
    public pageSize = 10;
    public formGroup: undefined | FormGroup;

    constructor(private formBuilder: FormBuilder) {}

    public createFormGroup = (args: any): FormGroup => {
        const item = args.isNew ? new Product() : args.dataItem;

        this.formGroup = this.formBuilder.group({
            ProductID: item.ProductID,
            ProductName: [item.ProductName, Validators.required],
            UnitPrice: item.UnitPrice,
            UnitsInStock: [item.UnitsInStock, Validators.compose([Validators.required, Validators.pattern('^[0-9]{1,3}')])],
            Discontinued: item.Discontinued
        });

        return this.formGroup;
    }
}
