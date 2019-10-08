import { IProduct } from './products';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { Injectable } from '@angular/core';


@Injectable()
export class ProductService {
  private _productUrl ='http://localhost:8099/api/catalog';

    constructor(private http: HttpClient) { }
    getProducts()
    {
         return this.http.get(this._productUrl)
         .pipe(
          map((data: any) => {
            if(data)
            {
            return data.map(
              (entry: IProduct) =>
                (entry as IProduct)
            );
            }
            return null;
          }));
    }
}
