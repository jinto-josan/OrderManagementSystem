import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-dialog',
  template: `
    <h1 mat-dialog-title>Edit {{ data.product.name }}</h1>
    <div mat-dialog-content>
      <mat-form-field appearance="outline">
        <mat-label>New Price</mat-label>
        <input matInput [(ngModel)]="updatedPrice" type="number" />
      </mat-form-field>
      <mat-form-field appearance="outline">
        <mat-label>New Quantity</mat-label>
        <input matInput [(ngModel)]="updatedQuantity" type="number" />
      </mat-form-field>
    </div>
    <div mat-dialog-actions>
      <button mat-button (click)="onCancel()">Cancel</button>
      <button mat-raised-button color="primary" (click)="onSave()">Save</button>
    </div>
  `
})
export class EditDialogComponent {
  updatedPrice: number;
  updatedQuantity: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<EditDialogComponent>
  ) {
    this.updatedPrice = data.product.price;
    this.updatedQuantity = data.product.quantity;
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    this.dialogRef.close({ price: this.updatedPrice, quantity: this.updatedQuantity });
  }
}
