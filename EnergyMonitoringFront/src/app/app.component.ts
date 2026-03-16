import { filter } from 'rxjs';
import { Component, inject } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { SeoService } from '@core/seo/seo.service';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [RouterOutlet,  RouterOutlet],
	templateUrl: './app.component.html',
	styleUrl: './app.component.css'
})

export class AppComponent {
  private router = inject(Router);
  private seo = inject(SeoService);

  constructor() {
    this.router.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe(() => {
        const route = this.getDeepestRoute(this.router.routerState.snapshot.root);
        const data = route.data;

        this.seo.update({
          title: route.title as string,
          description: data['description'],
          keywords: data['keywords']
        });
      });
  }

  private getDeepestRoute(route: any): any {
    return route.firstChild ? this.getDeepestRoute(route.firstChild) : route;
  }
}