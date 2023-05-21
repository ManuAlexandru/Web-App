import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleModelComponent } from './role-model.component';

describe('RoleModelComponent', () => {
  let component: RoleModelComponent;
  let fixture: ComponentFixture<RoleModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RoleModelComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(RoleModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
