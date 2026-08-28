import { Component } from '@angular/core';
import {
  SVGIcon,
  boldIcon,
  italicIcon,
  underlineIcon,
} from "@progress/kendo-svg-icons";
import { DatePipe } from "@angular/common";
import {
  KENDO_CHARTS,
  SeriesLabelsContentArgs,
  SankeyData,
} from "@progress/kendo-angular-charts";
import {
  monthlyRevenueData,
  productCategoryData,
  kpiMetrics,
  stockPriceData,
  revenueFlowData,
  MonthlyRevenue,
  ProductCategory,
  KpiMetric,
  StockDataPoint,
} from "./data";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [KENDO_CHARTS, DatePipe],
  template: `
    <div class="demo-container">
      <div class="kpi-row">
        @for (kpi of kpiMetrics; track kpi.label) {
        <div class="kpi-card">
          <div class="kpi-top">
            <div class="kpi-info">
              <p class="kpi-label">{{ kpi.label }}</p>
              <p class="kpi-value">{{ kpi.value }}</p>
            </div>
            <p
              class="kpi-change"
              [class.positive]="kpi.change > 0"
              [class.negative]="kpi.change < 0"
            >
              {{ kpi.change > 0 ? "▲" : "▼" }} {{ absValue(kpi.change) }}%
            </p>
          </div>
          <kendo-sparkline
            class="kpi-sparkline"
            [data]="kpi.trend"
            [type]="kpi.change < 0 ? 'area' : 'line'"
            [seriesColors]="kpi.change >= 0 ? positiveColors : negativeColors"
          >
          </kendo-sparkline>
        </div>
        }
      </div>

      <div class="charts-grid">
        <div class="chart-card">
          <div class="chart-header">
            <h3 class="chart-title">Monthly Revenue</h3>
            <p class="chart-subtitle">
              Current year vs. previous year with targets
            </p>
          </div>
          <kendo-chart class="revenue-chart">
            <kendo-chart-category-axis>
              <kendo-chart-category-axis-item [categories]="months">
              </kendo-chart-category-axis-item>
            </kendo-chart-category-axis>
            <kendo-chart-series>
              <kendo-chart-series-item
                type="column"
                [data]="currentRevenue"
                name="2025 Revenue"
              >
              </kendo-chart-series-item>
              <kendo-chart-series-item
                type="line"
                [data]="previousRevenue"
                name="2024 Revenue"
                [markers]="{ visible: true, size: 4 }"
                [lineStyle]="'smooth'"
              >
              </kendo-chart-series-item>
              <kendo-chart-series-item
                type="line"
                [data]="targetValues"
                name="Target"
                dashType="dash"
                [markers]="{ visible: false }"
              >
              </kendo-chart-series-item>
            </kendo-chart-series>
            <kendo-chart-value-axis>
              <kendo-chart-value-axis-item [labels]="{ format: 'c0' }">
              </kendo-chart-value-axis-item>
            </kendo-chart-value-axis>
            <kendo-chart-legend position="bottom"></kendo-chart-legend>
            <kendo-chart-tooltip>
              <ng-template
                kendoChartSharedTooltipTemplate
                let-category="category"
                let-points="points"
              >
                <strong>{{ category }}</strong>
                @for (point of points; track point.series.name) {
                <div>
                  {{ point.series.name }}: {{ formatCurrency(point.value) }}
                </div>
                }
              </ng-template>
            </kendo-chart-tooltip>
          </kendo-chart>
        </div>

        <div class="chart-card">
          <div class="chart-header">
            <h3 class="chart-title">Revenue by Category</h3>
            <p class="chart-subtitle">Product category distribution</p>
          </div>
          <kendo-chart class="donut-chart">
            <kendo-chart-series>
              <kendo-chart-series-item
                type="donut"
                [data]="categoryData"
                categoryField="category"
                field="value"
                [holeSize]="70"
              >
                <kendo-chart-series-item-labels
                  position="outsideEnd"
                  [content]="donutLabelContent"
                  background="none"
                >
                </kendo-chart-series-item-labels>
              </kendo-chart-series-item>
            </kendo-chart-series>
            <kendo-chart-legend position="bottom"></kendo-chart-legend>
            <kendo-chart-tooltip>
              <ng-template
                kendoChartSeriesTooltipTemplate
                let-value="value"
                let-category="category"
              >
                <strong>{{ category }}</strong
                ><br />
                Revenue: {{ formatCurrency(value) }}
              </ng-template>
            </kendo-chart-tooltip>
            <ng-template kendoChartDonutCenterTemplate>
              <div class="center-template">
                <p class="center-value">{{ totalRevenue }}</p>
                <p class="center-label">Total</p>
              </div>
            </ng-template>
          </kendo-chart>
        </div>

        <div class="chart-card full-width">
          <div class="chart-header">
            <h3 class="chart-title">Revenue Flow</h3>
            <p class="chart-subtitle">
              Traffic source → product category → order outcome
            </p>
          </div>
          <kendo-sankey class="sankey-chart" [data]="sankeyData">
            <kendo-sankey-links colorType="source"></kendo-sankey-links>
            <kendo-sankey-tooltip>
              <ng-template
                kendoSankeyNodeTooltipTemplate
                let-label="label"
                let-value="value"
              >
                <strong>{{ label.text }}</strong
                >: {{ value }} orders
              </ng-template>
              <ng-template
                kendoSankeyLinkTooltipTemplate
                let-source="source"
                let-target="target"
                let-value="value"
              >
                {{ source.label.text }} → {{ target.label.text }}:
                {{ value }} orders
              </ng-template>
            </kendo-sankey-tooltip>
          </kendo-sankey>
        </div>

        <div class="chart-card full-width">
          <div class="chart-header">
            <h3 class="chart-title">Daily Stock Price</h3>
            <p class="chart-subtitle">
              Candlestick chart with navigator (Jan–Mar 2025)
            </p>
          </div>
          <kendo-stockchart class="stock-chart">
            <kendo-chart-series>
              <kendo-chart-series-item
                type="candlestick"
                [data]="stockData"
                openField="open"
                closeField="close"
                lowField="low"
                highField="high"
                categoryField="date"
              >
              </kendo-chart-series-item>
            </kendo-chart-series>
            <kendo-chart-value-axis>
              <kendo-chart-value-axis-item [labels]="{ format: 'c0' }">
              </kendo-chart-value-axis-item>
            </kendo-chart-value-axis>
            <kendo-chart-navigator>
              <kendo-chart-navigator-select
                [from]="navigatorFrom"
                [to]="navigatorTo"
              >
              </kendo-chart-navigator-select>
              <kendo-chart-navigator-series>
                <kendo-chart-navigator-series-item
                  type="area"
                  [data]="stockData"
                  field="close"
                  categoryField="date"
                >
                </kendo-chart-navigator-series-item>
              </kendo-chart-navigator-series>
            </kendo-chart-navigator>
            <kendo-chart-tooltip>
              <ng-template
                kendoChartSeriesTooltipTemplate
                let-dataItem="dataItem"
              >
                <strong>{{ dataItem.date | date : "mediumDate" }}</strong
                ><br />
                Open: {{ formatCurrency(dataItem.open) }}<br />
                High: {{ formatCurrency(dataItem.high) }}<br />
                Low: {{ formatCurrency(dataItem.low) }}<br />
                Close: {{ formatCurrency(dataItem.close) }}
              </ng-template>
            </kendo-chart-tooltip>
          </kendo-stockchart>
        </div>
      </div>
    </div>`
})
export class AppComponent {
  title = 'angular_demo';
  public boldSVG: SVGIcon = boldIcon;
  public italicSVG: SVGIcon = italicIcon;
  public underlineSVG: SVGIcon = underlineIcon;

