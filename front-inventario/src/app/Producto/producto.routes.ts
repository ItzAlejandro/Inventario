import { Routes } from "@angular/router";
import { LayoutProductosComponent } from "./layout/layout-productos/layout-productos.component";
import { ListarProductosComponent } from "./Pages/listar-productos/listar-productos.component";
import { CrearEditarProductosComponent } from "./Pages/crear-editar-productos/crear-editar-productos.component";


export const ProductosRoutes : Routes =[
  {path:'',
    component:LayoutProductosComponent,
    children:[
      { path:'',component:ListarProductosComponent,

      },
      { path:'crear-producto',component:CrearEditarProductosComponent},
      { path:'editar-producto/:id',component:CrearEditarProductosComponent},
      { path:'**',redirectTo:''}
      ]
   },
]
export default ProductosRoutes;
