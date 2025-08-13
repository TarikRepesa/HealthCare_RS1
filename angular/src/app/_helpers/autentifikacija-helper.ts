import { LoginInformacije } from "./login-informacije";

export class AutentifikacijaHelper {

  static setLoginInfo(x: LoginInformacije): void {
    if (x == null)
      x = new LoginInformacije();
    localStorage.setItem("auth-token", JSON.stringify(x));
  }

  static getLoginInfo(): LoginInformacije {
    let x = localStorage.getItem("auth-token");
    if (x === "")
      return new LoginInformacije();

    try {
      let loginInformacije: LoginInformacije = JSON.parse(x);
      if (loginInformacije == null)
        return new LoginInformacije();
      return loginInformacije;
    }
    catch (e) {
      return new LoginInformacije();
    }
  }
  // static reloadLoginInfo(): void {
  //   let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().authToken;
  //   if (autentifikacijaToken == null) {
  //     alert("Unexpected error");
  //     return;
  //   }

  //   const httpClient = new HttpClient(new HttpXhrBackend({ build: () => new XMLHttpRequest() }));
  //   httpClient.get<AutentifikacijaToken>(Constants.apiRoot + `Auth/Get`, MojConfig.http_opcije()).subscribe(x => {
  //     let loginInfo = new LoginInformacije();
  //     loginInfo.authToken = x;
  //     loginInfo.isLogiran = true;
  //     loginInfo.isPermisijaAdmin = x.korisnickiNalog.isAdmin;
  //     loginInfo.isPermisijaVlasnik = x.korisnickiNalog.isVlasnik;
  //     loginInfo.isPermisijaKupac = x.korisnickiNalog.isKupac;

  //     AutentifikacijaHelper.setLoginInfo(loginInfo);
  //   });
  // }
}
