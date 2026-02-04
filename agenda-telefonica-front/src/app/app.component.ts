import { Component } from '@angular/core';
import { Contato } from './Models/Contato';
import { ContatoService } from './Services/contato.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'agenda-telefonica';
  contatos: Contato[] = [];

  constructor(private contatoService: ContatoService) {}

  ngOnInit() {
    this.contatoService
      .obterContatos()
      .subscribe((contatos) => (this.contatos = contatos));
  }
}
