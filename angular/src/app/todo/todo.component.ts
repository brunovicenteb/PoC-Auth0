import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

interface ToDoItem {
  id: number;
  title: string;
  isCompleted: boolean;
}

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  todoItems: ToDoItem[] = [];

  constructor(private http: HttpClient, private auth: AuthService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  private loadTodos(): void {
    this.auth.getAccessTokenSilently().subscribe(token => {
      this.http.get<ToDoItem[]>('http://localhost:5000/api/todo', {
        headers: {
          Authorization: `Bearer ${token}`
        }
      })
      .subscribe(data => {
        this.todoItems = data;
      }, error => {
        console.error('Error fetching todo items:', error);
      });
    }, error => {
      console.error('Error obtaining access token:', error);
    });
  }
}
