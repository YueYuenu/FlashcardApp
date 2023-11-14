import { Component, ViewChild } from '@angular/core';
import CardDeck from '../models/CardDeck';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DeckService } from '../services/deck.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-decks',
  templateUrl: './list-decks.component.html',
  styleUrls: ['./list-decks.component.css']
})
export class ListDecksComponent {
  private carddeck: CardDeck[] = [];
  displayedColumns: string[] = ['DeckId', 'DeckName'];
  public dataSource = new MatTableDataSource<CardDeck>()

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private deckService: DeckService, private router: Router) { }

  ngOnInit(): void {
      this.deckService.GetAllCardDecks().subscribe(flashcardslist => {
          this.carddeck = flashcardslist; this.dataSource.data = this.carddeck;
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

  clickedRows(carddeckId: CardDeck["deckId"]) {
      this.router.navigate([`deckdetails/${carddeckId}`]);
  }
}
