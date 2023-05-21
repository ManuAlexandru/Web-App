import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPageImagesComponent } from './owner-page-images.component';

describe('OwnerPageImagesComponent', () => {
  let component: OwnerPageImagesComponent;
  let fixture: ComponentFixture<OwnerPageImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerPageImagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerPageImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
