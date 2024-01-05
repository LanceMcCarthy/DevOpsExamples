import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MenuModule } from '@progress/kendo-angular-menu';
import { GridModule } from '@progress/kendo-angular-grid';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { PopupModule } from '@progress/kendo-angular-popup';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { SchedulerModule } from '@progress/kendo-angular-scheduler';

import 'hammerjs';

import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormComponent } from "./components/form/form.component";

import { ChartComponent } from "./components/chart/chart.component";

import { GridComponent } from "./components/grid/grid.component";


@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        HomeComponent,
        FormComponent,
        ChartComponent,
        GridComponent,
        FooterComponent
    ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        MenuModule,
        BrowserAnimationsModule,
        GridModule,
        ChartsModule,
        AppRoutingModule,
        DropDownsModule,
        PopupModule,
        InputsModule,
        LabelModule,
        ButtonsModule,
        SchedulerModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
