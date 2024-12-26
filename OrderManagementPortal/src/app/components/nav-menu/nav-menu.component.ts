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
        this.menuItems().forEach(e => {
          // let activeTab=val.urlAfterRedirects.split('?')[0];
          e.isActive = e.link.some(item=> item=== val.urlAfterRedirects.split('?')[0]);
      });
      }
   })
  }
  toggleSidenav(): void {
    this.isCollapsed = !this.isCollapsed;
  }


}
