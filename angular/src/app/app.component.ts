import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Router } from '@angular/router'; // Importando Router para navegação

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public auth: AuthService, private router: Router) {} // Injetando Router

  login(): void {
    this.auth.loginWithRedirect();
  }

  logout(): void {
    this.auth.logout({ }); // Redireciona para a página inicial após logout
  }

  redirectToTodos(): void {
    this.router.navigate(['/todos']); // Redireciona para a página de ToDo
  }
}
