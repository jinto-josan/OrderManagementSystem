import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './components/orders/orders.component';
import { InventoryComponent } from './components/inventory/inventory.component';
import { UsersComponent } from './components/users/users.component';
import { FinanceComponent } from './components/finance/finance.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddProductFormComponent } from './components/inventory/add-product-form/add-product-form.component';
import { CreateOrderFormComponent } from './components/orders/create-order-form/create-order-form.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'orders', component: OrdersComponent },
  {path: 'create-order', component: CreateOrderFormComponent},
  { path: 'inventory', component: InventoryComponent}, 
  { path: 'add-product', component: AddProductFormComponent },
  { path: 'users', component: UsersComponent },
  { path: 'finance', component: FinanceComponent },
  
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
