import { UserAccount } from "../Accounts/user-account.model";
import { UserPost } from "../Post/user-post.model";


export class AccountRating{
    public rattingId:number;
    public postId:string;
    public userPost:UserPost;
    public accountId:string;
    public userAccount:UserAccount;
    public rating:number;
    public ratingText:string;
}