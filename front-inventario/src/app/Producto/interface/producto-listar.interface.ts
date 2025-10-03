export interface ProductoListar{
  id : string;
  nombre : string;
  descripcion? : string;
  stock : number;
}

export interface ProductoPorId{
  nombre : string;
  descripcion? : string;
  categoria : string;
  imagen? : string;
  fechaCreacion : Date;
  precio : number
  stock : number;
}

export interface ProductoCrearModel {
  id? : string;
  nombre: string;
  descripcion?: string;
  categoria?: string;
  imagen?: File;
  precio: number;
  stock: number;
}
export interface ConsultaProductoCrearModel {
  id? : string;
  nombre: string;
  descripcion?: string;
  categoria?: string;
  imagen?: string;
  precio: number;
  stock: number;
}

export interface ListarProductosTransaccionesModelo {
  id: string;
  nombre: string;
  stock: number;
  precio: number;
}
