import { Component, Input, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import Flashcard from '../models/Flashcard';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { DeckService } from '../services/deck.service';
import CardDeck from '../models/CardDeck';

@Component({
  selector: 'app-edit-flashcards',
  templateUrl: './edit-flashcards.component.html',
  styleUrls: ['./edit-flashcards.component.css']
})
export class EditFlashcardsComponent implements OnInit {
  @Input() cardid!: number;
  private cardIdSub: Subscription | undefined;

  cardEditForm!: FormGroup;
  cardEditFormId!: FormGroup;
  cardedit!: Flashcard;
  card$?: Observable<Flashcard>;
  deck$?: Observable<CardDeck>;
  deckName!: string;
  deckId!: number | undefined;


  constructor(private flashcardService: FlashcardService, private deckservice: DeckService, private formbuilder: FormBuilder,
    private _snackbar: MatSnackBar, private route: ActivatedRoute, private router: Router) {
    this.cardEditFormId = this.formbuilder.group({
      Id: new FormControl(''),
      deckName: new FormControl('')
    })
    this.cardEditForm = this.formbuilder.group({
      Question: new FormControl('', Validators.required),
      Answer: new FormControl('', Validators.required),
    })

  }

  ngOnInit(): void {
    this.cardEditFormId.disable();
    this.card$ = this.flashcardService.GetCardsById(this.cardid),
    this.deck$ = this.deckservice.GetDeckByFlashcardId(this.cardid)

    this.deck$?.subscribe(deckpatch => {this.cardEditFormId.patchValue(
      { deckName: deckpatch.deckName},
      )
      this.deckName = deckpatch.deckName;
      this.deckId = deckpatch.deckId;
  })
    this.card$?.subscribe(flashcardpatch => {
      this.cardEditFormId.patchValue(
        {
          Id: flashcardpatch.id,
        }
      )

      this.cardEditForm.patchValue(
        {
          Question: flashcardpatch.question,
          Answer: flashcardpatch.answer
        }
      )
    });
  }

  formSubmission() {
    this.cardEditForm
    this.cardedit = {
      id: this.cardid,
      question: this.cardEditForm.get("Question")?.value,
      answer: this.cardEditForm.get("Answer")?.value,
    };
    this.flashcardService.EditCard(this.cardedit).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard edit succeeded.", "Close"), this.router.navigate([`deckdetails/${this.deckId}`]); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }

  deleteFlashcard() {
    const cardid = this.cardEditFormId.get("Id")?.value
    console.log("check id to delete", cardid);
    this.flashcardService.DeleteFlashcard(cardid).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard deletion succeeded.", "Close"), this.router.navigate([`deckdetails/${this.deckId}`]); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}