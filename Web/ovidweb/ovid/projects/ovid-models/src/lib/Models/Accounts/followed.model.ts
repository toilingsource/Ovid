import { UserAccount } from "./user-account.model";


export class Followed{
    public followId:number;
    public followerId:string;
    public follower:UserAccount;
    public followedId:string;
    public followedAccount:UserAccount;
    public sendNotifications:boolean;
}