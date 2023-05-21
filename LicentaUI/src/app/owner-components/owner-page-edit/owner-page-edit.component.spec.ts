import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPageEditComponent } from './owner-page-edit.component';

describe('OwnerPageEditComponent', () => {
  let component: OwnerPageEditComponent;
  let fixture: ComponentFixture<OwnerPageEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerPageEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerPageEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
