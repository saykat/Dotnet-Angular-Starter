import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private httpClient: HttpClient) { }

  getEmp() {
    return this.httpClient.get('http://dummy.restapiexample.com/api/v1/employees');
  }
}
