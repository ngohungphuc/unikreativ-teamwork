import { DataHandlerService, HttpClientService, PushService, Toastr_Token } from './index'
import { NgModule } from '@angular/core'
import './rxjs-extensions'
declare let toastr: any
@NgModule({
  providers: [
    HttpClientService,
    DataHandlerService,
    PushService, 
    { provide : Toastr_Token , useValue : toastr }
  ]
})
export class ServicesModule {}