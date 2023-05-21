import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerProgramComponent } from './trainer-program.component';

describe('TrainerProgramComponent', () => {
  let component: TrainerProgramComponent;
  let fixture: ComponentFixture<TrainerProgramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainerProgramComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainerProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
