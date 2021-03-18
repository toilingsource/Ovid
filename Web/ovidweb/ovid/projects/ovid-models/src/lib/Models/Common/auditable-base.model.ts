import { IAuditable } from "./iauditable.model";


export abstract class AuditableBase implements IAuditable{
    public createdBy:string;
    public created:Date;
    public updatedBy:string;
    public updated:Date;

    constructor(){
        this.created = new Date();
        this.updated = new Date();
        this.updatedBy = '';
        this.createdBy = '';
    }
}