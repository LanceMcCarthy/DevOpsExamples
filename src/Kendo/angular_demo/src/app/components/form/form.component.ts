import { Component, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TextBoxComponent } from '@progress/kendo-angular-inputs';
import { SVGIcon, eyeIcon } from '@progress/kendo-svg-icons';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styles: [
        `
            .form-wrapper {
                display: flex;
                justify-content: center;
            }
            .k-form {
                width: 300px;
            }
        `,
    ],
    encapsulation: ViewEncapsulation.None,
})

export class FormComponent {
    @ViewChild('password') public textbox: TextBoxComponent | undefined;

    public eye: SVGIcon = eyeIcon;

    public form: FormGroup;
    public data: any = {
        firstName: '',
        lastName: '',
        gender: null,
        email: '',
        company: '',
        username: '',
        password: '',
    };

    constructor() {
        this.form = new FormGroup({
        firstName: new FormControl(this.data.firstName, [Validators.required]),
        lastName: new FormControl(this.data.lastName, [Validators.required]),
        gender: new FormControl(this.data.gender, [Validators.required]),
        email: new FormControl(this.data.email, [
            Validators.required,
            Validators.email,
        ]),
        company: new FormControl(),
        username: new FormControl(this.data.username, [Validators.required]),
        password: new FormControl(this.data.password, [Validators.required]),
        });
    }

    public ngAfterViewInit(): void {
        if(this.textbox)
            this.textbox.input.nativeElement.type = 'password';
    }

    public toggleVisibility(): void {
        if(this.textbox) {
            const inputEl = this.textbox.input.nativeElement;
            inputEl.type = inputEl.type === 'password' ? 'text' : 'password';
        }
    }

    public submit(): void {
        this.form.markAllAsTouched();
    }

    public clearForm(): void {
        this.form.reset();
    }
}
