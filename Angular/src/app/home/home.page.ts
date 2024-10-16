import { Component, OnInit } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Task } from '../models/TasksModels';
import { TaskHttpService } from '../core/Services/task-http.service';
import { PresentToastService } from '../core/Services/present-toast.service';
import { AlertService } from '../core/Services/alert.service';
import { IonicModule } from '@ionic/angular';

interface TaskList {
  tasks: Task[];
}

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: true,
  imports: [
    IonicModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  providers: [],
})
export class HomePage implements OnInit {
  taskList!: TaskList;
  taskForm!: FormGroup;

  constructor(
    private taskService: TaskHttpService,
    private formBuilder: FormBuilder,
    private presentToastService: PresentToastService,
    private alertService: AlertService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.loadTasks();
  }

  initializeForm(): void {
    this.taskList = {
      tasks: [],
    };
    this.taskForm = this.formBuilder.group({
      title: ['', Validators.required],
    });
  }

  loadTasks(): void {
    this.taskService.getAllTasks().subscribe((response) => {
      this.taskList.tasks = response.data;
    });
  }

  async deleteTask(taskId: number) {
    if (
      !(await this.alertService.showConfirmationAlert(
        'You Sure to delete this task'
      ))
    ) {
      return;
    }
    this.taskService.deleteTask(taskId).subscribe(async (response) => {
      if (!response.isSuccess) {
        await this.presentToastService.presentToast(response.message);
      } else {
        await this.presentToastService.presentToast(
          'Task deleted successfully'
        );
        this.loadTasks();
      }
    });
  }

  addTask(): void {
    const taskTitle: string = this.taskForm.controls['title'].value;
    if (!this.taskForm.valid || !taskTitle || !taskTitle.trim()) {
      return;
    }

    this.taskService.addTask(taskTitle).subscribe(async (response) => {
      if (!response.isSuccess) {
        console.error(response.message);
      } else {
        await this.presentToastService.presentToast('Task Added Successfully');
        this.taskForm.reset();
        this.loadTasks();
      }
    });
  }
}
