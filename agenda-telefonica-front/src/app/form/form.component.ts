import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Contato } from '../Models/Contato';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { ContatoService } from '../Services/contato.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent {
  @Input() editarContato!: Contato;
  @Output() fechar: EventEmitter<boolean> = new EventEmitter();
  contato: Contato = {
    id: 0,
    nome: '',
    telefones: [],
  };
  telefones!: string;
  adicionar = faPlus;
  remover = faMinus;

  constructor(private contatoService: ContatoService) {}

  ngOnInit() {
    if (this.editarContato) {
      this.contato = { ...this.editarContato };
    }
  }

  adicionarTelefone() {
    if (
      this.telefones != '' &&
      this.telefones != null &&
      this.telefones != undefined
    ) {
      this.contato.telefones.push({ numero: this.telefones });
      this.telefones = '';
    }
  }

  removerTelefone(index: number) {
    this.contato.telefones.splice(index, 1);
  }

  onSubmit() {
    if (!this.editarContato) {
      if (this.contato.telefones.length < 1) {
        alert('O contato deve conter pelo menos um número de telefone!');
      } else {
        this.contatoService.criarContato(this.contato).subscribe();
        
        this.contato.nome = '';
        this.contato.idade = 0;
        this.contato.telefones = [];
        alert(`Contato ${this.contato.nome} salvo com sucesso!`);
      }
    } else {
      if (this.contato.telefones.length < 1) {
        alert('O contato deve conter pelo menos um número de telefone!');
      } else {
        this.contatoService
          .editarContato(this.contato.id, this.contato)
          .subscribe();
          this.fechar.emit(false);
        alert(`Contato ${this.contato.nome} foi editado com sucesso!`);
      }
    }
  }
}
