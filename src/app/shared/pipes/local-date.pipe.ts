/**
  * Usage: dateString | localDate:'format'
 **/
import { Pipe, PipeTransform } from '@angular/core';
import { formatDate } from '@angular/common';
import { SessionLocalService } from '../services/session-locale.service';

@Pipe({
    name: 'localDate'
})
export class LocalDatePipe implements PipeTransform {

    constructor(   private localService: SessionLocalService) { }
    transform(value: any, format: string) {

        if (!value) { return ''; }


        // let find = '/';
        // let re = new RegExp(find, 'g');
        // let dt =  value.replace(re, '').substring(0, 8);



        if (!format) { format = 'shortDate'; }

        return formatDate(value, format, this.localService.locale);
    }
}
