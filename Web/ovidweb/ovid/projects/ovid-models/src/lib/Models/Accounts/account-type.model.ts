import { UserAccount } from "./user-account.model";



export class AccountType{
    public accontTypeId:string;
    public name:string;
    public description:string;
    public userAccounts:UserAccount[] =[];
}