import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchOptionsTrainerComponent } from './search-options-trainer.component';

describe('SearchOptionsTrainerComponent', () => {
  let component: SearchOptionsTrainerComponent;
  let fixture: ComponentFixture<SearchOptionsTrainerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchOptionsTrainerComponent]
    });
    fixture = TestBed.createComponent(SearchOptionsTrainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
