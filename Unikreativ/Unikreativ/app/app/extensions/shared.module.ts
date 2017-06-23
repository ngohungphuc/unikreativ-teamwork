import { DataHandlerService, HttpClientService, Toastr_Token } from './index'
import { NgModule } from '@angular/core'
import './rxjs-extensions'
declare let toastr: any
@NgModule({
  providers: [
    HttpClientService,
    DataHandlerService, 
    { provide : Toastr_Token , useValue : toastr }
  ]
})
export class ServicesModule {}