import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchItemComponent } from './fetch-item.component';

describe('FetchEmployeeComponent', () => {
  let component: FetchItemComponent;
  let fixture: ComponentFixture<FetchItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [FetchItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
