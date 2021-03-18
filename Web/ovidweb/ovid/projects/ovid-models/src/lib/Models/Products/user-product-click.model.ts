import { UserAccount } from "../Accounts/user-account.model";
import { SponsoredProduct } from "./sponsored-product.model";


export class UserProductClick{
    public clickId:number;
    public clickDate:Date;
    public productId:string;
    public product:SponsoredProduct;
    public accountId:string;
    public user:UserAccount;
} 