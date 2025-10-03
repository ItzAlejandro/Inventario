import { Component } from '@angular/core';
import { SidenavComponent } from "../../../shared/components/sidenav/sidenav.component";
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-layout-productos',
  imports: [SidenavComponent, RouterModule],
  templateUrl: './layout-productos.component.html',
  styleUrl: './layout-productos.component.css'
})
export class LayoutProductosComponent {

}
