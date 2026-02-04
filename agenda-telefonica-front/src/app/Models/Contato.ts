import { Telefone } from "./Telefone";

export interface Contato {
  id: number;
  nome: string;
  idade?: number;
  telefones: Telefone[];
}
