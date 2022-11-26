import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolsOutputComponent } from './tools-output.component';

describe('ToolsOutputComponent', () => {
  let component: ToolsOutputComponent;
  let fixture: ComponentFixture<ToolsOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToolsOutputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToolsOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
