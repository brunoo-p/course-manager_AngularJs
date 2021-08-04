import { RouterModule } from '@angular/router';
import { NgModule } from "@angular/core";
import { NavbarComponent } from "./component/nav-bar/nav-bar.component";

@NgModule({
  declarations:[
    NavbarComponent
  ],
  imports:[
    RouterModule
  ],
  exports:[
    NavbarComponent
  ]
})
export class CoreModule {

}
