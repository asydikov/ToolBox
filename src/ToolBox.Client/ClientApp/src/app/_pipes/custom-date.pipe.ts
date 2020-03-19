import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'customDate'
})
export class CustomDatePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    if(!value){
      return 'Never'
    }else{
     return  new DatePipe('en-GB').transform(value, 'dd.MM.yy HH:mm');
    }
  }

}
