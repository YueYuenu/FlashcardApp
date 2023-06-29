import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { ListFlashcardsComponent } from '../list-flashcards/list-flashcards.component';
import { AddFlashcardsComponent } from '../add-flashcards/add-flashcards.component';
import { EditFlashcardsComponent } from '../edit-flashcards/edit-flashcards.component';
import { DeleteFlashcardsComponent } from '../delete-flashcards/delete-flashcards.component';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'listFlashcards', component: ListFlashcardsComponent },
  { path: 'addFlashcards', component: AddFlashcardsComponent },
  { path: 'editFlashcards', component: EditFlashcardsComponent },
  { path: 'deleteFlashcards', component: DeleteFlashcardsComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },

]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
