import { AxiosResponse } from 'axios';

export interface Service<T> {
    GetAll?: Promise<AxiosResponse<T>>;
  }