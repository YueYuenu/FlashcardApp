import { Component, Input } from '@angular/core';
import Flashcard from '../models/Flashcard';
import { FlashcardService } from '../services/flashcard.service';
import { Observable } from 'rxjs';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-practise-page',
  templateUrl: './practise-page.component.html',
  styleUrls: ['./practise-page.component.css']
})
export class PractisePageComponent {
  @Input() deckId!: number;
  flashcards!: Flashcard[];

  constructor(private flashcardService: FlashcardService){
  }
  ngOnInit(): void {
    this.flashcardService.RandomizeFlashcards(this.deckId).subscribe((
      flashcards: Flashcard[]) => {return this.flashcards = flashcards});
  }

}
