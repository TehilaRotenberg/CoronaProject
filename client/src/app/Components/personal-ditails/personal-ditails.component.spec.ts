import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalDitailsComponent } from './personal-ditails.component';

describe('PersonalDitailsComponent', () => {
  let component: PersonalDitailsComponent;
  let fixture: ComponentFixture<PersonalDitailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalDitailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalDitailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
