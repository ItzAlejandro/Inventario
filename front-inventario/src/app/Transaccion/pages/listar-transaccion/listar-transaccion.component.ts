import { Component } from '@angular/core';
import { BuscarFechaComponent } from "../../../shared/components/buscar-fecha/buscar-fecha.component";
import { RangoFechas } from '../../../shared/interface/rango-fechas.interface';
import { FiltroPaginadoModel } from '../../../shared/interface/filtrado-pagina.interface';
import { GenericListComponent } from "../../../shared/components/generic-list/generic-list.component";

@Component({
  selector: 'app-listar-transaccion',
  imports: [BuscarFechaComponent, GenericListComponent],
  templateUrl: './listar-transaccion.component.html',
  styleUrl: './listar-transaccion.component.css'
})
export class ListarTransaccionComponent {
  paginacion: FiltroPaginadoModel ={ pagina:1, cantidad: 10, textoBusqueda: ''}
  public searchParams: { transaccionTipo?: string; } = {};
  public rangeDate! :RangoFechas;
  public historialTransacciones:any =[];

  handleSearch(params: { transaccionTipo?: string;  rangeFechas?: RangoFechas }) {
    this.searchParams = params;
    let valor: string ;
    let tipo: number;
    let timeStarAndEnd : RangoFechas;
    this.paginacion={
      pagina:1, cantidad: 10, textoBusqueda: ''
    }

    if (params.transaccionTipo) {
      valor = params.transaccionTipo;
      tipo = 1;
    } else if (params.rangeFechas)  {
      timeStarAndEnd = params.rangeFechas;
      this.rangeDate =timeStarAndEnd;
      return;
    }else{
      return;
    }
  }
}
