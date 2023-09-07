import { Component, OnInit } from '@angular/core';
import { FlashcardService } from '../services/flashcard.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import Flashcard from '../models/Flashcard';
import { ActivatedRoute, NavigationEnd, NavigationExtras, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-flashcards',
  templateUrl: './edit-flashcards.component.html',
  styleUrls: ['./edit-flashcards.component.css']
})
export class EditFlashcardsComponent implements OnInit {

  private cardIdSub: Subscription | undefined;

  cardEditForm!: FormGroup;
  cardEditFormId!: FormGroup;
  cardedit!: Flashcard;
  card$?: Observable<Flashcard>;

  constructor(private flashcardService: FlashcardService, private formbuilder: FormBuilder,
    private _snackbar: MatSnackBar, private route: ActivatedRoute, private router: Router) {
    this.cardEditFormId = this.formbuilder.group({
      Id: new FormControl('')
    })
    this.cardEditForm = this.formbuilder.group({
      Question: new FormControl('', Validators.required),
      Answer: new FormControl('', Validators.required),
    })

  }

  ngOnInit(): void {
    this.cardEditFormId.disable();
    this.cardIdSub = this.route.params.subscribe(
      params => this.card$ = this.flashcardService.GetCardsById(params['id']),
    );
    this.card$?.subscribe(flashcardpatch => {
      this.cardEditFormId.patchValue(
        {
          Id: flashcardpatch.id
        }
      )
      this.cardEditForm.patchValue(
        {
          Question: flashcardpatch.question,
          Answer: flashcardpatch.answer
        }
      )
    });
    this.router.events.subscribe(event => { //This is hecking slow on list reload. is there a better way?!
      if (event instanceof NavigationEnd)
        window.location.reload();
    })
  }
  //cache get all, then getall again after submit, then reload?

  formSubmission() {
    this.cardEditForm
    this.cardedit = {
      id: this.cardEditFormId.get("Id")?.value,
      question: this.cardEditForm.get("Question")?.value,
      answer: this.cardEditForm.get("Answer")?.value,
    };   
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(['listFlashcards']));
    this.flashcardService.EditCard(this.cardedit).subscribe(res => {
      if (res.status == 200) { this._snackbar.open("Flashcard edit succeeded.", "Close"); }
      else { this._snackbar.open("Something went wrong", "Close"); }
    });
  }
}