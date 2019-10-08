//import { Component, OnInit }  from '@angular/core';
import {
  Component,
  OnInit,
  OnChanges,
  Input,
  ViewChild,
  Output,
  EventEmitter
} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

//import { Subscription }       from 'rxjs/Subscription';

import { IProduct } from './products';
import { ProductService } from './product.service';

@Component({
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    pageTitle: string = 'Product List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = false;
    listFilter: string="";
    style:string="tile";
    private sub_style: any;

    errorMessage: string;

    products: IProduct[];

    constructor(private _route: ActivatedRoute,
      private _router: Router,private _productService: ProductService) {    }

     values = '';
     onKey(event: any) {
      this.listFilter = event;
    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
      let self=this;
        this._productService.getProducts()
                .subscribe(products => this.products = products);

                this.sub_style = this._route.params.subscribe(
                  params => {
                    self.style= params['style'];

              });
    }

}
