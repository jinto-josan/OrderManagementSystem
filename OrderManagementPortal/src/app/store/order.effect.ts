import { Injectable } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { Observable, of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { OrderService } from './order.service';
import { loadOrders, loadOrdersSuccess, loadOrdersFailure } from './order.actions';

@Injectable()
export class OrderEffects {

  loadOrders$ = createEffect(() => this.actions$.pipe(
    ofType(loadOrders),
    mergeMap(() => this.orderService.getOrders()
      .pipe(
        map(orders => loadOrdersSuccess({ orders })),
        catchError(error => of(loadOrdersFailure({ error })))
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private orderService: OrderService
  ) {}
}
