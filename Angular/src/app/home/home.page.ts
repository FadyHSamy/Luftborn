import { Component, OnInit } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Task } from '../models/TasksModels';
import { TaskHttpService } from '../core/Services/task-http/task-http.service';
import { PresentToastService } from '../core/Services/present-toast/present-toast.service';
import { AlertService } from '../core/Services/alert-service/alert.service';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: true,
  imports: [IonicModule, ReactiveFormsModule, CommonModule],
  providers: [],
})
export class HomePage implements OnInit {
  constructor() {}

  ngOnInit(): void {
    console.log('Home Page');
  }
}
