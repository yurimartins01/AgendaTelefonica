import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contato } from '../Models/Contato';

@Injectable({
  providedIn: 'root',
})
export class ContatoService {
  urlApi = 'https://localhost:7016/api/Contatos';
  constructor(private http: HttpClient) {}

  obterContatos(): Observable<Contato[]> {
    return this.http.get<Contato[]>(`${this.urlApi}`)
  }

  criarContato(contato: Contato) {
    return this.http.post<Contato>(`${this.urlApi}`, contato)
  }

  editarContato(id:number, contato: Contato){
    return this.http.put<Contato>(`${this.urlApi}/${id}`,contato)
  }

  deletarContato(id: number){
    return this.http.delete<Contato>(`${this.urlApi}/${id}`)
  }

}
