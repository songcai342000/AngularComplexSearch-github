import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { SearchDashboardComponent } from './search-dashboard.component';
import { SearchComponent } from './search/search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


const routes: Routes = [
  { path: '', component: SearchDashboardComponent }
];

@NgModule({
  declarations: [
    SearchDashboardComponent,
    SearchComponent
  ],
  imports: [
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
    RouterModule.forChild(routes)
  ]
})
export class SearchDashboardModule { }
