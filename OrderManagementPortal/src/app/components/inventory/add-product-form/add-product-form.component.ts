import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product-form.component.html',
  styleUrls: ['./add-product-form.component.scss']
})
export class AddProductFormComponent {
  addProductForm: FormGroup;
  imagePreviews: string[] = [];
  categories: string[] = ['Electronics', 'Furniture', 'Appliances']; // Sample categories

  constructor(private fb: FormBuilder, private router: Router) {
    this.addProductForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      category: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(0)]],
      stock: ['', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required, Validators.min(0)]],
      size: ['', Validators.required],
      images: [[]]
    });
  }

  onImageUpload(event: Event): void {
    const files = (event.target as HTMLInputElement).files;
    if (!files) return;

    const imagesArray = Array.from(files).slice(0, 5);
    this.addProductForm.patchValue({ images: imagesArray });

    this.imagePreviews = imagesArray.map(file => URL.createObjectURL(file));
  }

  onSubmit(): void {
    if (this.addProductForm.valid) {
      // Navigate back to inventory page
      this.router.navigate(['/inventory'], { state: { newProduct: this.addProductForm.value } });
    }
  }
}