  public kpiMetrics: KpiMetric[] = kpiMetrics;
  public categoryData: ProductCategory[] = productCategoryData;

  public months: string[] = monthlyRevenueData.map(
    (d: MonthlyRevenue) => d.month
  );
  public currentRevenue: number[] = monthlyRevenueData.map(
    (d: MonthlyRevenue) => d.revenue
  );
  public previousRevenue: number[] = monthlyRevenueData.map(
    (d: MonthlyRevenue) => d.previousYear
  );
  public targetValues: number[] = monthlyRevenueData.map(
    (d: MonthlyRevenue) => d.target
  );

  public stockData: StockDataPoint[] = stockPriceData;
  public sankeyData: SankeyData = revenueFlowData;
  public navigatorFrom: Date = new Date(2025, 0, 2);
  public navigatorTo: Date = new Date(2025, 2, 7);

  public positiveColors: string[] = ["var(--kendo-color-success)"];
  public negativeColors: string[] = ["var(--kendo-color-error)"];

  public totalRevenue: string = this.formatCurrency(
    productCategoryData.reduce(
      (sum: number, item: ProductCategory) => sum + item.value,
      0
    )
  );

  public donutLabelContent = (args: SeriesLabelsContentArgs): string => {
    return `${args.category}\n${((args.percentage ?? 0) * 100).toFixed(1)}%`;
  };

  public formatCurrency(value: number): string {
    return value >= 1000000
      ? `$${(value / 1000000).toFixed(2)}M`
      : value >= 1000
      ? `$${(value / 1000).toFixed(0)}K`
      : `$${value}`;
  }

  public absValue(value: number): number {
    return Math.abs(value);
  }
}
