import { Routes } from '@angular/router';

export const routes: Routes = [

  {path:'producto', loadChildren:()=>import('./Producto/producto.routes')},
  {path:'transaccion', loadChildren:()=>import('./Transaccion/transaccion.routes')},
  {path: '**', redirectTo: 'producto', pathMatch: 'full' },
  {path: '', redirectTo: 'producto', pathMatch: 'full' },
];
