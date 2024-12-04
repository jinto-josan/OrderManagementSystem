import { Injectable } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { Observable, of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { ProductService } from './product.service'; // Assume ProductService handles API requests
import { loadProducts, loadProductsSuccess, loadProductsFailure } from './product.actions';

@Injectable()
export class ProductEffects {
  loadProducts$ = createEffect(() => this.actions$.pipe(
    ofType(loadProducts),
    mergeMap(() => this.productService.getProducts()
      .pipe(
        map(products => loadProductsSuccess({ products })),
        catchError(error => of(loadProductsFailure({ error })))
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private productService: ProductService
  ) {}
}
