import { createReducer, on } from '@ngrx/store';
import { loadProductsSuccess, loadProductsFailure } from './product.actions';
import { Product } from './product.model';

export const initialState: Product[] = [];

export const productReducer = createReducer(
  initialState,
  on(loadProductsSuccess, (state, { products }) => [...products]),
  on(loadProductsFailure, (state, { error }) => { 
    // Handle error state if needed 
    return state;
  })
);
