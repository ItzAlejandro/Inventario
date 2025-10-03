import { Component, inject, OnInit } from '@angular/core';
import { GenericListComponent } from "../../../shared/components/generic-list/generic-list.component";
import { TablaProductosComponent } from "../../component/tabla-productos/tabla-productos.component";
import { ProductoListar } from '../../interface/producto-listar.interface';
import { FiltroPaginadoModel } from '../../../shared/interface/filtrado-pagina.interface';
import { ProductosService } from '../../service/productos.service';
import { GenericSearchCreateComponent } from "../../../shared/components/generic-search-create/generic-search-create.component";
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponentComponent } from '../../component/dialog-component/dialog-component.component';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { SweetAlertComponent } from '../../../shared/components/sweet-alert/sweet-alert.component';

@Component({
  selector: 'app-listar-productos',
  imports: [GenericListComponent, TablaProductosComponent, GenericSearchCreateComponent,MatFormFieldModule],
  templateUrl: './listar-productos.component.html',
  styleUrl: './listar-productos.component.css'
})
export class ListarProductosComponent implements OnInit {

  private readonly router = inject(Router)
  private readonly sweet= new SweetAlertComponent();

RedirectUrl(status : boolean) {
 if(!status)return
    this.router.navigate(['/producto/crear-producto']);

}
    private readonly service = inject(ProductosService)

  ngOnInit(): void {
      this.ListarProductos();

  }

  public ListarProductos(): void{
    this.service.ListarProductos(this.paginacion).subscribe({
              next:(resp)=>{
                        this.listaProductos=resp.data.elemento;
                        this.cantidadTotal = resp.data.cantidadTotal;
                  },
                  error:(error)=>{
                    this.listaProductos = [];
                  }
            })
  }

onPageChange(filtro: FiltroPaginadoModel) {
    this.paginacion=filtro;
    this.ListarProductos();
}

  public EliminarProducto(id : string){
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¡No podrás revertir esto!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {


        this.service.EliminarProducto(id).subscribe({
              next:(resp)=>{
                    if(resp.success){
                      this.ListarProductos();
                        Swal.fire(
                          'Eliminado',
                          'El registro ha sido eliminado.',
                          'success'
                        );
                    }else{
                      Swal.fire(
                          'No se Eliminado',
                          resp.message,
                          'warning'
                        );
                    }
                  },
                  error:(error)=>{
                    this.listaProductos = [];
                    this.sweet.sweetError('Existio un Error',error.message)
                  }
            })

      }
    });
  }

RedirecUpdatetUrl(id: string) {
  this.router.navigate(['/producto/editar-producto', id]);
}
RedirecSearchUrl(id :string) {
  this.openDialog(id);
}
  paginacion: FiltroPaginadoModel ={ pagina:1, cantidad: 10, textoBusqueda: ''}
  public cantidadTotal = 0;
  listaProductos!:ProductoListar[];

   readonly dialog = inject(MatDialog);

  openDialog(id : string) {
    const dialogRef = this.dialog.open(DialogComponentComponent,
      {
        data : id
      }
    );

    dialogRef.afterClosed().subscribe(result => {
    });
  }
}
