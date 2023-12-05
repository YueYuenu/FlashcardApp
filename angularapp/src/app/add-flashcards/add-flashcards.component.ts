import { Component, Input, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar as MatSnackBar } from '@angular/material/snack-bar';
import Flashcard from '../models/Flashcard';
import { DeckService } from '../services/deck.service';
import CardDeck from '../models/CardDeck';
import { Observable } from 'rxjs';

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

  constructor(private flashcardService: FlashcardService, private deckService: DeckService, private formbuilder: FormBuilder, private _snackbar: MatSnackBar) {
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
    this.flashcardService.AddCard(this.cardAdd).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard was successfully added.", "Close"); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}