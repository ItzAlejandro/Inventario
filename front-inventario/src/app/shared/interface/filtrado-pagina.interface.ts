export interface FiltroPaginadoModel {
  pagina: number;
  cantidad: number;
  textoBusqueda?: string;
}

export interface FiltroPaginadoResult<T> {
  cantidadTotal: number;
  elemento: T;
}
