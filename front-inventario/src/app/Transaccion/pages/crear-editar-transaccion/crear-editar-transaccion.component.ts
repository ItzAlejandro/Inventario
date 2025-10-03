import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder,  FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductosService } from '../../../Producto/service/productos.service';
import { ListarProductosTransaccionesModelo } from '../../../Producto/interface/producto-listar.interface';
import { CrearTransaccionesModelo } from '../../interface/transacciones.interface';
import { TransaccionService } from '../../service/transaccion.service';

@Component({
  selector: 'app-crear-editar-transaccion',
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, MatSlideToggleModule, ReactiveFormsModule,
    MatButtonModule, MatIconModule],
  templateUrl: './crear-editar-transaccion.component.html',
  styleUrl: './crear-editar-transaccion.component.css'
})
export class CrearEditarTransaccionComponent implements OnInit{

  private readonly fb= inject(FormBuilder);
  private readonly servicioProducto= inject(ProductosService);
  private readonly service= inject(TransaccionService);
  public title : string = "Crear";
  public id! : string;
  public productos : ListarProductosTransaccionesModelo[] = [] ;
  public producto! : ListarProductosTransaccionesModelo ;
  private readonly activatedRouter = inject(ActivatedRoute)
  private readonly router = inject(Router);

    public transaccionForm :FormGroup = this.fb.group({
      tipoTransaccion: ['', Validators.required],
      producto: ['', Validators.required],
      detalle: ['', Validators.maxLength(250)],
      precio: [0, [Validators.required, Validators.min(0)]],
      cantidad: [null,[Validators.required,Validators.min(1),Validators.pattern(/^[0-9]+$/)]],
      stock: ['', [Validators.required, Validators.min(0)]],
      precioTotal: ['', [Validators.required]]
    });


  ngOnInit(): void {
    this.ListarProductosTransacciones();
    const idParam = this.activatedRouter.snapshot.paramMap.get('id');
              if (idParam !== null) {
                  this.id = idParam;
              }
              if(this.id){
                this.title="Editar"

                this.TransaccionPorId();
              }
  }

    public TransaccionPorId(){

    }

    public ListarProductosTransacciones(): void {

      this.servicioProducto.ListarProductosTransacciones().subscribe({
          next:(resp)=>{
              if(resp.success){
                this.productos = resp.data;
              }else{
              }
            },
            error:(error)=>{
            }
          })
    }
    public cargarInformacion(): void{
          const selectedId = this.transaccionForm.get('producto')?.value;
          if(!selectedId){
             this.transaccionForm.patchValue({
              precio: 0,
              stock : 0,
              precioTotal : 0,
              cantidad : 0
            });
              return;
          }
          this.producto = this.productos.find(pro => pro.id === selectedId)!;
         this.transaccionForm.patchValue({
            precio: this.producto.precio,
            stock : this.producto.stock
          });
    }



  Submit() {
    if (!this.transaccionForm.valid) {
       return;
     }

       if(this.id!=null){
           const formEditarTransaccion: CrearTransaccionesModelo={
                   //id : this.id.trim(),
                   tipoTransaccion: this.transaccionForm.value.tipoTransaccion,
                  idProducto: this.transaccionForm.value.producto,
                  cantidad: this.transaccionForm.value.cantidad,
                  precioUnitario:  this.transaccionForm.value.precio,
                  detalle: this.transaccionForm.value.detalle,
                 };
             this.Editar(formEditarTransaccion);
           }else{
               const formCrearTransaccion: CrearTransaccionesModelo={
                       tipoTransaccion: this.transaccionForm.value.tipoTransaccion,
                       idProducto: this.transaccionForm.value.producto,
                       cantidad: this.transaccionForm.value.cantidad,
                       precioUnitario:  this.transaccionForm.value.precio,
                       detalle: this.transaccionForm.value.detalle,
                     };
             this.Crear(formCrearTransaccion);
           }
  }


  Editar(formEditarTransaccion: CrearTransaccionesModelo) {
    throw new Error('Method not implemented.');
  }

  Crear(formCrearTransaccion: CrearTransaccionesModelo) {
      this.service.CrearProducto(formCrearTransaccion).subscribe({
            next:(resp)=>{
                if(resp.success){
                  this.router.navigate(['']);
                }else{
                }
              },
              error:(error)=>{
              }
        })
  }


  cancelbutton() {
  this.router.navigate(['/']);
  }

ValidarCantidad() {
  const cantidad = this.transaccionForm.get('cantidad')?.value;
  const tipoTransaccion = this.transaccionForm.get('tipoTransaccion')?.value;

    if (!/^[0-9]+$/.test(cantidad)) {
      cantidad?.setErrors({ notNumber: true });
      cantidad?.markAsTouched();
      return;
    }

  if (this.producto) {
    if (cantidad > this.producto.stock && tipoTransaccion != 1) {
      this.transaccionForm.get('cantidad')?.setErrors({ stock: true });
      this.transaccionForm.get('cantidad')?.markAsTouched();
      return;
    }

    const total = cantidad * this.producto.precio;
    this.transaccionForm.patchValue({ precioTotal: total });
  } else {
    this.transaccionForm.get('producto')?.setErrors({ required: true });
    this.transaccionForm.get('producto')?.markAsTouched();
  }
}

viewErrors(controlName: string, seudonimo: string): string {
  const control = this.transaccionForm.get(controlName);
  if (!control || !control.touched || control.valid) return '';

  if (control.hasError('min') && controlName === 'cantidad') {
    return `El campo ${seudonimo} NO permite valores menores que 1.`;
  }

  if (control.hasError('required')) {
    return `El campo ${seudonimo} es obligatorio.`;
  }

if (
  control.hasError('stock') &&
  controlName === 'cantidad' &&
  this.transaccionForm.get('tipoTransaccion')?.value === 2
) {
  return `La cantidad ingresada no puede ser mayor al stock disponible.`;
}

  return '';
}

}
