import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import { MatTableDataSource,MatTableModule } from '@angular/material/table';
import { ProductoListar } from '../../interface/producto-listar.interface';
import {MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import {MatIconModule} from '@angular/material/icon';
import { FiltroPaginadoModel } from '../../../shared/interface/filtrado-pagina.interface';
@Component({
  selector: 'tabla-productos',
  imports: [MatCardModule, MatPaginatorModule, MatTableModule,MatIconModule],
  templateUrl: './tabla-productos.component.html',
  styleUrl: './tabla-productos.component.css'
})
export class TablaProductosComponent {

    ngOnChanges() {
    this.tablaProductos = new MatTableDataSource(this.data);
  }
cambiarPagina(event: PageEvent) {
  const filtro : FiltroPaginadoModel  ={
        cantidad : event.pageSize,
        pagina : event.pageIndex+1,
        textoBusqueda : this.texto
      };
      this.numeroPagina = event.pageIndex;
      this.cantidadPorPaginado = event.pageSize
      this.filtroEmiter.emit(filtro);
}
SearchIdProducto(id :string) {
      this.searchId.emit(id);
}
EditIdProducto(id : string) {
      this.updateId.emit(id);
}
DeleteIdAntenna(id: string) {
  this.deleteId.emit(id);
}
  public tablaProductos = new MatTableDataSource<ProductoListar>();
  public columnas: string[] = ['nombre', 'descripcion', 'stock','acciones'];

  @Input() data: ProductoListar[] = [];
   cantidadPorPaginado: number = 10;
  @Input()  cantidadTotal :number = 0;
  @Output() filtroEmiter = new EventEmitter<FiltroPaginadoModel>();
  @Output() searchId = new EventEmitter<string>();
  @Output() deleteId = new EventEmitter<string>();
  @Output() updateId = new EventEmitter<string>();

 opcionesPaginado: number[] =[1,10,20,25]
 numeroPagina = 0;
 texto = '';




}
