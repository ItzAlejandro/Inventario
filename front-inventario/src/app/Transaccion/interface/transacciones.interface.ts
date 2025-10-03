
export interface CrearTransaccionesModelo {
  //id? : string;
  tipoTransaccion: number;
  idProducto: string;
  cantidad: number;
  precioUnitario: number;
  detalle?: string;
}
