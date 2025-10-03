import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FiltroPaginadoModel } from '../../interface/filtrado-pagina.interface';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
@Component({
  selector: 'shared-generic-search-create',
  imports: [MatFormFieldModule,MatIconModule, MatInputModule,MatButtonModule],
  templateUrl: './generic-search-create.component.html',
  styleUrl: './generic-search-create.component.css'
})
export class GenericSearchCreateComponent {
  @Output() filtroEmiter = new EventEmitter<FiltroPaginadoModel>();
  @Output() Create = new EventEmitter<boolean>();
  @Input({required :true })
  title!:string;
  @Input({required :true })
  header!:string;

  public cantidadPorPaginado: number = 10;
  public numeroPagina = 0;
  public texto = '';

    applyFilter(event: any) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.texto = filterValue;
      const filtro: FiltroPaginadoModel = {
        cantidad: this.cantidadPorPaginado,
        pagina: 1,
        textoBusqueda: this.texto
      };

      this.numeroPagina = 0;
      this.filtroEmiter.emit(filtro);
    }
    public Crear(status: boolean){
      this.Create.emit(status);
    }
}
