import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PractisePageComponent } from './practise-page.component';

describe('PractisePageComponent', () => {
  let component: PractisePageComponent;
  let fixture: ComponentFixture<PractisePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PractisePageComponent]
    });
    fixture = TestBed.createComponent(PractisePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
