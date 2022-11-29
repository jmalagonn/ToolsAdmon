import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxQRCodeModule } from '@techiediaries/ngx-qrcode';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { ToDropdownItemPipe } from './pipes/to-dropdown-item.pipe';
import { LastCharactersPipe } from './pipes/last-characters.pipe';
import { OutputToolStatePipe } from './pipes/output-tool-state.pipe';

@NgModule({
  declarations: [
    DropdownComponent,
    ToDropdownItemPipe,
    LastCharactersPipe,
    OutputToolStatePipe
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    NgxQRCodeModule,
    BsDropdownModule.forRoot(),
  ],
  exports: [
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    NgxQRCodeModule,
    BsDropdownModule,
    DropdownComponent,
    ToDropdownItemPipe,
    LastCharactersPipe,
    OutputToolStatePipe
  ]
})
export class SharedModule { }
