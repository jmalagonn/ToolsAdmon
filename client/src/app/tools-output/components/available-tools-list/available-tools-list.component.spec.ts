import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableToolsListComponent } from './available-tools-list.component';

describe('AvailableToolsListComponent', () => {
  let component: AvailableToolsListComponent;
  let fixture: ComponentFixture<AvailableToolsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvailableToolsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvailableToolsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
