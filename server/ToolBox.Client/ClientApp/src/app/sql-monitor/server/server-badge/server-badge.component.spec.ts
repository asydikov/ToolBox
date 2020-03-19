import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServerBadgeComponent } from './server-badge.component';

describe('ServerBadgeComponent', () => {
  let component: ServerBadgeComponent;
  let fixture: ComponentFixture<ServerBadgeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServerBadgeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServerBadgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
