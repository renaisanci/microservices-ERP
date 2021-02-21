import { Base } from './base';
export interface User extends Base {
  Username: string;
  Password: string;
  PrimeiroNome: string;
  UltimoNome: string;
  Token: string;
}
