import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCarPartComponent } from './create-car-part.component';

describe('CreateCarPartComponent', () => {
  let component: CreateCarPartComponent;
  let fixture: ComponentFixture<CreateCarPartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCarPartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCarPartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
