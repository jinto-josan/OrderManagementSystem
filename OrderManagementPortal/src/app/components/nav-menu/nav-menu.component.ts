import { Component, input, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { MenuItem } from '.';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.scss'
})
export class NavMenuComponent implements OnInit {

  menuItems=input<MenuItem[]>([]);
  isCollapsed = true;  


  constructor(private router : Router) { }  
  ngOnInit() {
    this.router.events.subscribe(val => {
      if(val instanceof NavigationEnd){
        console.log(val.urlAfterRedirects.split('?')[0],this.menuItems());
        this.menuItems().forEach(e => e.isActive = e.link === val.urlAfterRedirects.split('?')[0]);
      }
   })
  }
  toggleSidenav(): void {
    this.isCollapsed = !this.isCollapsed;
  }


}
