
export interface FunilEtapa    {
  FunilEtapaId:number;
  NomeFunilEtapa: string;
  Negocios: Negocio[];

}

export interface Negocio  {
  NegocioId: number;
  Titulo: string;
  Organizacao: string;
  FunilEtapaId:number;

}
