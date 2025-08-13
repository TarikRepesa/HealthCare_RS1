import {Bolnica} from "./bolnica";

export interface Odjeljenje{
  id: number;
  naziv: string;
  brojOsoblja: number;
  vrsta: string;
  bolnicaId: Bolnica;

}
