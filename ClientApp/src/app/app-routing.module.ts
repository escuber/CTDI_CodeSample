import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductModule } from './products/product.module';

const routes: Routes =
 [
  { path: '**', redirectTo: '/products', pathMatch: 'full' },
  { path:  '',  redirectTo:  '/products',  pathMatch:  'full'  }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
