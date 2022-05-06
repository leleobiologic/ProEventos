import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constantes } from '../util/constantes';

@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipe  extends DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    value = value.slice(0, 16);
    // return super.transform(value);
    return value;
  }

}
