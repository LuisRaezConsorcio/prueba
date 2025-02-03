import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserinspectComponent } from './userinspect.component';

describe('UserinspectComponent', () => {
  let component: UserinspectComponent;
  let fixture: ComponentFixture<UserinspectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserinspectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserinspectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
