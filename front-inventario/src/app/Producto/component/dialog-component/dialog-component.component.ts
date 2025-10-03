import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef,MatDialogModule } from '@angular/material/dialog';
import { ProductosService } from '../../service/productos.service';
import { ProductoPorId } from '../../interface/producto-listar.interface';
import {MatListModule} from '@angular/material/list';
import { DatePipe, NgIf } from '@angular/common';
@Component({
  selector: 'app-dialog-component',
  imports: [MatDialogModule,MatListModule, NgIf,DatePipe],
  templateUrl: './dialog-component.component.html',
  styleUrl: './dialog-component.component.css'
})
export class DialogComponentComponent implements OnInit {
  private readonly service = inject(ProductosService);
  readonly dialogRef = inject(MatDialogRef<DialogComponentComponent>);
  readonly data = inject<string>(MAT_DIALOG_DATA);
  readonly idProducto = this.data;
  public producto! :ProductoPorId;
  private readonly cdr = inject(ChangeDetectorRef);

  ngOnInit(): void {
    this.VerProducto(this.idProducto);
  }


  public VerProducto(id : string) : void{
    this.service.ProductoByid(id).subscribe({
      next : (resp)=>{
        if(resp.success){
          this.producto = resp.data;
          this.cdr.detectChanges();
        }else{
          this.dialogRef.close();
        }
      },
      error : (err) =>{

      }
    })
  }
}
