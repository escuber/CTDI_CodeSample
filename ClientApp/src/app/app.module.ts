import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

import { MyMaterialModule } from './material.module';
import { MatSidenavModule, MatListModule } from '@angular/material';
import { MatGridListModule } from '@angular/material/grid-list';
import { ErrorComponent } from './error.component';
import { ProductModule } from './products/product.module';



@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent
  ],
  imports: [HttpClientModule,
    ProductModule,
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MyMaterialModule,
    FormsModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule
  ],
  entryComponents: [ErrorComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
