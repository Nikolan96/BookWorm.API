import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AchievementTableComponent } from './achievement-table.component';

describe('AchievementTableComponent', () => {
  let component: AchievementTableComponent;
  let fixture: ComponentFixture<AchievementTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AchievementTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AchievementTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
