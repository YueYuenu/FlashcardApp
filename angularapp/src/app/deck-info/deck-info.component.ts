import { Component, Input, ViewChild } from '@angular/core';
import { DeckService } from '../services/deck.service';
import { Observable } from 'rxjs';
import { FlashcardService } from '../services/flashcard.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import Flashcard from '../models/Flashcard';
import { MatTableDataSource } from '@angular/material/table';
import CardDeck from '../models/CardDeck';

@Component({
  selector: 'app-deck-info',
  templateUrl: './deck-info.component.html',
  styleUrls: ['./deck-info.component.css']
})
export class DeckInfoComponent {
  @Input() deckId!: number
  deck$!: Observable<CardDeck>;
  deckName!: string;

  private flashcards: Flashcard[] = [];
    displayedColumns: string[] = ['Id', 'Question', 'Answer'];
    public dataSource = new MatTableDataSource<Flashcard>()

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

  constructor(private deckService: DeckService, private flashcardService: FlashcardService, private router: Router) {}

  ngOnInit(): void {
    this.deck$ = this.deckService.GetDeckById(this.deckId);
    this.flashcardService.GetCardsByDeckId(this.deckId).subscribe(flashcardslist => {
      this.flashcards = flashcardslist; this.dataSource.data = this.flashcards;})

    console.log('check params id: ' + this.deckId)
    this.deck$?.subscribe(deckpatch => {
      this.deckName = deckpatch.deckName;
      console.log('deckId check: ' + deckpatch.deckId, 'deckName: ' + deckpatch.deckName)
    });
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

clickedRows(flashcardId: Flashcard["id"]) {
    this.router.navigate([`carddetails/${flashcardId}`]);
}

}
