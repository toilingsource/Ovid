import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  /** Base API Endpoint */
  public get ApiUrl() { return "https://keeper.mj-2.com"; } // TODO  Site URL
  /** Authentication Server Endpoint */
  public get AuthenticationServer() { return "https://keeper.mj-2.com"; } // TODO  Site URL

  constructor() { }
}
