import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of } from 'rxjs';
import { ApiResponse } from '../../shared/interface/api-response.interface';
import { extractErrors } from '../../shared/Funciones/extractErrors';
import { CrearTransaccionesModelo } from '../interface/transacciones.interface';

@Injectable({
  providedIn: 'root'
})
export class TransaccionService {
  private readonly url = environment.apiTransaccion;
  private readonly http = inject(HttpClient);

  private readonly urlCrearTransaccion: string = '/transaccion';


    public CrearProducto(model : CrearTransaccionesModelo): Observable<ApiResponse<boolean>> {
      return this.http
        .post<ApiResponse<boolean>>(`${this.url}${this.urlCrearTransaccion}`,model)
        .pipe(
          catchError((err) => {
            const errores = extractErrors(err);
            err.error.data=errores;
            return this.errorResponseDTO(err);
          })
        );
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
