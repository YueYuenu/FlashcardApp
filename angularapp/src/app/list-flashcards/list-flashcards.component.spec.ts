import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFlashcardsComponent } from './list-flashcards.component';

describe('ListFlashcardsComponent', () => {
    let component: ListFlashcardsComponent;
    let fixture: ComponentFixture<ListFlashcardsComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [ListFlashcardsComponent]
        })
            .compileComponents();

        fixture = TestBed.createComponent(ListFlashcardsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});