import { UserAccount } from "../Accounts/user-account.model";
import { CampaignItem } from "./campain-item.model";


export class UserCampaignItemClick{
    public clickId:number;
    public clickDate:Date;
    public campItemId:number;
    public item:CampaignItem;
    public accountId:string;
    public user:UserAccount;
}