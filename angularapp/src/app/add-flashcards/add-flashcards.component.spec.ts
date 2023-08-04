import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFlashcardsComponent } from './add-flashcards.component';

describe('AddFlashcardsComponent', () => {
  let component: AddFlashcardsComponent;
  let fixture: ComponentFixture<AddFlashcardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddFlashcardsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddFlashcardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});