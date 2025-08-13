import { Karton } from "./karton";
import { Recept } from "./recept";
import { ZdravstvenaLegitimacija } from "./zdravstvenaLegitimacija";

export interface Pacijent {
    id: number;
    email: string;
    ime: string;
    prezime: string;
    brojTelefona: string;
    datumRodenja: string;
    mjestoRodenja: string;
    slika: any;
    zdravstvenaLegitimacija: ZdravstvenaLegitimacija;
    karton: Karton;
}
