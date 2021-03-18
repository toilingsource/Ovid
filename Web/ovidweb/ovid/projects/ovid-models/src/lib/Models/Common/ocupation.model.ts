import { UserAccount } from "../Accounts/user-account.model";




export class Ocupation{
    public ocupationId:number;
    public name:string;
    public userAccounts:UserAccount[] = [];
}