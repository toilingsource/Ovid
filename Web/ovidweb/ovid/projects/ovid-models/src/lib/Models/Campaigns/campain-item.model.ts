import { SponsoredProduct } from "../Products/sponsored-product.model";
import { Campaign } from "./campaign.model";
import { UserCampaignItemClick } from "./user-campaign-item-click.model";


export class CampaignItem {
    public campItemId: number;
    public campaignId: string;
    public campaign: Campaign;
    public productId: string;
    public product: SponsoredProduct;
    public salePrice: number;
    public regularPrice: number;
    public salesText: string;
    public campaignLink: string;
    public clicks: number;
    public ItemClicks: UserCampaignItemClick[] = [];
}