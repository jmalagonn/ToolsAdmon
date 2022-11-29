import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolsOutputDetailComponent } from './tools-output-detail.component';

describe('ToolsOutputDetailComponent', () => {
  let component: ToolsOutputDetailComponent;
  let fixture: ComponentFixture<ToolsOutputDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToolsOutputDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToolsOutputDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
