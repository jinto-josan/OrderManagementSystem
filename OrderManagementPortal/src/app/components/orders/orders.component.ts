import { AfterViewInit, Component, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { MatProgressBar } from '@angular/material/progress-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  


  ngOnInit(): void {
    this.filterOrders();
  }
  constructor(private router:Router) {}


  orders = [
    {
      id: 101,
      status: 'Not Billed',
      user: 'John Doe',
      placedDate: new Date('2024-12-01'),
      invoiceDate: null,
      total: 1500,
      deliveryDate: null,
      items: [{ name: 'Laptop', quantity: 1 }, { name: 'Mouse', quantity: 2 }],
    },
    {
      id: 102,
      status: 'Dispatched',
      user: 'Jane Smith',
      total: 2500,
      placedDate: new Date('2024-11-28'),
      invoiceDate: new Date('2024-11-30'),
      deliveryDate: new Date('2024-12-12'),
      items: [{ name: 'Chair', quantity: 1 }],
    },
    {
      id: 103,
      status: 'Dispatched',
      user: 'Jom Doe',
      placedDate: new Date('2024-12-01'),
      invoiceDate: new Date('2024-11-30'),
      total: 1500,
      deliveryDate: new Date('2024-12-06'),
      items: [{ name: 'Laptop', quantity: 1 }, { name: 'Mouse', quantity: 2 }],
      
    },
  ];

  orderStatuses = ['All', 'Not Billed','Pending', 'Dispatched', 'Delivered'];
  selectedStatus = 'All';
  searchQuery = '';
  filteredOrders :any= [];
  expandedOrderId: number | null = null;



  filterOrders(): void {
    
    this.filteredOrders = this.orders
      .filter(order => this.selectedStatus === 'All' || order.status === this.selectedStatus)
      .filter(order => {
        const query = this.searchQuery.toLowerCase();
        return (
          order.id.toString().includes(query) ||
          order.user.toLowerCase().includes(query) ||
          order.items.filter(item=>item.name.toLowerCase().includes(query)).length > 0
        );
      })
      .sort((a, b) => b.placedDate.getTime() - a.placedDate.getTime());
  }

  onSearch(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.searchQuery = input.value;
    this.filterOrders();
  }

  onFilterChange(): void {
    this.filterOrders();
  }


  exportOrders(): void {
    console.log('Export Orders clicked');
  }

  toggleOrderDetails(order: { id: number | null; }): void {
    this.expandedOrderId = this.expandedOrderId === order.id ? null : order.id;
  }

  getUserInitials(userName: string): string {
    const [firstName, lastName] = userName.split(' ');
    return `${firstName[0]}${lastName[0]}`;
  }

  getOrderItemsString(items: { name: string; quantity: number }[]): string {
    return items.map(item => `${item.name} (${item.quantity}x)`).join('; ');
  }

  dayProgressFromDispatch(order:any): number {
    const now = new Date();
    const elapsedTime = now.getTime() - order.invoiceDate.getTime();
    const totalTime = order.deliveryDate.getTime() - order.invoiceDate.getTime();

    if (order.status === 'Delivered') {
      return 100;
    }
    order.isLate=elapsedTime>totalTime;
    return Math.floor((elapsedTime / totalTime) * 100);
  }
}
