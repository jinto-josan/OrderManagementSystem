import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { MsalService } from '@azure/msal-angular';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private msalService: MsalService) {}

  canActivate(): boolean {
    if (this.msalService.instance.getAllAccounts().length > 0) {
      return true;
    } else {
      this.msalService.loginRedirect();
      return false;
    }
  }
}
