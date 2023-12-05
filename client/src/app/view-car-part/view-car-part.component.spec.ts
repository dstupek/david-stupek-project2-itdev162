import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCarPartComponent } from './view-car-part.component';

describe('ViewCarPartComponent', () => {
  let component: ViewCarPartComponent;
  let fixture: ComponentFixture<ViewCarPartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewCarPartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCarPartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
