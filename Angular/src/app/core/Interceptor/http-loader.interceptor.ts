import { HttpInterceptorFn } from '@angular/common/http';
import { LoaderService } from '../Services/loader/loader.service';
import { finalize } from 'rxjs';

export const httpLoaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = new LoaderService(); // Instantiate the loading service
  loadingService.showLoadingSpinner(); // Show loading spinner UI element

  return next(req).pipe(
    finalize(() => {
      loadingService.hideLoadingSpinner(); // Hide loading spinner UI element
    })
  );
};
