import './rxjs-extensions'
import { NgModule } from '@angular/core'
import { HttpClientService, Toastr_Token, DataHandlerService } from './index'
declare let toastr: any
@NgModule({
  providers: [
    HttpClientService,
    DataHandlerService, 
    { provide : Toastr_Token , useValue : toastr }
  ]
})
export class ServicesModule {}