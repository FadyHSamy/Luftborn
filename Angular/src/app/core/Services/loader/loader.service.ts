import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoaderService {
  private loading = false;

  showLoadingSpinner() {
    this.loading = true;
    console.log('Loading spinner shown');
  }

  hideLoadingSpinner() {
    this.loading = false;
    console.log('Loading spinner hidden');
  }

  isLoading(): boolean {
    return this.loading;
  }
}
