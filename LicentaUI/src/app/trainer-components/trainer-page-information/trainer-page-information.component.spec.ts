import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerPageInformationComponent } from './trainer-page-information.component';

describe('TrainerPageInformationComponent', () => {
  let component: TrainerPageInformationComponent;
  let fixture: ComponentFixture<TrainerPageInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainerPageInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainerPageInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
