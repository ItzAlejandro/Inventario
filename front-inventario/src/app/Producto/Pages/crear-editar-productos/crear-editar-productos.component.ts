import { Component, inject, OnInit } from '@angular/core';
import { ProductoCrearModel } from '../../interface/producto-listar.interface';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductosService } from '../../service/productos.service';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { GetPhotoComponent } from "../../../shared/components/get-photo/get-photo.component";
import { JsonPipe } from '@angular/common';
@Component({
  selector: 'app-crear-editar-productos',
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, MatSlideToggleModule, ReactiveFormsModule,
    MatButtonModule, MatIconModule, GetPhotoComponent],
  templateUrl: './crear-editar-productos.component.html',
  styleUrl: './crear-editar-productos.component.css'
})
export class CrearEditarProductosComponent implements OnInit{

  private readonly activatedRouter = inject(ActivatedRoute)
  private readonly fb= inject(FormBuilder);
  public title : string = "Crear";
  public id! : string;
  private readonly router = inject(Router);
  private readonly service = inject(ProductosService);
  public isSubmitting = false;


  ngOnInit(): void {
    const idParam = this.activatedRouter.snapshot.paramMap.get('id');
              if (idParam !== null) {
                  this.id = idParam;
              }
              if(this.id){
                this.title="Editar"

                this.ProductoPorId();
              }
  }



  public imageUrlMoment! : string|undefined;
    public productoForm :FormGroup = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.maxLength(250)],
      categoria: ['', Validators.maxLength(250)],
      imagen: new FormControl<File | string |null>(null),
      precio: [0, [Validators.required, Validators.min(0)]],
      stock: ['', [Validators.required, Validators.min(0)]]
    });


  Submit(): void {
    if (!this.productoForm.valid) {
      return;
    }

      if(this.id!=null){
          const formEditProducto: ProductoCrearModel={
                  id : this.id.trim(),
                  nombre: this.productoForm.value.nombre.trim().toUpperCase(),
                  descripcion: this.productoForm.value.descripcion.trim().toUpperCase(),
                  categoria: this.productoForm.value.categoria.trim().toUpperCase(),
                  imagen:  this.productoForm.value.imagen instanceof File ? this.productoForm.value.imagen : undefined,
                  precio: this.productoForm.value.precio,
                  stock : this.productoForm.value.stock
                };
            this.Editar(formEditProducto);
          }else{
              const formCrearProducto: ProductoCrearModel={
                      nombre: this.productoForm.value.nombre.trim().toUpperCase(),
                      descripcion: this.productoForm.value.descripcion.trim().toUpperCase(),
                      categoria: this.productoForm.value.categoria.toString().trim().toUpperCase(),
                      imagen: this.productoForm.value.imagen instanceof File ? this.productoForm.value.imagen : undefined,
                      precio: this.productoForm.value.precio,
                      stock : this.productoForm.value.stock
                    };
            this.Crear(formCrearProducto);
          }
    }

    public ProductoPorId(){
     this.service.ProductoEditarByid(this.id).subscribe({
      next:(resp)=>{
          if(resp.success){
            this.imageUrlMoment = resp.data!.imagen;
           this.productoForm.patchValue({
              nombre : resp.data!.nombre,
              descripcion : resp.data!.descripcion,
              categoria : resp.data!.categoria,
              imagen : resp.data!.imagen,
              precio : resp.data!.precio,
              stock : resp.data!.stock
           })
          }else{
          }
        },
        error:(error)=>{
        }
      })
    }

    public Crear(model : ProductoCrearModel){
        this.service.CrearProducto(model).subscribe({
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

  public Editar(model : ProductoCrearModel){
    this.service.ActualizarProducto(model).subscribe({
        next:(resp)=>{
            if(resp.success){
              this.router.navigate(['/']);
            }else{
            }
          },
          error:(error)=>{
          }
    })
  }

  public cancelbutton() : void{
    this.router.navigate(['/']);
  }


  selectedFile(file :File ){
      this.productoForm.controls['imagen'].setValue(file);
  }

  SubmitFORM(){
    if(typeof this.imageUrlMoment =="string"){
        this.imageUrlMoment =undefined;
    }
  }


  viewErrors(controlName: string, seudonimo : string):string{
  const control = this.productoForm.get(controlName);
    if (!control || !control.touched || control.valid) return '';

    if (control.hasError('required') ) {
      return `El campo ${seudonimo} es obligatorio.`;
    }
    return '';
  }
}
