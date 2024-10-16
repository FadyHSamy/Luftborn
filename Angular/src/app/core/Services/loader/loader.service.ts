import { Injectable } from '@angular/core';
import { LoadingController } from '@ionic/angular';

@Injectable({
  providedIn: 'root',
})
export class LoaderService {
  constructor(private loadingCtrl: LoadingController) {}

  loadingPromise: Promise<HTMLIonLoadingElement | null> | null = null;

  async presentLoading() {
    if (!this.loadingPromise) {
      this.loadingPromise = this.loadingCtrl.create({
        translucent: true,
        backdropDismiss: false,
        spinner:'crescent'
      });
    }

    const loading = await this.loadingPromise;
    if (loading) {
      await loading.present();
    }
  }

  async dismissLoading() {
    const loading = await this.loadingPromise;
    if (loading) {
      await loading.dismiss();
    }
  }
}
