import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { BehaviorSubject } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'] // Corrected from 'styleUrl' to 'styleUrls'
})
export class HomeComponent {
  // Use BehaviorSubjects for properties you want to change over time
  showHeroImage$ = new BehaviorSubject<boolean>(true);
  heroCols$ = new BehaviorSubject<number>(2);

  constructor(private breakpointObserver: BreakpointObserver) {
    // Observe the breakpoint and update BehaviorSubjects accordingly
    this.breakpointObserver.observe([Breakpoints.XSmall])
      .pipe(
        map(result => result.breakpoints[Breakpoints.XSmall]),
        startWith(false) // Initialize with default value if needed
      )
      .subscribe(isXSmall => {
        this.showHeroImage$.next(!isXSmall); // Hide on XSmall screens
        this.heroCols$.next(isXSmall ? 1 : 2); // Use 1 column on XSmall screens
      });
  }
}
