import { UserAccount } from "../Accounts/user-account.model";
import { AuditableBase } from "../Common/auditable-base.model";
import { SponsoredProduct } from "../Products/sponsored-product.model";
import { AccountRating } from "../Ratings/account-rating.model";
import { PostImage } from "./post-image.model";


export class UserPost extends AuditableBase{
    public postId:string;
    public accountId:string;
    public userAccount:UserAccount;
    public itemText:string;
    public itemRating:number;
    public reviewLink:string;
    public reviewText:string;
    public productId:string;
    public product:SponsoredProduct;
    public parentPostId:string;
    public ratings:AccountRating;
    public images:PostImage[] = [];
}