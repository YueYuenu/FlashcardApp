import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import CardDeck from '../models/CardDeck';

@Injectable({
  providedIn: 'root'
})
export class DeckService {
  url: string = environment.apiUrl + 'FlashcardController/';
  constructor(private http: HttpClient) { }

  GetAllCards(): Observable<CardDeck[]> {
    return this.http.get<CardDeck[]>(this.url + 'GetAllCardDecks');
}
}
