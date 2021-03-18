import { UserAccount } from "../Accounts/user-account.model";
import { Advertisment } from "../Advertising/advertisment.model";
import { SponsoredProduct } from "../Products/sponsored-product.model";


export class Marketer{
    public marketerId:string;
    public name:string;
    public logo:string;
    public webSite:string;
    public supportUrl:string;
    public description:string;
    public contactEmail:string;
    public supportPhone:string;
    public userId:string;
    public user:UserAccount;
    public sponsoredProducts:SponsoredProduct[] = [];
    public advertisments:Advertisment[] = [];

}