import { Component, ViewChild } from '@angular/core';
import { Contato } from '../Models/Contato';
import { ContatoService } from '../Services/contato.service';
import {
  faCoffee,
  faEye,
  faPencil,
  faTrash,
} from '@fortawesome/free-solid-svg-icons';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-lista-contatos',
  templateUrl: './lista-contatos.component.html',
  styleUrl: './lista-contatos.component.css',
})
export class ListaContatosComponent {
  @ViewChild('modal') modal!: ModalComponent;
  contatos: Contato[] = [];
  contatosFiltrados: Contato[] = [];
  olho = faEye;
  lapis = faPencil;
  lixo = faTrash;

  constructor(private contatoService: ContatoService) {}

  ngOnInit() {
    this.obterContatos();
  }

  obterContatos() {
    this.contatoService.obterContatos().subscribe((contatos) => {
      this.contatos = contatos;
      this.contatosFiltrados = contatos;
    });
  }

  buscarContato(event: Event): void {
    const valor = (event.target as HTMLInputElement).value.toLowerCase();

    if (valor === '') {
      this.contatosFiltrados = this.contatos;
    } else {
      this.contatosFiltrados = this.contatos.filter(
        (contato) =>
          contato.nome.toLowerCase().includes(valor) ||
          contato.telefones.some((telefone) => telefone.numero.includes(valor))
      );
    }
  }

  abrirModalDetalhes(index: number) {
    this.modal.abrirModalDetalhes(this.contatosFiltrados[index]);
  }

  abrirModalEditar(index: number) {
    this.modal.abrirModalEditar(this.contatosFiltrados[index]);
  }

  deletarContato(index: number) {
    let confirmar = confirm(
      'Ao deletar o contato ele não poderá ser recuperado. Deseja continuar?'
    );
    if (confirmar) {
      this.contatoService
        .deletarContato(this.contatosFiltrados[index].id)
        .subscribe();
      alert('Contato deletado com sucesso!');
    }
  }
}
