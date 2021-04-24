import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  users: User[] | undefined;
  addchecked = false;
  enableEdit = false;
  enableEditIndex = null;
  thisuser: User = {
    email: '',
    password: '',
  }
  updateduser: User = {
    email: '',
    password: '',
  }

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(
      u => {
        this.users = u;
        console.table(this.users);
      }
    )
  }
  addUser() {
    this.userService.addUser(this.thisuser).subscribe();
  }
  deleteUser(id: number | undefined) {
    this.userService.deleteUser(id).subscribe();
  }
  enableEditMethod(i: any) {
    this.enableEdit = true;
    this.enableEditIndex = i;
  }
  updateUser(id: number | undefined) {
    this.updateduser.id = id;
    this.userService.updateUser(this.updateduser).subscribe();
  }

}
