import { Advertisment } from "../Advertising/advertisment.model";
import { UserAddClick } from "../Advertising/user-add-click.model";
import { Campaign } from "../Campaigns/campaign.model";
import { UserCampaignClick } from "../Campaigns/user-campaign-click.model";
import { UserCampaignItemClick } from "../Campaigns/user-campaign-item-click.model";
import { AuditableBase } from "../Common/auditable-base.model";
import { Ocupation } from "../Common/ocupation.model";
import { Salary } from "../Common/salalary.model";
import { Marketer } from "../Marketers/marketer.model";
import { PostImage } from "../Post/post-image.model";
import { UserPost } from "../Post/user-post.model";
import { UserProductClick } from "../Products/user-product-click.model";
import { AccountRating } from "../Ratings/account-rating.model";
import { SocialFeed } from "../SocialMedia/social-feed.model";
import { AccountType } from "./account-type.model";
import { Followed } from "./followed.model";
import { UserIntrest } from "./user-intrest.model";



export class UserAccount extends AuditableBase{
    public accountId:string;
    public userId:string;
    public typeId:string;
    public accountType:AccountType;
    public displayName:string;
    public dateOfBirth:Date;
    public lastLoginIp:string;
    public country:string;
    public province:string;
    public city:string;
    public postalCode:string;
    public ocupationId:number;
    public ocupation:Ocupation;
    public salaryId:string;
    public salalary:Salary;
    public avatar:string;
    public reputationPoints:number;


    public userPosts:UserPost[] = [];
    public postImages:PostImage[] = [];
    public ratings:AccountRating[] = [];
    public socialFeeds:SocialFeed[] = [];
    public advertisments:Advertisment[] = [];
    public intrests:UserIntrest[] = [];
    public followers:Followed[] = [];
    public followed:Followed[] = [];
    public campaigns:Campaign[] = [];
    public marketers:Marketer[] = [];
    public userAddClicks:UserAddClick[] =[];
    public campaignClicks:UserCampaignClick[] = [];
    public campaignItemClicks:UserCampaignItemClick[] =[];
    public productClicks:UserProductClick[] = [];
}