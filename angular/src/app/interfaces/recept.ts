import { Ljekar } from "./ljekar";
import { Pacijent } from "./pacijent";

export class Recept {
  id: number;
  datumIzdavanja: string;
  doza: number;
  napomena: string;
  sifraBolesti: string;
  pacijent: Pacijent;
  ljekar: Ljekar;
}
