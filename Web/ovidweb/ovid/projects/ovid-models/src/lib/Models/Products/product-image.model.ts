import { AuditableBase } from "../Common/auditable-base.model";
import { SponsoredProduct } from "./sponsored-product.model";



export class ProductImage extends AuditableBase{
        public imageId:number;
        public productId:string;
        public sponsoredProduct:SponsoredProduct;
        public altText:string;
        public imageData:string;
}