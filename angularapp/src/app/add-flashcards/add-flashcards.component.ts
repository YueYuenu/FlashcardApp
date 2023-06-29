import { Component, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import Flashcard from '../models/Flashcard';

@Component({
  selector: 'app-add-flashcards',
  templateUrl: './add-flashcards.component.html',
  styleUrls: ['./add-flashcards.component.css']
})
export class AddFlashcardsComponent implements OnInit {
  cardForm!: FormGroup;
  cardAdd!: Flashcard;

  constructor(private flashcardService: FlashcardService, private formbuilder: FormBuilder, private _snackbar: MatSnackBar) {
    this.cardForm = this.formbuilder.group({
      Question: new FormControl('', Validators.required),
      Answer: new FormControl('', Validators.required),
    })
  }

  ngOnInit(): void {
  }

  formSubmission() {
    this.cardForm
    this.cardAdd = {
      question: this.cardForm.get("Question")?.value,
      answer: this.cardForm.get("Answer")?.value,
    };
    console.log("card add",this.cardAdd) //question and answer are null in db but appear correctly in this log.
    this.flashcardService.AddCard(this.cardAdd).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard was successfully added.", "Close"); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}
