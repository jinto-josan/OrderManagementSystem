import { createReducer, on } from '@ngrx/store';
import { addProductToOrder } from './order.actions';
import { Product } from './product.model';

export const initialState: Product[] = [];

export const orderReducer = createReducer(
  initialState,
  on(addProductToOrder, (state, { product }) => [...state, product])
);
