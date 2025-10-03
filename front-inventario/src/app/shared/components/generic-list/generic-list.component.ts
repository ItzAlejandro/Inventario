import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'shared-generic-list',
  imports: [MatCardModule],
  templateUrl: './generic-list.component.html',
  styleUrl: './generic-list.component.css'
})
export class GenericListComponent {
  @Input ({required:true})
  list:any;

  @Input({required:true})
  title!:string;
}
