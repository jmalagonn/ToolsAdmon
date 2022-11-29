import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenToolsOutputListComponent } from './open-tools-output-list.component';

describe('OpenToolsOutputListComponent', () => {
  let component: OpenToolsOutputListComponent;
  let fixture: ComponentFixture<OpenToolsOutputListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenToolsOutputListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpenToolsOutputListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
