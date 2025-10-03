import { Component } from '@angular/core';
import { SidebarItem } from '../../interface/SidebarItem.interface';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatIconModule} from '@angular/material/icon';
@Component({
  selector: 'shared-sidenav',
  imports: [MatDividerModule,MatCardModule,MatSidenavModule, MatToolbarModule, MatListModule,RouterModule, CommonModule,
    MatIconModule
  ],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {


  public sidebar: SidebarItem[] = [
    {
      label: 'Productos',
      icon: 'edit',
      expanded: false,
      subitems: [
        { label: 'Gestionar Prod.', icon: 'edit', url: '/producto' },
      ]
    },
      {
      label: 'Transacciones',
      icon: 'edit',
      expanded: false,
      subitems: [
        { label: 'Crear Transacción', icon: 'edit', url: '/transaccion/crear-transaccion' },
        { label: 'Editar Transacción', icon: 'edit', url: '/transaccion/crear-transaccion'},
        { label: 'Historial Transacción', icon: 'edit', url: '/transaccion/listar'},
      ]
    }
  ];



  toggleSublist(item: SidebarItem): void {
    item.expanded = !item.expanded;
  }

}
