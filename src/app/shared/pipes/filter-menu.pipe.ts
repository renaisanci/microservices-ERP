import { Pipe, PipeTransform } from '@angular/core';
import { Menu } from 'src/app/models/menu';

// tslint:disable no-bitwise
@Pipe({ name: 'filterBy' })
export class FilterByPipe implements PipeTransform {
menulist: Menu[];
iok: boolean;
jok: boolean;
lok: boolean;


  transform(itemList: Menu[], searchKeyword: string) {
    if (!itemList) {
      return [];
    }
    if (!searchKeyword) {
      return itemList;
    }
    const filteredList = [];

    if (itemList.length > 0) {
      searchKeyword = searchKeyword.toLowerCase();

      for ( let i = 0; i < itemList.length; i++) {


            this.iok = false;
            this.jok = false;
            this.lok = false;

        if (itemList[i].DescMenu.toString().toLowerCase().indexOf(searchKeyword) > -1 && this.iok === false) {
          filteredList.push(itemList[i]);
          this.jok = true;
          this.lok = true;
        }

        if (itemList[i].Children.length > 0 && this.jok === false) {
        for ( let j = 0; j < itemList[i].Children.length; j++) {

          if (itemList[i].Children[j].DescMenu.toString().toLowerCase().indexOf(searchKeyword) > -1 ) {
            filteredList.push(itemList[i]);

            this.lok = true;

          }
          if (itemList[i].Children[j].Children.length > 0 && this.lok === false) {
          for ( let l = 0; l < itemList[i].Children[j].Children.length; l++) {

            if (itemList[i].Children[j].Children[l].DescMenu.toString().toLowerCase().indexOf(searchKeyword) > -1  ) {
              filteredList.push(itemList[i]);
            }

          }
        }
        }
      }

      }

    }
    return filteredList;
  }
}
