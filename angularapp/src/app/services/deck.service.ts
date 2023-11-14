import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import CardDeck from '../models/CardDeck';

@Injectable({
  providedIn: 'root'
})
export class DeckService {
  url: string = environment.apiUrl + 'decks/';
  constructor(private http: HttpClient) { }

  GetAllCardDecks(): Observable<CardDeck[]> {
    return this.http.get<CardDeck[]>(this.url);
  }
  
  GetDeckById(deckId: number): Observable<CardDeck> {
    return this.http.get<CardDeck>(this.url + deckId);
  }
    
  GetDeckByFlashcardId(cardId: number): Observable<CardDeck> {
    return this.http.get<CardDeck>(this.url + 'cardid?id=' + cardId);
  }

  CreateCardDeck(carddeck: CardDeck): Observable<any>{
    return this.http.post<CardDeck>(this.url, carddeck, {observe: 'response'})
  }

  UpdateCardDeck(carddeck: CardDeck): Observable<any>{
    return this.http.put<CardDeck>(this.url, carddeck, { observe: 'response'})
  }

  SearchCardDecks(query: string): Observable<any>{
    return this.http.get<CardDeck[]>(this.url + 'search?query=' + query)
  }

  DeleteCardDeck(deckId: number): Observable<any>{
    return this.http.delete<CardDeck>(this.url + deckId, {observe: 'response'})
  }
}
