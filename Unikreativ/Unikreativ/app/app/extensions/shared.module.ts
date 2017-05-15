import './rxjs-extensions'
import { NgModule } from '@angular/core'
import { HttpClientService } from './http-extensions'
@NgModule({
  providers: [HttpClientService]
})
export class ServicesModule {}