import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchOptionsDieteticianComponent } from './search-options-dietetician.component';

describe('SearchOptionsDieteticianComponent', () => {
  let component: SearchOptionsDieteticianComponent;
  let fixture: ComponentFixture<SearchOptionsDieteticianComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchOptionsDieteticianComponent]
    });
    fixture = TestBed.createComponent(SearchOptionsDieteticianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
