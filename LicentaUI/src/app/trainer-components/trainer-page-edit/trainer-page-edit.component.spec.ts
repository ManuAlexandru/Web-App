import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerPageEditComponent } from './trainer-page-edit.component';

describe('TrainerPageEditComponent', () => {
  let component: TrainerPageEditComponent;
  let fixture: ComponentFixture<TrainerPageEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainerPageEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainerPageEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
