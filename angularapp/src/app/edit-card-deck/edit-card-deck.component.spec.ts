import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCardDeckComponent } from './edit-card-deck.component';

describe('EditCardDeckComponent', () => {
  let component: EditCardDeckComponent;
  let fixture: ComponentFixture<EditCardDeckComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditCardDeckComponent]
    });
    fixture = TestBed.createComponent(EditCardDeckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
