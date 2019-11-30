import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ChildActivationEnd, NavigationEnd, ResolveStart, Router} from '@angular/router';
import {filter, map} from 'rxjs/operators';
import {SetupService} from './services/setup.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {

  title = '';

  public constructor(public setupService: SetupService,private router: Router) {
  }

  ngOnInit() {
    this.router.events.pipe(
      filter(event => event instanceof ResolveStart),
      map(event => {
        let data = null;
        let route = event['state'].root;

        while (route) {
          data = route.data || data;
          route = route.firstChild;
        }

        return data;
      }),
    ).subscribe(
      data => this.title = data.title
    );
  }
}
