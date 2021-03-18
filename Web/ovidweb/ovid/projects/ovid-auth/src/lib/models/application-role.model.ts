/** Application Role Model */
export class ApplicationRole {
    public description: string;
    public createdBy: string;
    public updatedBy: string;
    public createdDate: Date;
    public updatedDate: Date;
    public id: string;
    public name: string;
    public normalizedName: string;
    public concurrencyStamp: string;
  }
  
  
  export class UserRoles {
  
    public friendlyName: string = '';
    public roleName: string = '';
    public icon: string = '';
  
    constructor(role: string) {
      this.roleName = role;
      if (role === 'ovidsupport') {
        this.friendlyName = "Support Team";
      } else if (role === 'ovidadmin') {
        this.friendlyName = "Administrator";
        this.icon = '';
      } else if (role === 'ovidinfluencer') {
        this.friendlyName = "Influencer";
        this.icon = '';
      } else if (role === 'ovidmarekter') {
        this.friendlyName = "Marketer";
        this.icon = '';
      } else if (role === 'oviduser') {
        this.friendlyName = "User";
        this.icon = '';
      }
    }
  }
  