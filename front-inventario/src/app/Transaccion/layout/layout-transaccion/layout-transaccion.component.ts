import { Component } from '@angular/core';
import { SidenavComponent } from "../../../shared/components/sidenav/sidenav.component";
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-layout-transaccion',
  imports: [SidenavComponent, RouterModule],
  templateUrl: './layout-transaccion.component.html',
  styleUrl: './layout-transaccion.component.css'
})
export class LayoutTransaccionComponent {

}
