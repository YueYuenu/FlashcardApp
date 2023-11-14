import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDecksComponent } from './list-decks.component';

describe('ListDecksComponent', () => {
  let component: ListDecksComponent;
  let fixture: ComponentFixture<ListDecksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListDecksComponent]
    });
    fixture = TestBed.createComponent(ListDecksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
