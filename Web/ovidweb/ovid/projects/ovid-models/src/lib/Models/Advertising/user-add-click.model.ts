import { UserAccount } from "../Accounts/user-account.model";
import { Advertisment } from "./advertisment.model";



export class UserAddClick{
    public clickId:number;
    public addId:number;
    public advertisment:Advertisment;
    public accountId:string;
    public user:UserAccount;
    public clickDate:Date;
}