import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Flashcard from '../models/Flashcard';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FlashcardService {
    url: string = environment.apiUrl + 'flashcards/';
    constructor(private http: HttpClient) { }

    EditCard(editFlashcard: Flashcard): Observable<any> {
        return this.http.put<Flashcard>(this.url + 'update', editFlashcard, { observe: 'response' });
    }

    AddCard(flashcard: Flashcard): Observable<any> {
        return this.http.post<Flashcard>(this.url + 'create', flashcard, { observe: 'response' });
    }

    GetAllCards(): Observable<Flashcard[]> {
        return this.http.get<Flashcard[]>(this.url + '');
    }

    GetCardsById(cardId: number): Observable<Flashcard> {
        return this.http.get<Flashcard>(this.url + 'id?id=' + cardId);
    }

    GetCardsByDeckId(deckId: number): Observable<Flashcard> {
        return this.http.get<Flashcard>(this.url + 'deckid?id=' + deckId);
    }

    DeleteFlashcard(cardId: number): Observable<any> {
        return this.http.delete<Flashcard>(this.url + 'delete?id=' + cardId, { observe: 'response' });
    }
}