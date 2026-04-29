import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { ContactDetails } from './components/contact-details/contact-details';
import { AddContact } from './components/add-contact/add-contact';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet,ContactList,ContactDetails,AddContact, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('my-app');
}
