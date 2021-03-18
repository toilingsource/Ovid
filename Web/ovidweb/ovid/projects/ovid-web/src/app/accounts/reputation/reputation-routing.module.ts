import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReputationComponent } from './reputation.component';

const routes: Routes = [{ path: '', component: ReputationComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReputationRoutingModule { }
