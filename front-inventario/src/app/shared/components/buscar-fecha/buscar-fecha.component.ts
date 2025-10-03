import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule,ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDividerModule} from '@angular/material/divider';
import {MatFormFieldModule} from '@angular/material/form-field';
import { RangoFechas } from '../../interface/rango-fechas.interface';
import { MatInputModule } from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
@Component({
  selector: 'shared-buscar-fecha',
  imports: [FormsModule, MatDatepickerModule,MatDividerModule,MatFormFieldModule,ReactiveFormsModule,MatInputModule,
    MatIconModule
  ],
  templateUrl: './buscar-fecha.component.html',
  styleUrl: './buscar-fecha.component.css'
})
export class BuscarFechaComponent {

readonly range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });

  transacionBusqueda: string = '';
  rangeFechas! : RangoFechas;
  @Input({required :true}) titleInput : string = "Transacción";
  @Output() searchPerformed = new EventEmitter<{ assetNumber?: string; rangeFechas?: RangoFechas }>();

  onSearch() {
    this.onClear();
    if (!this.transacionBusqueda) return;
    this.searchPerformed.emit({ assetNumber: this.transacionBusqueda });
  }

  onSerarchRangeDate(){
    if(!this.range.value.start || !this.range.value.end){
      return
    }
    this.onSerarchRangeDateClear();
    const fechas : RangoFechas = {
      inicio : this.range.value.start?.toISOString(),
      fin : this.range.value.end?.toISOString()
    }
    this.searchPerformed.emit({ rangeFechas: fechas})
  }
  onClear() {
    this.range.reset();
  }

  onSerarchRangeDateClear(){
    this.transacionBusqueda = '';
  }
}
