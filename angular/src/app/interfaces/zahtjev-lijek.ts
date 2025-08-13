import {Apoteka} from "./apoteka";
import { Ljekar } from "./ljekar";

export interface ZahtjevLijek {
  id: number;
  naziv: string;
  kolicina: number;
  apoteka: Apoteka;
  apotekaId: string;
  ljekar: Ljekar;
  ljekarId: string;
}
