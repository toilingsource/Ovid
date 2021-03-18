/** Application User Model */
export class ApplicationUser {
    public isEnabled: boolean;
    public id: string;
    public userName: string;
    public normalizedUserName: string;
    public email: string;
    public normalizedEmail: string;
    public emailConfirmed: boolean;
    public phoneNumber: string;
    public phoneNumberConfirmed: boolean;
    public twoFactorEnabled: boolean;
    public lockoutEnd: Date;
    public lockoutEnabled: boolean;
    public accessFailedCount: number;
    public profileImage: string;
    public roles:string[];
  }
  