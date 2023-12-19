import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFlashcardComponent } from './show-flashcard.component';

describe('ShowFlashcardComponent', () => {
  let component: ShowFlashcardComponent;
  let fixture: ComponentFixture<ShowFlashcardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowFlashcardComponent]
    });
    fixture = TestBed.createComponent(ShowFlashcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
