import { HttpInterceptorFn } from '@angular/common/http';
import { LoaderService } from '../Services/loader/loader.service';
import { finalize } from 'rxjs';
import { LoadingController } from '@ionic/angular';

export const httpLoaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingCtrl = new LoadingController();
  const loadingService = new LoaderService(loadingCtrl);
  loadingService.presentLoading();

  return next(req).pipe(
    finalize(() => {
      loadingService.dismissLoading();
    })
  );
};
