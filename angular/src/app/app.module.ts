import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from '@auth0/auth0-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { TodoComponent } from './todo/todo.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TodoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    AuthModule.forRoot({
      domain: 'dev-8uhb8pxg7x8zh2oe.us.auth0.com',
      clientId: 'zH9IHJ3TvqUQolGdYceuxgqXAqGSE2m1',
      authorizationParams: {
        redirect_uri: "https://localhost:4200/todo"
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
