import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFlashcardsComponent } from './delete-flashcards.component';

describe('DeleteFlashcardsComponent', () => {
  let component: DeleteFlashcardsComponent;
  let fixture: ComponentFixture<DeleteFlashcardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteFlashcardsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteFlashcardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
