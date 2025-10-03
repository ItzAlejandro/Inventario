import { Component } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sweet-alert',
  imports: [],
  templateUrl: './sweet-alert.component.html',
  styleUrl: './sweet-alert.component.css'
})
export class SweetAlertComponent {
sweetCorrecto(titulo:string,mensaje :string):void{
    Swal.fire({
      title: titulo,
      text: mensaje,
      icon: "success"
    });
  }

    sweetCorrectoButton(titulo:string,mensaje :string):void{
    Swal.fire({
      title: titulo,
      text: mensaje,
      icon: "success",
      draggable: true
    });
  }

  sweetWarning(titulo:string,mensaje :string):void{
    Swal.fire({
      title: titulo,
      text: mensaje,
      icon: "warning"
    });
  }


  sweetError(titulo:string,mensaje :string):void{
    Swal.fire({
      title: titulo,
      text: mensaje,
      icon: "error"
    });
  }
}
