import { Base } from './base';
export interface Menu extends Base {
  Badge: string;
  BadgeValue: string;
  Children?: Children[];
  DescMenu: string;
  Icon: string;
  MenuPaiId: string;
  ModuloId: string;
  Nivel: string;
  Ordem: string;
  State: string;
  Type: string;
}


export interface Children extends Base {
  Badge: string;
  BadgeValue: string;
  Children?: Children[];
  DescMenu: string;
  Icon: string;
  MenuPaiId: string;
  ModuloId: string;
  Nivel: string;
  Ordem: string;
  State: string;
  Type: string;
}
