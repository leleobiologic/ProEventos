import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constantes } from '../util/constantes';

@Pipe({
  name: 'HourFormatPipes'
})
export class HourFormatPipePipe extends DatePipe implements PipeTransform{

  override transform(value: any, args?: any): any {
    if (value != null || value != undefined)
    value = value.slice(11, 16);
    return value;
  }

}
