import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import CardDeck from '../models/CardDeck';
import { DeckService } from '../services/deck.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-card-deck',
  templateUrl: './edit-card-deck.component.html',
  styleUrls: ['./edit-card-deck.component.css']
})
export class EditCardDeckComponent {

  private deckIdSub: Subscription | undefined;

  newDeckform!: FormGroup;
  deckEditFormId!: FormGroup;
  deckedit!: CardDeck;
  deck$?: Observable<CardDeck>;

  constructor(private deckservice: DeckService, private formbuilder: FormBuilder,
    private _snackbar: MatSnackBar, private route: ActivatedRoute, private router: Router) {
    this.deckEditFormId = this.formbuilder.group({
      deckId: new FormControl('')
    })
    this.newDeckform = this.formbuilder.group({
      deckName: new FormControl('', Validators.required),
    })

  }

  ngOnInit(): void {
    this.deckEditFormId.disable();
    this.deckIdSub = this.route.params.subscribe(
      params => this.deck$ = this.deckservice.GetDeckById(params['id']),
    );
    this.deck$?.subscribe(deckpatch => {
      this.deckEditFormId.patchValue(
        {
          deckId: deckpatch.deckId
        }
      )
      this.newDeckform.patchValue(
        {
          deckName: deckpatch.deckName
        }
      )
    });
  }

  formSubmission() {
    this.newDeckform
    this.deckedit = {
      deckId: this.deckEditFormId.get("deckId")?.value,
      deckName: this.newDeckform.get("deckName")?.value,

    };
    this.deckservice.CreateCardDeck(this.deckedit).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Deck edit succeeded.", "Close"), this.router.navigate(['decklist']); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }

  deleteFlashcard() {
    const cardid = this.deckEditFormId.get("Id")?.value
    console.log("check id to delete", cardid);
    this.deckservice.DeleteCardDeck(cardid).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Deck deletion succeeded.", "Close"), this.router.navigate(['decklist']); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}
