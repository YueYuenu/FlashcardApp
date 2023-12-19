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
import { DeckInfoComponent } from '../deck-info/deck-info.component';
import { PractisePageComponent } from '../practise-page/practise-page.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  // Flashcards
  { path: 'flashcardslist', component: ListFlashcardsComponent },
  { path: 'deckdetails/:deckId/add-flashcards', component: AddFlashcardsComponent },
  { path: 'carddetails/:cardid', component: EditFlashcardsComponent },
  { path: 'deleteflashcards', component: DeleteFlashcardsComponent },
  { path: 'deckdetails/:deckId/practise', component: PractisePageComponent },
  // Decks
  { path: 'decklist', component: ListDecksComponent },
  { path: 'deckdetails/:deckId', component:DeckInfoComponent },
  { path: 'decklist/add-deck', component: AddDeckComponent },
  { path: 'deckdetails/:deckId/editdeck', component: EditCardDeckComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },

]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes, { bindToComponentInputs: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }