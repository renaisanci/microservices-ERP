import { Base } from './base';

export interface PessoaJuridica extends Base {
  NomeFantasia: string;
  Cnpj: string;
  RazaoSocial: string;
}
