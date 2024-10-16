import { Component } from '@angular/core';
import { IonApp, IonRouterOutlet } from '@ionic/angular/standalone';
import { LoaderComponent } from './shared/components/loader/loader.component';
import { LoaderService } from './core/Services/loader/loader.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  standalone: true,
  imports: [IonApp, IonRouterOutlet, LoaderComponent],
  providers: [],
})
export class AppComponent {
  constructor() {}
}
