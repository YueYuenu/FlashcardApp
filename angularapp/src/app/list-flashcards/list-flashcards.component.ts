import { Component, OnInit, ViewChild } from '@angular/core';
import Flashcard from '../models/Flashcard';
import { FlashcardService } from '../services/flashcard.service';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
    selector: 'app-list-flashcards',
    templateUrl: './list-flashcards.component.html',
    styleUrls: ['./list-flashcards.component.css']
})
export class ListFlashcardsComponent implements OnInit {
    private flashcards: Flashcard[] = [];
    displayedColumns: string[] = ['Id', 'Question', 'Answer'];
    public dataSource = new MatTableDataSource<Flashcard>()

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

    constructor(private flashcardservice: FlashcardService) { }

    ngOnInit(): void {
        this.flashcardservice.GetAllCards().subscribe(flashcards => {
            this.flashcards = flashcards; this.dataSource.data = this.flashcards;
            console.log(this.flashcards); console.log(this.dataSource.data)
        })
    }

    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    applyFilter(event: Event) {
        const filterValue = (event.target as HTMLInputElement).value;
        this.dataSource.filter = filterValue.trim().toLowerCase();

        if (this.dataSource.paginator) {
            this.dataSource.paginator.firstPage();
        }
    }
}