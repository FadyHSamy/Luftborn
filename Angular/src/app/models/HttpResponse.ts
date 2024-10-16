export interface HttpResponse<T> {
  data: T;
  isSuccess: boolean;
  message: string;
  requestApiUrl: string;
}
