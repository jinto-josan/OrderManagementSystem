import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatIconModule } from '@angular/material/icon';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatCardModule } from '@angular/material/card';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import {NgxChartsModule} from '@swimlane/ngx-charts';
import {MatMenuModule} from '@angular/material/menu';
import {MatBadgeModule} from '@angular/material/badge';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import { ComboChartComponent } from './components/combo-chart/combo-chart.component';
import { ComboSeriesVerticalComponent } from './components/combo-chart/combo-series-vertical.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CommonModule } from '@angular/common';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { InventoryComponent } from './components/inventory/inventory.component';
import { EditDialogComponent } from './components/inventory/edit-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddProductFormComponent } from './components/inventory/add-product-form/add-product-form.component';
import { CreateOrderFormComponent } from './components/orders/create-order-form/create-order-form.component';
import { OrderSummaryComponent } from './components/orders/order-summary/order-summary.component';

@NgModule({
  declarations: [AppComponent,
    DashboardComponent, OrdersComponent, CreateOrderFormComponent, OrderSummaryComponent, InventoryComponent,
    EditDialogComponent, AddProductFormComponent,
    ComboChartComponent,ComboSeriesVerticalComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    NgxChartsModule,
    MatMenuModule,
    MatListModule,
    MatBadgeModule,
    MatPaginatorModule,
    MatTableModule,

  //Form modules for mat
    MatOptionModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressBarModule,
    MatButtonModule],
  bootstrap: [AppComponent],
  providers: [
    provideAnimationsAsync()
  ]
})
export class AppModule {}
