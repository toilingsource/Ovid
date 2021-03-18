import { AuditableBase } from "../Common/auditable-base.model";
import { Marketer } from "../Marketers/marketer.model";
import { ProductCategory } from "./product-category.model";
import { ProductImage } from "./product-image.model";
import { UserProductClick } from "./user-product-click.model";



export class SponsoredProduct extends AuditableBase{
    public productId:string;
    public markerterId:string;
    public marketer:Marketer;
    public categoryId:string;
    public category:ProductCategory;
    public name:string;
    public productLink:string;
    public description:string;
    public infromation:string;
    public price:number;
    public infulencePrice:number;
    public numberSold:number;
    public keyWords:string;
    public images:ProductImage[] = [];
    public productClicks:UserProductClick[] = [];
}