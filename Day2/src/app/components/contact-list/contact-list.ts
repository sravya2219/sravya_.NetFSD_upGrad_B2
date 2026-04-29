import { Component } from '@angular/core';
import { Contact } from '../../models/contact.model';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-contact-list',
  imports: [CommonModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
contacts:Contact[]=[
   { id: 1, name: 'Sravya', email: 'sravya@gmail.com', phone: '1234567890' },
  { id: 2, name: 'Rahul', email: 'rahul@gmail.com', phone: '9876543210' }
];
}
