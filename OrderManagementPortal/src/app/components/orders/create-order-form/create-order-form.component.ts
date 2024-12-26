import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-order-form',
  templateUrl: './create-order-form.component.html',
  styleUrl: './create-order-form.component.scss'
})
export class CreateOrderFormComponent implements OnInit {
  // Table Data
  products:({
    image: string;
    name: string;
    description: string;
    quantity: number;
    price: number;
    dateAdded: Date;
    category: string;
    id: number;
  } &{orderQuantity?:number})[] = [
    {
      id: 1,
      image: 'https://via.placeholder.com/50',
      name: 'Laptop',
      description: 'High performance laptop',
      quantity: 10,
      price: 1200,
      dateAdded: new Date('2023-12-01'),
      category: 'Electronics'
    },
    {
      id: 2,
      image: 'https://via.placeholder.com/50',
      name: 'Smartphone',
      description: 'Latest model smartphone',
      quantity: 20,
      price: 800,
      dateAdded: new Date('2023-11-15'),
      category: 'Electronics'
    },
    {
      id: 3,
      image: 'https://via.placeholder.com/50',
      name: 'Office Chair',
      description: 'Ergonomic office chair',
      quantity: 5,
      price: 150,
      dateAdded: new Date('2023-11-10'),
      category: 'Furniture'
    }
  ];

  // Filter Options
  categories = ['Electronics', 'Furniture', 'Appliances'];
  selectedCategory = 'All';
  searchQuery = '';

  // Table Data Source
  dataSource: MatTableDataSource<any> = new MatTableDataSource(this.products);

  // Table Columns
  displayedColumns: string[] = ['image', 'name', 'quantity', 'price', 'dateAdded', 'edit'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog: MatDialog, private router:Router) {}

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    const state = history.state;
    const orderItems = state.orderItems || [];

    // Restore quantities from the returned orderItems
    if (orderItems.length) {
      this.products.forEach(product => {
        const matchedItem = orderItems.find((item: { id: number; }) => item.id === product.id);
        product.orderQuantity = matchedItem ? matchedItem.orderQuantity : 0;
      });
    }
  }

  // Filter by Search Query
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.dataSource.filter = filterValue;
  }

  // Filter by Category
  applyCategoryFilter(): void {
    if (this.selectedCategory === 'All') {
      this.dataSource.data = this.products;
    } else {
      this.dataSource.data = this.products.filter(
        product => product.category === this.selectedCategory
      );
    }
  }

  increaseQuantity(product: any): void {
    if(product.quantity === 0) return;
    product.orderQuantity = (product.orderQuantity || 0) + 1;
    product.quantity--;
  }

  decreaseQuantity(product: any): void {
    if (product.orderQuantity > 0) {
      product.orderQuantity -= 1;
      product.quantity++
    }
    
  }

  hasOrderItems(): boolean {
    return this.products.some(product => product.orderQuantity &&  product.orderQuantity > 0);
  }

  goToSummary(): void {
    const orderItems = this.products.filter(product => product.orderQuantity && product.orderQuantity > 0);
    this.router.navigate(['order-summary'], { state: { orderItems } });
  }
}
