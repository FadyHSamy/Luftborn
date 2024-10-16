import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpResponse } from 'src/app/models/HttpResponse';
import { Task } from 'src/app/models/TasksModels';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TaskHttpService {
  constructor(private httpClient: HttpClient) {}

  getAllTasks(): Observable<HttpResponse<Task[]>> {
    return this.httpClient.get<HttpResponse<Task[]>>(
      `${environment.apiUrl}api/Tasks/GetAllTasks`
    );
  }

  deleteTask(taskId: number): Observable<HttpResponse<null>> {
    return this.httpClient.delete<HttpResponse<null>>(
      `${environment.apiUrl}api/Tasks/DeleteTask?TaskId=${taskId.toString()}`
    );
  }

  addTask(taskTitle: string): Observable<HttpResponse<null>> {
    return this.httpClient.post<HttpResponse<null>>(
      `${environment.apiUrl}api/Tasks/AddTask`,
      { title: taskTitle, description: null }
    );
  }
}
