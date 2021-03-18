import { IntrestList } from "../Common/intrest-list.model";
import { UserAccount } from "./user-account.model";



export class UserIntrest{
    public userIntrestId:number;
    public accountId:string;
    public user:UserAccount;
    public intrestId:number;
    public intrest:IntrestList;
}