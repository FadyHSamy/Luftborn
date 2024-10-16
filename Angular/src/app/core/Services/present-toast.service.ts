import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root',
})
export class PresentToastService {
  constructor(private toastController: ToastController) {}
  async presentToast(messageString: string) {
    const toast = await this.toastController.create({
      message: messageString,
      duration: 1500,
      position: 'top',
    });

    await toast.present();
  }
}
