import { UserAccount } from "../Accounts/user-account.model";


export class SocialFeed{
    public feedId:number;
    public accountId:string;
    public user:UserAccount;
    public provider:string;
    public pullFeeds:boolean;
    public crossPost:boolean;
    public followers:number;
    public link:string;
}