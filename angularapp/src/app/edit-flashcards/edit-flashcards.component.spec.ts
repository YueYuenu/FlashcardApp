import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFlashcardsComponent } from './edit-flashcards.component';

describe('EditFlashcardsComponent', () => {
  let component: EditFlashcardsComponent;
  let fixture: ComponentFixture<EditFlashcardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditFlashcardsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditFlashcardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
