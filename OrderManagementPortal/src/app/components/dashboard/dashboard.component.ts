import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  // Metrics
  totalOrders = 1234;
  revenue = 120345.67;
  activeUsers = 456;
  lowStockItems = 89;

  combinedData = [
    {
      name: 'Sales',
      series: [
        { name: 'Jan', value: 120 },
        { name: 'Feb', value: 200 },
        { name: 'Mar', value: 150 },
        { name: 'Apr', value: 220 },
        { name: 'May', value: 300 },
        { name: 'Jun', value: 250 }
      ]
    },
    {
      name: 'User Activity',
      series: [
        { name: 'Jan', value: 80 },
        { name: 'Feb', value: 90 },
        { name: 'Mar', value: 100 },
        { name: 'Apr', value: 110 },
        { name: 'May', value: 130 },
        { name: 'Jun', value: 120 }
      ]
    }
  ];
  // Sales Data for Line Chart
  // salesData = [
  //   {
  //     name: 'Sales',
  //     series: [
  //       { name: 'Jan', value: 120 },
  //       { name: 'Feb', value: 200 },
  //       { name: 'Mar', value: 150 },
  //       { name: 'Apr', value: 220 },
  //       { name: 'May', value: 300 },
  //       { name: 'Jun', value: 250 }
  //     ]
  //   }
  // ];

  // // User Activity Data for Bar Chart
  // userActivityData = [
  //   { name: 'Mon', value: 50 },
  //   { name: 'Tue', value: 60 },
  //   { name: 'Wed', value: 70 },
  //   { name: 'Thu', value: 100 },
  //   { name: 'Fri', value: 80 },
  //   { name: 'Sat', value: 120 },
  //   { name: 'Sun', value: 90 }
  // ];

  constructor() {
  }



}
