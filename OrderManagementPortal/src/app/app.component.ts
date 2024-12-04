import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isCollapsed = true;

  toggleSidenav(): void {
    this.isCollapsed = !this.isCollapsed;
  }

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
