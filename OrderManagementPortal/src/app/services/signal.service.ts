import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: HubConnection;
  private orderSubject = new BehaviorSubject<any>(null);

  constructor() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://your-api-url.com/orderHub')
      .build();

    this.hubConnection.start().catch(err => console.log('SignalR Connection Error: ', err));

    this.hubConnection.on('OrderUpdated', (order) => {
      this.orderSubject.next(order);
    });
  }

  get orderUpdates() {
    return this.orderSubject.asObservable();
  }
}
