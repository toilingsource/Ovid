import { UserAccount } from "../Accounts/user-account.model";
import { CampaignType } from "./campaign-type.model";
import { CampaignItem } from "./campain-item.model";
import { UserCampaignClick } from "./user-campaign-click.model";


export class Campaign{
    public CampaignId:string;
    public TypeId:number;
    public CampaignType:CampaignType;
    public accountId:string;
    public user:UserAccount;
    public StartDate:Date;
    public EndDate:Date;
    public Graphic:string;
    public Width:number;
    public Height:number;
    public Clicks:number;
    public Impressions:number;
    public Items:CampaignItem[] = [];
    public UserClicks:UserCampaignClick[] = [];
}