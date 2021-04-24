import { Expenditure } from "./expenditure";
import { Income } from "./income";

export interface User {
    id?: number,
    email: string,
    password: string,
    fullname?: string,
    joinedOn?: Date,
    incomes?: Income[],
    expenditures?: Expenditure[]
}