import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expenditure } from 'src/app/shared/models/expenditure';
import { Income } from 'src/app/shared/models/income';
import { User } from 'src/app/shared/models/user';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  getAllUsers(): Observable<User[]>{
    return this.apiService.getAll('Users/users')
  }
  getUserById(id: number): Observable<User> {
    return this.apiService.getOne(`${'Users/user/'}${id}`)
  }
  addUser(user: User) {
    return this.apiService.post('Users/create', user)
  }
  deleteUser(id: number | undefined) {
    return this.apiService.delete('Users/delete', id)
  }
  updateUser(user: User) {
    return this.apiService.post('Users/update', user)
  }
  addExpenditure(expenditure: Expenditure) {
    return this.apiService.post('Expenditures/create', expenditure)
  }
  updateExpenditure(expenditure: Expenditure) {
    return this.apiService.post('Expenditures/update', expenditure)
  }
  deleteExpenditure(id: number | undefined) {
    return this.apiService.delete('Expenditures/delete', id)
  }
  addIncome(income: Income) {
    return this.apiService.post('Incomes/create', income)
  }
  updateIncome(income: Income) {
    return this.apiService.post('Incomes/update', income)
  }
  deleteIncome(id: number | undefined) {
    return this.apiService.delete('Incomes/delete', id)
  }
}
