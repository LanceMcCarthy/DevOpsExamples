import { Component } from '@angular/core';
import {
  SVGIcon,
  boldIcon,
  italicIcon,
  underlineIcon,
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-root',
  template: `
    <div class="row">
        <div class="col-sm-12 col-md-4 example-col">
          <p>Icons only</p>
          <kendo-buttongroup>
            <button
              kendoButton
              [toggleable]="true"
              [svgIcon]="boldSVG"
              title="Bold"
            ></button>
            <button
              kendoButton
              [toggleable]="true"
              [svgIcon]="italicSVG"
              title="Italic"
            ></button>
            <button
              kendoButton
              [toggleable]="true"
              [svgIcon]="underlineSVG"
              title="Underline"
            ></button>
          </kendo-buttongroup>
        </div>
        <div class="col-sm-12 col-md-4 example-col">
          <p>Text only</p>
          <kendo-buttongroup>
            <button kendoButton [toggleable]="true">Bold</button>
            <button kendoButton [toggleable]="true">Italic</button>
            <button kendoButton [toggleable]="true">Underline</button>
          </kendo-buttongroup>
        </div>
        <div class="col-sm-12 col-md-4 example-col">
          <p>Icons + Text</p>
          <kendo-buttongroup>
            <button kendoButton [toggleable]="true" [svgIcon]="boldSVG">
              Bold
            </button>
            <button kendoButton [toggleable]="true" [svgIcon]="italicSVG">
              Italic
            </button>
            <button kendoButton [toggleable]="true" [svgIcon]="underlineSVG">
              Underline
            </button>
          </kendo-buttongroup>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12 example-col">
          <p>Buttons with responsive width</p>
          <kendo-buttongroup width="100%">
            <button kendoButton [toggleable]="true" [svgIcon]="boldSVG">
              Bold
            </button>
            <button kendoButton [toggleable]="true" [svgIcon]="italicSVG">
              Italic
            </button>
            <button kendoButton [toggleable]="true" [svgIcon]="underlineSVG">
              Underline
            </button>
          </kendo-buttongroup>
        </div>
      </div>`,
  standalone: false
})
export class AppComponent {
  title = 'angular_demo';
  public boldSVG: SVGIcon = boldIcon;
  public italicSVG: SVGIcon = italicIcon;
  public underlineSVG: SVGIcon = underlineIcon;
}
