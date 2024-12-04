import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './components/orders/orders.component';
import { InventoryComponent } from './components/inventory/inventory.component';
import { UsersComponent } from './components/users/users.component';
import { FinanceComponent } from './components/finance/finance.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'inventory', component: InventoryComponent },
  { path: 'users', component: UsersComponent },
  { path: 'finance', component: FinanceComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
