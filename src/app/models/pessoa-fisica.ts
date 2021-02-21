import { Base } from './base';

export interface PessoaFisica extends Base {

  Nome: string;
  Sobrenome: string;
  Cpf: string;
  Rg: string;
  DtNascimento: Date;
}
