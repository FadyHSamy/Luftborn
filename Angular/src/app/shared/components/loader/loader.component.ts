import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { LoaderService } from 'src/app/core/Services/loader/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss'],
  standalone: true,
  imports: [CommonModule, IonicModule],
})
export class LoaderComponent {
  constructor(public loaderService: LoaderService) {}
}
