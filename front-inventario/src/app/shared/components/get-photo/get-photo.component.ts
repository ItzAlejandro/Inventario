import { Component, EventEmitter, Input, Output } from '@angular/core';
import { toBase64 } from '../../Funciones/toBase64';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatIconModule} from '@angular/material/icon';
import { NgIf } from '@angular/common';
@Component({
  selector: 'shared-get-photo',
  imports: [MatTooltipModule, MatIconModule, NgIf],
  templateUrl: './get-photo.component.html',
  styleUrl: './get-photo.component.css'
})
export class GetPhotoComponent {

  @Input ({required:true})
  titulo! : string;
  @Input ({required:true})
  loadingButton : boolean=false;

  @Input()
  urlCurrentImage? :string;

  @Output()
    selectedFile = new EventEmitter<File>();


  imageBase64? : string;

  update(event:Event){
    const input = event.target as HTMLInputElement;
    if(input.files && input.files.length>0){
        const file : File = input.files[0];
        toBase64(file).then((valor : string ) => this.imageBase64 = valor )
          .catch(error => console.log(error));
         this.selectedFile.emit(file);
         this.urlCurrentImage = undefined;
      }
  }

}
