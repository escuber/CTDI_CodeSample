import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';
import { ProductListComponent } from './product-list.component';
import { ProductFilterPipe } from './product-filter.pipe';
import { ProductService } from './product.service';
import  {  Component  }  from  '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
   CommonModule,
    RouterModule.forChild([
      { path: 'products/:style', component: ProductListComponent },
      { path: 'products', component: ProductListComponent }
    ])
  ],
  declarations: [
    ProductListComponent,

    ProductFilterPipe
  ],
  providers: [
    ProductService
  ]
})
export class ProductModule {}
