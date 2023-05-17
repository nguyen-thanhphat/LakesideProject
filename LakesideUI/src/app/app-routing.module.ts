import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

const userModule = () => import('./user/user.module').then(x => x.UserModule);
const adminModule = () => import('./admin/admin.module').then(a => a.AdminModule);

const routes: Routes = [
  { path: '', loadChildren: userModule},
  { path: 'dashboard', loadChildren: adminModule},

  //Lỗi
  { path: '**', component: NotFoundComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
