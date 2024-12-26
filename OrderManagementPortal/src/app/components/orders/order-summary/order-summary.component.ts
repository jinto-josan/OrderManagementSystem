import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.scss']
})
export class OrderSummaryComponent implements OnInit {
  orderItems: any[] = [];
  summaryColumns: string[] = ['name', 'quantity', 'total'];

  constructor(private router: Router) {}

  ngOnInit(): void {
    const state = history.state;
    this.orderItems = state.orderItems || [];
  }

  increaseQuantity(item: any): void {
    item.orderQuantity += 1;
  }

  decreaseQuantity(item: any): void {
    if (item.orderQuantity > 0) {
      item.orderQuantity -= 1;
    }
  }
  getTotalCost(): number {
    return this.orderItems.reduce((acc, item) => acc + item.price * item.orderQuantity, 0);
  }

  confirmOrder(): void {
    console.log('Order Confirmed:', this.orderItems);
    alert('Order confirmed successfully!');
    this.router.navigate(['/orders']); // Redirect to inventory
  }
  cancelOrder(): void {
    // Navigate back to the Create Order page with the current state
    this.router.navigate(['/create-order'], { state: { orderItems: this.orderItems } });
  }
}
