import { SponsoredProduct } from "./sponsored-product.model";



export class ProductCategory{
    public categoryId:number;
    public name:string;
    public icon:string;
    public products:SponsoredProduct[] = [];
}