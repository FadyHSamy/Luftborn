export enum TaskStatus {
  Unfinished = 0,
  Finished = 1,
}

export interface Task {
  id: number;
  title: string;
  status: TaskStatus;
}
