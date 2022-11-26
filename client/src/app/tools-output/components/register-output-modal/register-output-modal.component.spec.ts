import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterOutputModalComponent } from './register-output-modal.component';

describe('RegisterOutputModalComponent', () => {
  let component: RegisterOutputModalComponent;
  let fixture: ComponentFixture<RegisterOutputModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterOutputModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterOutputModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
