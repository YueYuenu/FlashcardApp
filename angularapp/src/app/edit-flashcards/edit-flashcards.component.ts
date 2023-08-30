import { Component, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import Flashcard from '../models/Flashcard';

@Component({
    selector: 'app-edit-flashcards',
    templateUrl: './edit-flashcards.component.html',
    styleUrls: ['./edit-flashcards.component.css']
})
export class EditFlashcardsComponent implements OnInit {

    cardEditForm!: FormGroup;
    cardedit!: Flashcard;

  constructor(private flashcardService: FlashcardService, private formbuilder: FormBuilder, private _snackbar: MatSnackBar) {
    this.cardEditForm = this.formbuilder.group({
      Id: new FormControl(''),
      Question: new FormControl('', Validators.required),
      Answer: new FormControl('', Validators.required),
    })
  }

    ngOnInit(): void {
    }
    //get correct ID somehow, cache get all and search cards, then getall again after submit?

    formSubmission() {
        this.cardEditForm
        this.cardedit = {
          id: this.cardEditForm.get("Id")?.value,
          question: this.cardEditForm.get("Question")?.value,
          answer: this.cardEditForm.get("Answer")?.value,
        };
        console.log("card add",this.cardedit)
        
        this.flashcardService.EditCard(this.cardedit).subscribe(res => {
          if (res.status == 200) { this._snackbar.open("Flashcard edit succeeded.", "Close"); }
          else { this._snackbar.open("Something went wrong", "Close"); }
        });
      }
}