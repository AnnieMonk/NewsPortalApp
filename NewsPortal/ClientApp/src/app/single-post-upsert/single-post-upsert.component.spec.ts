import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SinglePostUpsertComponent } from './single-post-upsert.component';

describe('SinglePostUpsertComponent', () => {
  let component: SinglePostUpsertComponent;
  let fixture: ComponentFixture<SinglePostUpsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SinglePostUpsertComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SinglePostUpsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
