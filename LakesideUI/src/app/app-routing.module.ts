import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './admin/login/login.component';

const userModule = () => import('./user/user.module').then(x => x.UserModule);
const adminModule = () => import('./admin/admin.module').then(a => a.AdminModule);

const routes: Routes = [
  { path: '', loadChildren: userModule},
  { path: 'dashboard', loadChildren: adminModule},
  {
    path:'login',
    component: LoginComponent
  },

  //Lỗi
  { path: '**', component: NotFoundComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
