import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  // Chart view dimensions
  view: [number, number] = [700, 300];

  // Color scheme for charts
  colorScheme = {
    domain: ['#1976D2', '#FF9800', '#4CAF50', '#F44336']
  };

  // Data for Sales Trend (Line Chart)
  salesData = [
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
    }
  ];

  // Data for User Activity (Bar Chart)
  userActivityData = [
    { name: 'Mon', value: 50 },
    { name: 'Tue', value: 60 },
    { name: 'Wed', value: 70 },
    { name: 'Thu', value: 100 },
    { name: 'Fri', value: 80 },
    { name: 'Sat', value: 120 },
    { name: 'Sun', value: 90 }
  ];
}
