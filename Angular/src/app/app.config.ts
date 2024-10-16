import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import {
  PreloadAllModules,
  provideRouter,
  RouteReuseStrategy,
  withPreloading,
} from '@angular/router';
import { routes } from './app.routes';
import { httpLoaderInterceptor } from './core/Interceptor/http-loader.interceptor';
import { IonicRouteStrategy } from '@ionic/angular';
import { provideIonicAngular } from '@ionic/angular/standalone';

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },

    provideIonicAngular(),
    provideRouter(routes, withPreloading(PreloadAllModules)),
    provideHttpClient(withInterceptors([httpLoaderInterceptor])),
    provideRouter(routes),
    provideHttpClient(withInterceptors([httpLoaderInterceptor])),
  ],
};
