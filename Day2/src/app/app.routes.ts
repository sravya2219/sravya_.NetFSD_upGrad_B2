import { RouterModule,Routes } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { AddContact } from './components/add-contact/add-contact';
import { ContactDetails } from './components/contact-details/contact-details';
import { NgModule } from '@angular/core';
export const routes: Routes = [
    {path:'',redirectTo:'contacts', pathMatch:'full'},
    {path:'contacts', component:ContactList},
     {path:'add', component:AddContact},
     {path:'contactdetails', component:ContactDetails}

];

