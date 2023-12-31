import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { HomeComponent } from './home/home.component';
import { AppMaterialModule } from './app-material/app-material.module';
import { ListFlashcardsComponent } from './list-flashcards/list-flashcards.component';
import { AddFlashcardsComponent } from './add-flashcards/add-flashcards.component';
import { EditFlashcardsComponent } from './edit-flashcards/edit-flashcards.component';
import { DeleteFlashcardsComponent } from './delete-flashcards/delete-flashcards.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListDecksComponent } from './list-decks/list-decks.component';
import { EditCardDeckComponent } from './edit-card-deck/edit-card-deck.component';
import { AddDeckComponent } from './add-deck/add-deck.component';
import { DeckInfoComponent } from './deck-info/deck-info.component';

@NgModule({
    declarations: [
        AppComponent,
        ToolbarComponent,
        HomeComponent,
        ListFlashcardsComponent,
        AddFlashcardsComponent,
        EditFlashcardsComponent,
        DeleteFlashcardsComponent,
        PageNotFoundComponent,
        ListDecksComponent,
        EditCardDeckComponent,
        AddDeckComponent,
        DeckInfoComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        AppMaterialModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,

    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }