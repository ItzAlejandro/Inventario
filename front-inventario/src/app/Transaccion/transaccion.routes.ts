import { Routes } from "@angular/router";
import { LayoutTransaccionComponent } from "./layout/layout-transaccion/layout-transaccion.component";
import { ListarTransaccionComponent } from "./pages/listar-transaccion/listar-transaccion.component";
import { CrearEditarTransaccionComponent } from "./pages/crear-editar-transaccion/crear-editar-transaccion.component";

export const TransaccionRoutes : Routes =[
  {path:'',
    component:LayoutTransaccionComponent,
    children:[
      { path:'',component:ListarTransaccionComponent,

      },
      { path:'crear-transaccion',component:CrearEditarTransaccionComponent},
      { path:'editar-transaccion/:id',component:CrearEditarTransaccionComponent},
      { path:'**',redirectTo:''}
      ]
   },
]
export default TransaccionRoutes;
