import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
const routes: Routes = [
  
  // the path url calls the component using router
  // app-component.html calls router-outlet which calls HomeComponent initially.
  {path: "", component: HomeComponent},
  {path: "users/:id", component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
