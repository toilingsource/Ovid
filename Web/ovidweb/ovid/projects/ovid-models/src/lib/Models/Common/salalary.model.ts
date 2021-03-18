import { UserAccount } from "../Accounts/user-account.model";



export class Salary{
    public salaryId:number;
    public startRange:number;
    public endRange:number;
    public userAccounts:UserAccount[] = [];
}