import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import CardDeck from '../models/CardDeck';
import { DeckService } from '../services/deck.service';
import { Router } from '@angular/router';
import { SnackbarService } from '../services/snackbar.service';

@Component({
  selector: 'app-edit-card-deck',
  templateUrl: './edit-card-deck.component.html',
  styleUrls: ['./edit-card-deck.component.css']
})
export class EditCardDeckComponent {
  @Input() deckId!: number
  
  newDeckform!: FormGroup;
  deckEditFormId!: FormGroup;
  deckedit!: CardDeck;
  deck$?: Observable<CardDeck>;

  constructor(private deckservice: DeckService, private formbuilder: FormBuilder,
    private _snackbar: SnackbarService, private router: Router) {
    this.deckEditFormId = this.formbuilder.group({
      deckId: new FormControl('')
    })
    this.newDeckform = this.formbuilder.group({
      deckName: new FormControl('', Validators.required),
    })

  }

  ngOnInit(): void {
    this.deckEditFormId.disable();
    this.deck$ = this.deckservice.GetDeckById(this.deckId)
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
    this.deckservice.UpdateCardDeck(this.deckedit).subscribe({
      next: (res) => {
       if (res.status == 200) { this._snackbar.SnackBar("Deck edit succeeded."), this.router.navigate(['decklist']); }},
      error: (error) => { this._snackbar.SnackBar("Something went wrong"); },
      complete: () => {}
      });
  }

  deleteCardDeck() {
    const deckId = this.deckEditFormId.get("deckId")?.value
    console.log("check id to delete", deckId);
    if(confirm("Are you sure you want to delete this deck?")){
      this.deckservice.DeleteCardDeck(deckId).subscribe({
        next: (res) => {
        if (res.status == 200) { this._snackbar.SnackBar("Deck deletion succeeded."), this.router.navigate(['decklist']); }},
        error: (error) => { this._snackbar.SnackBar("Something went wrong"); },
        complete: () => {}
      });
    } 
  }
}
