import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { ListFlashcardsComponent } from '../list-flashcards/list-flashcards.component';
import { AddFlashcardsComponent } from '../add-flashcards/add-flashcards.component';
import { EditFlashcardsComponent } from '../edit-flashcards/edit-flashcards.component';
import { DeleteFlashcardsComponent } from '../delete-flashcards/delete-flashcards.component';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { ListDecksComponent } from '../list-decks/list-decks.component';
import { EditCardDeckComponent } from '../edit-card-deck/edit-card-deck.component';
import { AddDeckComponent } from '../add-deck/add-deck.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'flashcardslist', component: ListFlashcardsComponent },
  { path: 'add-flashcards', component: AddFlashcardsComponent },
  { path: 'add-deck', component: AddDeckComponent},
  { path: 'decklist', component: ListDecksComponent},
  { path: 'carddetails/:id', component: EditFlashcardsComponent },
  { path: 'deckdetails/:id', component: EditCardDeckComponent},
  { path: 'deleteflashcards', component: DeleteFlashcardsComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },

]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }