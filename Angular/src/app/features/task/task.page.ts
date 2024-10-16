import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { AlertService } from 'src/app/core/Services/alert-service/alert.service';
import { PresentToastService } from 'src/app/core/Services/present-toast/present-toast.service';
import { TaskHttpService } from 'src/app/core/Services/task-http/task-http.service';
import { IonicModule } from '@ionic/angular';
import { Task, TaskStatus } from '../../models/TasksModels';

interface TaskList {
  tasks: Task[];
}
@Component({
  selector: 'app-task',
  templateUrl: './task.page.html',
  styleUrls: ['./task.page.scss'],
  standalone: true,
  imports: [IonicModule, ReactiveFormsModule, CommonModule],
})
export class TaskPage implements OnInit {
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
        await this.presentToastService.presentToast(response.message);
        this.taskForm.reset();
        this.loadTasks();
      }
    });
  }

  updateTaskStatus(taskId: number, taskStatus: TaskStatus) {
    this.taskService
      .updateTaskStatus(taskId, taskStatus)
      .subscribe(async (response) => {
        if (!response.isSuccess) {
          console.error(response.message);
        } else {
          await this.presentToastService.presentToast(response.message);
          this.loadTasks();
        }
      });
  }
}
