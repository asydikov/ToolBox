import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
 
//   { path: '' },
  // { path: 'cards', component: CardComponent, canActivate: [AuthGuard] },
  // { path: 'notes', component: NoteComponent, canActivate: [AuthGuard] },
  // { path: 'notes/:id', component: NoteComponent, canActivate: [AuthGuard] },
  // { path: 'regirstration', component: RegisterComponent },
  // { path: '**', component: CardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class SqlMonitorRoutingModule { }
