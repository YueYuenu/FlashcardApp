import { Component, Input, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Flashcard from '../models/Flashcard';
import { DeckService } from '../services/deck.service';
import CardDeck from '../models/CardDeck';
import { Observable } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

@Component({
  selector: 'app-add-flashcards',
  templateUrl: './add-flashcards.component.html',
  styleUrls: ['./add-flashcards.component.css']
})
export class AddFlashcardsComponent implements OnInit {
  @Input() deckId!: number;
  cardForm!: FormGroup;
  cardAdd!: Flashcard;
  deck$?: Observable<CardDeck>;
  deckName: any;

  constructor(private flashcardService: FlashcardService, private deckService: DeckService, private formbuilder: FormBuilder, 
    private _snackbar: SnackbarService) {
    this.cardForm = this.formbuilder.group({
      deckId: new FormControl(),
      Question: new FormControl('', Validators.required),
      Answer: new FormControl('', Validators.required),
    })
  }

  ngOnInit(): void {
    this.deck$ = this.deckService.GetDeckById(this.deckId);
    console.log('check params id: ' + this.deckId)
    this.deck$?.subscribe(deckpatch => {
      this.cardForm.patchValue(
        {
          deckId: deckpatch.deckId
        }
      )
      this.cardForm.patchValue(
        {
          deckName: deckpatch.deckName
        }
      )
      this.deckName = deckpatch.deckName;
      console.log('deckId check: ' + deckpatch.deckId, 'deckName: ' + deckpatch.deckName)
    });
  }

  formSubmission() {
    this.cardForm
    this.cardAdd = {
      deckId: this.deckId,
      question: this.cardForm.get("Question")?.value,
      answer: this.cardForm.get("Answer")?.value,
    };
    console.log("card add", this.cardAdd)
    this.flashcardService.AddCard(this.cardAdd).subscribe({
      next: res => {
      if (res.status == 200) { this._snackbar.SnackBar("Flashcard was successfully added."); }},
      error: (error) => { this._snackbar.SnackBar("Something went wrong"); },
      complete: () => {}
    });
  }
}