import {Component} from '@angular/core';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-user-register',
  templateUrl: 'user-register.component.html'
})
export class UserRegisterComponent {
  constructor(private toastr: ToastrService) {}

  submit(form) {
    console.log(form.value);
    if (form.invalid) {
      this.toastr.warning('Please fill all the field correctly', 'Warning');
    } else {
      this.toastr.success('Submitted', 'Success');
      form.submitted = false;
      form.reset();
    }
  }

}
