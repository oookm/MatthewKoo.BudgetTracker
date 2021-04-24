import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  userId: number | undefined;
  user: User | undefined;
  addchecked = false;
  enableEdit = false;
  updateduser: User = {
    email: '',
    password: '',
  }

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.userId = Number(params.get('id'));
        this.updateduser.id = this.userId
        this.userService.getUserById(this.userId)
          .subscribe(u => {
            this.user = u;
          });
      }
    )
  }
  enableEditMethod(e: any) {
    this.enableEdit = true;
  }
  updateUser() {
    this.userService.updateUser(this.updateduser).subscribe()
  }
}
