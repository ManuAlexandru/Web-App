import { Pipe, PipeTransform } from '@angular/core';
import { GymModel } from 'src/app/module/models/gymModel';

@Pipe({
  name: 'filterGyms',
})
export class SearchPipe implements PipeTransform {
  public transform(gyms: GymModel[], filterText: string) {
    if (gyms.length === 0 || filterText === '') return gyms;
    else {
      return gyms.filter((product) => {
        return product.gymName.toLowerCase().includes(filterText);
      });
    }
  }
}
