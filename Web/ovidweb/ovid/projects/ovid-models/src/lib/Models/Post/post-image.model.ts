import { UserAccount } from "../Accounts/user-account.model";
import { UserPost } from "./user-post.model";


export class PostImage{
    public imageId:number;
    public altText:string;
    public imageData:string;
    public accountId:string;
    public user:UserAccount;
    public postId:string;
    public post:UserPost;
}