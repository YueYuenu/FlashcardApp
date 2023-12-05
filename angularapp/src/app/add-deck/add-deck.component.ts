import { Component } from '@angular/core';
import CardDeck from '../models/CardDeck';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DeckService } from '../services/deck.service';
import { MatSnackBar as MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-deck',
  templateUrl: './add-deck.component.html',
  styleUrls: ['./add-deck.component.css']
})
export class AddDeckComponent {
  deckForm!: FormGroup;
  deckAdd!: CardDeck;

  constructor(private deckService: DeckService, private formbuilder: FormBuilder, private _snackbar: MatSnackBar) {
    this.deckForm = this.formbuilder.group({
      deckName: new FormControl('', Validators.required),
    })
  }

  ngOnInit(): void {
  }

  formSubmission() {
    this.deckForm
    this.deckAdd = {
      deckName: this.deckForm.get("deckName")?.value,
    };
    console.log("card add", this.deckAdd)
    this.deckService.CreateCardDeck(this.deckAdd).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard was successfully added.", "Close"); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}
