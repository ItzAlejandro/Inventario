import { inject, Injectable } from '@angular/core';
import { FiltroPaginadoModel, FiltroPaginadoResult } from '../../shared/interface/filtrado-pagina.interface';
import { ApiResponse } from '../../shared/interface/api-response.interface';
import { catchError, Observable, of } from 'rxjs';
import { ConsultaProductoCrearModel, ListarProductosTransaccionesModelo, ProductoCrearModel, ProductoListar, ProductoPorId } from '../interface/producto-listar.interface';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { extractErrors } from '../../shared/Funciones/extractErrors';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  private readonly url = environment.apiUrl;
  private readonly http = inject(HttpClient);
  private readonly urlTodosLosProductos: string = '/producto/ListarProductos';
  private readonly urlListarProductosTransacciones: string = '/producto/ProductosTransacciones';
  private readonly urlProductoPorId: string = '/producto?id=';
  private readonly urlProductoEditarPorId: string = '/producto/BuscarEditar?id=';
  private readonly urlCrearProducto: string = '/producto';
  private readonly urlActualizarProducto: string = '/producto/ActualizarProducto';
  private readonly urlEliminarProducto: string = '/producto/productoEliminar';


    public ListarProductos(filtro : FiltroPaginadoModel): Observable<ApiResponse<FiltroPaginadoResult<ProductoListar[]>>> {
        const params = {
          pagina: filtro.pagina,
          cantidad: filtro.cantidad,
          textoBusqueda: filtro.textoBusqueda ?? ''
        };
        return this.http.get<ApiResponse<FiltroPaginadoResult<ProductoListar[]>>>(`${this.url}${this.urlTodosLosProductos}`,{ params })
          .pipe(
            catchError((err) => {
              return this.errorResponseDTO(err);
            })
          );
      }

    public ListarProductosTransacciones(): Observable<ApiResponse<ListarProductosTransaccionesModelo[]>> {

        return this.http.get<ApiResponse<ListarProductosTransaccionesModelo[]>>(`${this.url}${this.urlListarProductosTransacciones}`)
          .pipe(
            catchError((err) => {
              return this.errorResponseDTO(err);
            })
          );
      }

  public ProductoByid(id : string): Observable<ApiResponse<ProductoPorId>> {

      return this.http
        .get<ApiResponse<ProductoPorId>>(`${this.url}${this.urlProductoPorId}${id}`)
        .pipe(
          catchError((err) => {
            const errores = extractErrors(err);
            err.error.data=errores;
            return this.errorResponseDTO(err);
          })
        );
    }
  public ProductoEditarByid(id : string): Observable<ApiResponse<ConsultaProductoCrearModel>> {

      return this.http
        .get<ApiResponse<ConsultaProductoCrearModel>>(`${this.url}${this.urlProductoEditarPorId}${id}`)
        .pipe(
          catchError((err) => {
            const errores = extractErrors(err);
            err.error.data=errores;
            return this.errorResponseDTO(err);
          })
        );
    }
    public CrearProducto(assetData : ProductoCrearModel): Observable<ApiResponse<boolean>> {
      const model = this.construirFormData(assetData);
      return this.http
        .post<ApiResponse<boolean>>(`${this.url}${this.urlCrearProducto}`,model)
        .pipe(
          catchError((err) => {
            const errores = extractErrors(err);
            err.error.data=errores;
            return this.errorResponseDTO(err);
          })
        );
    }

    public ActualizarProducto(assetData : ProductoCrearModel): Observable<ApiResponse<boolean>> {
      const model = this.construirFormData(assetData);
      return this.http
        .put<ApiResponse<boolean>>(`${this.url}${this.urlActualizarProducto}`,model)
        .pipe(
          catchError((err) => {
            const errores = extractErrors(err);
            err.error.data=errores;
            return this.errorResponseDTO(err);
          })
        );
    }


    public EliminarProducto(id: string): Observable<ApiResponse<boolean>> {

    return this.http.put<ApiResponse<boolean>> (this.url +this.urlEliminarProducto,
    JSON.stringify(id),
    {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      catchError((err) => {
        const errores = extractErrors(err);
        err.error.data=errores;
        const error = this.errorResponseDTO(err);
        return error;
      })
    );;
  }

    private construirFormData(producto:ProductoCrearModel): FormData{
      const formData = new FormData();
      if (producto.id != null) formData.append('model.id', producto.id.toString());
      if(producto.nombre)formData.append('model.nombre',producto.nombre);
      if(producto.descripcion)formData.append('model.descripcion',producto.descripcion);
      if(producto.categoria)formData.append('model.categoria',producto.categoria);
      if (producto.stock != null) formData.append('model.stock', producto.stock.toString());
      if (producto.precio != null) formData.append('model.precio', producto.precio.toString());
      if(producto.imagen)formData.append('model.imagen',producto.imagen);
      return formData;
    }
         errorResponseDTO(err: any): Observable<ApiResponse<any>>  {
              const response: ApiResponse<any> = {
                success: err.error.success,
                message: err.error.message,
                statusCode : err.error.statusCode,
                data : null
              };
              return of(response);
            }
}
