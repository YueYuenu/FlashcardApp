import { Component, Input } from '@angular/core';
import Flashcard from '../models/Flashcard';

@Component({
  selector: 'app-show-flashcard',
  templateUrl: './show-flashcard.component.html',
  styleUrls: ['./show-flashcard.component.css']
})
export class ShowFlashcardComponent {
@Input() flashcard!: Flashcard;
hide = true;
}
