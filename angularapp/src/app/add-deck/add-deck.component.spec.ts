import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDeckComponent } from './add-deck.component';

describe('AddDeckComponent', () => {
  let component: AddDeckComponent;
  let fixture: ComponentFixture<AddDeckComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddDeckComponent]
    });
    fixture = TestBed.createComponent(AddDeckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
