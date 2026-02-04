import { Component } from '@angular/core';
import { Contato } from '../Models/Contato';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {

  detalhes: boolean = false
  editar: boolean = false
  titulo: string = "Contato"
  contato!: Contato

  abrirModalDetalhes(contato: Contato){
    this.contato = contato
    this.detalhes = true
  }

  abrirModalEditar(contato: Contato){
    this.contato = contato
    this.editar = true
  }

  fecharModal(){
   this.detalhes == true? this.detalhes = false : this.editar = false
  }
  fecharModalEditar(event: boolean){
    this.editar = event
  }
}
