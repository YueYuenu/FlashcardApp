import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCommonModule } from '@angular/material/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule as MatButtonModule} from '@angular/material/button';
import {MatMenuModule as MatMenuModule} from '@angular/material/menu';
import {MatInputModule as MatInputModule} from '@angular/material/input';
import {MatSnackBarModule as MatSnackBarModule} from '@angular/material/snack-bar';
import {MatFormFieldModule as MatFormFieldModule} from '@angular/material/form-field';
import { MatTableModule as MatTableModule } from '@angular/material/table'
import {MatPaginatorModule as MatPaginatorModule} from '@angular/material/paginator';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    MatCommonModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatInputModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatTableModule,
    MatPaginatorModule,
  ]
})
export class AppMaterialModule { }