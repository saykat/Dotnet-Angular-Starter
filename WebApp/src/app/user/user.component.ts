import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {UserService} from '../services/user.service';
import {SetupService} from '../services/setup.service';

@Component({
  selector: 'app-user',
  templateUrl: 'user.component.html'
})
export class UserComponent implements OnInit {
  employees = [];
  constructor(private setupService: SetupService, private httpClient: HttpClient, private userService: UserService) {}
  ngOnInit(): void {
  }

  getData() {
    this.employees = [];
    this.setupService.busy = this.httpClient.get('http://dummy.restapiexample.com/api/v1/employees').subscribe(res => {
      for (let i = 0; i < 10; i++) {
        this.employees.push(res[i]);
      }
    });
  }
  getEmpData() {
    this.employees = [];
    this.setupService.busy = this.userService.getEmp().subscribe(res => {
      for (let i = 0; i < 10; i++) {
        this.employees.push(res[i]);
      }
    });
  }

}
