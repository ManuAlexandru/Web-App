import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPageTrainersComponent } from './owner-page-trainers.component';

describe('OwnerPageTrainersComponent', () => {
  let component: OwnerPageTrainersComponent;
  let fixture: ComponentFixture<OwnerPageTrainersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerPageTrainersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerPageTrainersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
