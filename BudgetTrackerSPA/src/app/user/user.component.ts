import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { Expenditure } from '../shared/models/expenditure';
import { Income } from '../shared/models/income';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  userId: number | undefined;
  user: User | undefined;
  addcheckedexpenditure = false;
  addcheckedincome = false;
  updateduser: User = {
    email: '',
    password: '',
  }
  expenditure: Expenditure = {
    amount: 0,
  }
  updatedexpenditure: Expenditure = {
    amount: 0,
  }
  income: Income = {
    amount: 0,
  }
  updatedincome: Income = {
    amount: 0,
  }
  enableEdit = false;

  enableEditExpenditure = false;
  enableEditIndexExpenditure = null;
  enableEditIncome = false;
  enableEditIndexIncome = null;

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  // get user id from route
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.userId = Number(params.get('id'));
        this.updateduser.id = this.userId
        this.userService.getUserById(this.userId)
          .subscribe(u => {
            this.user = u;
          });
        this.expenditure.userId = this.userId;
        this.income.userId = this.userId;
      }
    )
  }
  enableEditMethod() {
    this.enableEdit = true;
  }
  enableEditMethodExpenditure(i: any) {
    this.enableEditExpenditure = true;
    this.enableEditIndexExpenditure = i;
  }
  enableEditMethodIncome(i: any) {
    this.enableEditIncome = true;
    this.enableEditIndexIncome = i;
  }
  updateUser() {
    this.userService.updateUser(this.updateduser).subscribe()
  }
  addExpenditure() {
    this.userService.addExpenditure(this.expenditure).subscribe()
  }
  updateExpenditure(id: number | undefined, uid: number | undefined) {
    this.updatedexpenditure.id = id;
    this.updatedexpenditure.userId = uid;
    this.userService.updateExpenditure(this.updatedexpenditure).subscribe();
  }
  deleteExpenditure(id: number | undefined) {
    this.userService.deleteExpenditure(id).subscribe();
  }
  addIncome() {
    this.userService.addIncome(this.income).subscribe()
  }
  updateIncome(id: number | undefined, uid: number | undefined) {
    this.updatedincome.id = id;
    this.updatedincome.userId = uid;
    this.userService.updateIncome(this.updatedincome).subscribe();
  }
  deleteIncome(id: number | undefined) {
    this.userService.deleteIncome(id).subscribe();
  }
}