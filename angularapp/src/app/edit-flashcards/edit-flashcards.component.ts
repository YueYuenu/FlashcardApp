import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-edit-flashcards',
    templateUrl: './edit-flashcards.component.html',
    styleUrls: ['./edit-flashcards.component.css']
})
export class EditFlashcardsComponent implements OnInit {
    constructor() { }

    ngOnInit(): void {
    }
    //get correct ID somehow, cache get all and search cards, then getall again after submit?
}