import { UserAccount } from "../Accounts/user-account.model";
import { AuditableBase } from "../Common/auditable-base.model";
import { Marketer } from "../Marketers/marketer.model";
import { UserAddClick } from "./user-add-click.model";


export class Advertisment extends AuditableBase{

    public addId:number;
    public accountId:string;
    public user:UserAccount;
    public marketerId:string;
    public markerter:Marketer;
    public altText:string;
    public addData:string;
    public clicks:number;
    public impressions:number;
    public weight:number;
    public startDate:Date;
    public endDate:Date;
    public addClicks:UserAddClick[] = [];

}