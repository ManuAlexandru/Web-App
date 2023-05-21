import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerPageInformationComponent } from './owner-page-information.component';

describe('OwnerPageInformationComponent', () => {
  let component: OwnerPageInformationComponent;
  let fixture: ComponentFixture<OwnerPageInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerPageInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerPageInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
