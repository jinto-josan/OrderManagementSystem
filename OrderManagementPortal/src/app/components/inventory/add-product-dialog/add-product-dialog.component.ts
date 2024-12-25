import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-product-dialog',
  templateUrl: './add-product-dialog.component.html',
  styleUrls: ['./add-product-dialog.component.scss']
})
export class AddProductDialogComponent {
  addProductForm: FormGroup;
  imagePreviews: string[] = []; // Holds image previews

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddProductDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public categories: string[]
  ) {
    // Initialize the form
    this.addProductForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      category: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(0)]],
      stock: ['', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required, Validators.min(0)]],
      size: ['', Validators.required],
      images: [[]] // Array to hold uploaded files
    });
  }

  onImageUpload(event: Event): void {
    const files = (event.target as HTMLInputElement).files;
    if (!files) return;

    // Allow up to 5 images
    const imagesArray = Array.from(files).slice(0, 5);
    this.addProductForm.patchValue({ images: imagesArray });

    // Generate previews
    this.imagePreviews = imagesArray.map(file => URL.createObjectURL(file));
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.addProductForm.valid) {
      this.dialogRef.close(this.addProductForm.value);
    }
  }
}
