import './rxjs-extensions'
import { NgModule } from '@angular/core'
import { HttpClientService } from './http-extensions'
import { DataHandlerService } from './services-handler'
@NgModule({
  providers: [HttpClientService,DataHandlerService]
})
export class ServicesModule {}