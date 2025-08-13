import {Apoteka} from "./apoteka";
import {Proizvodjac} from "./proizvodjac";
import {Recept} from "./recept";

export interface Lijek {
  id: number;
  naziv: string;
  vrsta: string;
  kolicinaNaStanju: number;
  nacinUpotrebe: string;
  nuspojave: string;
  upozorenja: string;
  cijena: number;
  apotekaId: Apoteka;
  proizvodjacId: Proizvodjac;
  receptId: Recept;
}
