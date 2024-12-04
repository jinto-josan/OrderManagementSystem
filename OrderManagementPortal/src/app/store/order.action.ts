import { createAction, props } from '@ngrx/store';
import { Product } from './product.model';

export const addProductToOrder = createAction('[Order] Add Product to Order', props<{ product: Product }>());
