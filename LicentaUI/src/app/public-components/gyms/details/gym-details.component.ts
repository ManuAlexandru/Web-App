import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { GymModel } from 'src/app/module/models/gymModel';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';

@Component({
  selector: 'gym-details',
  templateUrl: './gym-details.component.html',
})
export class GymDetailsComponent implements OnInit {
  public gym: GymModel = new GymModel();
  gymId: string = '';
  constructor(
    private _gymService: OwnerGymServices,
    private _router: Router,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.refreshPage(this.getId());
  }

  getId() {
    this.gymId = this._router.url.split('/')[2];

    return this.gymId;
  }

  getMapImageUrl() {
    if (this.gym.addres == '' || this.gym.city == '' || this.gym.country == '')
      return;
    // Construct the URL of the static map image
    const baseUrl = 'https://maps.googleapis.com/maps/api/staticmap';
    const params = [
      `size=224x224`,
      `scale=2`,
      `maptype=roadmap`,
      `markers=color:red|label:A|${this.gym.addres},${this.gym.city},${this.gym.country}`,
      `key=EnterYourKeyHere`,
    ];
    const url = `${baseUrl}?${params.join('&')}`;

    // Sanitize the URL to avoid security risks
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }

  refreshPage(id: string) {
    this._gymService.getGym(id).subscribe((res: GymModel) => {
      this.gym = res;
      console.log('Gym', res);
    });
  }
}
