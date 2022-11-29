import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { OutputTool } from 'src/app/Core/models/Output-tool.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-tools-output-detail',
  templateUrl: './tools-output-detail.component.html',
  styleUrls: ['./tools-output-detail.component.scss']
})
export class ToolsOutputDetailComponent implements OnInit {
  outputTool?: OutputTool;

  constructor(
    private route: ActivatedRoute,
    private httpService: HttpService) {}

  ngOnInit(): void {
    this.getOutputTool();
  };

  getOutputTool(): void {    
    const outputToolId = this.route.snapshot.paramMap.get('id');

    this.httpService.get<OutputTool>(`OutputTools/${outputToolId}`)
      .subscribe(response => this.outputTool = response);
  }
}
