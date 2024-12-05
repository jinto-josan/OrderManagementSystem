import { Component } from '@angular/core';
import { MenuItem } from './components/nav-menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {


  menuItems:MenuItem[]=[
    {icon:'home',name:'Dashboard',link:'/dashboard'},
    {icon:'shopping_cart',name:'Orders',link:'/orders'},
    {icon:'store',name:'Inventory',link:'/inventory'},
    {icon:'group',name:'Users',link:'/users'},
    {icon:'attach_money',name:'Finance',link:'/finance'},
  ]


 

  notifications: string[] = [
    'Order #1234 has been shipped.',
    'New user registered: John Doe.',
    'Inventory for Item #456 is low.'
  ];

  viewProfile(): void {
    console.log('Navigating to user profile...');
  }

  // Logout functionality
  logout(): void {
    console.log('Logging out...');
  }
}
