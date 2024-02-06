import { Component } from '@angular/core';
import CardDeck from '../models/CardDeck';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DeckService } from '../services/deck.service';
import { Router } from '@angular/router';
import { SnackbarService } from '../services/snackbar.service';



@Component({
  selector: 'app-add-deck',
  templateUrl: './add-deck.component.html',
  styleUrls: ['./add-deck.component.css']
})
export class AddDeckComponent {
  deckForm!: FormGroup;
  deckAdd!: CardDeck;

  constructor(private deckService: DeckService, private formbuilder: FormBuilder, 
    private router: Router, private _snackbar: SnackbarService) {
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
    console.log("deck add", this.deckAdd)
    this.deckService.CreateCardDeck(this.deckAdd).subscribe({
      next: (res) => { if (res.status == 200) { this._snackbar.SnackBar("Deck was successfully added."), 
      this.router.navigate(['decklist']); }}, 
      error: (error) => {this._snackbar.SnackBar("Something went wrong, your deckname may already exist.");}
  });
  }
}
