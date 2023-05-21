import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPageHomeComponent } from './owner-page-home.component';

describe('OwnerPageHomeComponent', () => {
  let component: OwnerPageHomeComponent;
  let fixture: ComponentFixture<OwnerPageHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerPageHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerPageHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
