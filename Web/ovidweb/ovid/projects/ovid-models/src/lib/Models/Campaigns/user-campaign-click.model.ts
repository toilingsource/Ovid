import { UserAccount } from "../Accounts/user-account.model";
import { Campaign } from "./campaign.model";


export class UserCampaignClick{
    public clickId:number;
    public clickDate:Date;
    public campaignId:string;
    public campaign:Campaign;
    public accountId:string;
    public user:UserAccount;
}