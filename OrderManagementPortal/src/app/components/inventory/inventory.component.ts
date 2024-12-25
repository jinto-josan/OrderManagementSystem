import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { EditDialogComponent } from './edit-dialog.component';
import { AddProductDialogComponent } from './add-product-dialog/add-product-dialog.component';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent implements OnInit {
  // Table Data
  products = [
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

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
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

  // Add New Product
  openAddProductDialog(): void {
    const dialogRef = this.dialog.open(AddProductDialogComponent, {
      width: '500px',
      data: this.categories // Pass categories for the dropdown
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Add the new product to the inventory
        this.products.push({
          ...result,
          id: this.products.length + 1,
          dateAdded: new Date()
        });
        this.dataSource.data = this.products; // Refresh the table
      }
    });
  }

  // Open Edit Dialog
  openEditDialog(product: any): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '400px',
      data: { product }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Update the product's price and quantity
        product.price = result.price;
        product.quantity = result.quantity;
        this.dataSource.data = [...this.dataSource.data]; // Refresh table
      }
    });
  }
}
