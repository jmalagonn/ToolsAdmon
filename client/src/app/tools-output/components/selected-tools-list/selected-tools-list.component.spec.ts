import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedToolsListComponent } from './selected-tools-list.component';

describe('SelectedToolsListComponent', () => {
  let component: SelectedToolsListComponent;
  let fixture: ComponentFixture<SelectedToolsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectedToolsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectedToolsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
