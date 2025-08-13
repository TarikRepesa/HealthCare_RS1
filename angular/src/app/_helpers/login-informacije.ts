import { Korisnik } from "../Models/Korisnik";

export class LoginInformacije {
  authToken: AutentifikacijaToken;
  isLogiran: boolean = false;
  isPermisijaAsistent: boolean = false;
  isPermisijaFarmaceut: boolean = false;
  isPermisijaTehnicar: boolean = false;
  isPermisijaLjekar: boolean = false;
  isPermisijaPacijent: boolean = false;
  isPermisijaAdmin: boolean = false;
}


export class AutentifikacijaToken {
  id:                   number;
  token:           string;
  korisnikId:    string;
  korisnik:      Korisnik;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
  isAllowed2FA:      boolean;
}
