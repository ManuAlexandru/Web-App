import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerPageImagesComponent } from './trainer-page-images.component';

describe('TrainerPageImagesComponent', () => {
  let component: TrainerPageImagesComponent;
  let fixture: ComponentFixture<TrainerPageImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainerPageImagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainerPageImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
