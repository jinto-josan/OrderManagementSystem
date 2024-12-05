import { Component, HostListener } from '@angular/core';
import { ScaleType } from '@swimlane/ngx-charts';

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


  kpiPerCategory = [
    {
      "name": "Electronics", 
      "series": [
        {
          "name": "Revenue*10^3", 
          "value": 15
        },
        {
          "name": "Orders*10", 
          "value": 12
        },
        {
          "name": "Users*10", 
          "value": 10
        }
      ]
    },
    {
      "name": "Clothing", 
      "series": [
        {
          "name": "Revenue*10^3", 
          "value": 8
        },
        {
          "name": "Orders*10", 
          "value": 8
        },
        {
          "name": "Users*10", 
          "value": 7
        }
      ]
    },
    {
      "name": "Groceries", 
      "series": [
        {
          "name": "Revenue*10^3", 
          "value": 5
        },
        {
          "name": "Orders*10", 
          "value": 5
        },
        {
          "name": "Users*10", 
          "value": 4
        }
      ]
    }
  ];


  lineChartData = [
    {
      name: 'Sales',
      series: [
        { name: 'Jan', value: 80 },
        { name: 'Feb', value: 90 },
        { name: 'Mar', value: 100 },
        { name: 'Apr', value: 110 },
        { name: 'May', value: 130 },
        { name: 'Jun', value: 120 }
      ]
    }]

    barchartData = [
      
      { name: 'Jan', value: 120 },
      { name: 'Feb', value: 200 },
      { name: 'Mar', value: 150 },
      { name: 'Apr', value: 220 },
      { name: 'May', value: 300 },
      { name: 'Jun', value: 250 }
        
  ];

  // Stacked Bar Chart Data (Order Fulfillment Trends)
  orderFulfillmentData = [
    {
      name: 'Jan',
      series: [
        { name: 'Pending', value: 20 },
        { name: 'Shipped', value: 50 },
        { name: 'Delivered', value: 100 },
        { name: 'Canceled', value: 5 }
      ]
    },
    {
      name: 'Feb',
      series: [
        { name: 'Pending', value: 15 },
        { name: 'Shipped', value: 60 },
        { name: 'Delivered', value: 120 },
        { name: 'Canceled', value: 10 }
      ]
    },
    {
      name: 'Mar',
      series: [
        { name: 'Pending', value: 10 },
        { name: 'Shipped', value: 80 },
        { name: 'Delivered', value: 150 },
        { name: 'Canceled', value: 8 }
      ]
    },
    {
      name: 'Apr',
      series: [
        { name: 'Pending', value: 12 },
        { name: 'Shipped', value: 70 },
        { name: 'Delivered', value: 140 },
        { name: 'Canceled', value: 6 }
      ]
    },
    {
      name: 'May',
      series: [
        { name: 'Pending', value: 25 },
        { name: 'Shipped', value: 90 },
        { name: 'Delivered', value: 160 },
        { name: 'Canceled', value: 7 }
      ]
    },
    {
      name: 'Jun',
      series: [
        { name: 'Pending', value: 30 },
        { name: 'Shipped', value: 100 },
        { name: 'Delivered', value: 180 },
        { name: 'Canceled', value: 10 }
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
