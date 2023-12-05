
import { EventEmitter } from '@angular/core';
import { Trainer } from '../models/trainer';



export class TrainerService{
    trainers: Trainer[] = [
        {
          id: 1,
          role: 'Trainer',
          name: 'John',
          lastName: 'Doe',
          address: {
            id: 1,
            city: 'City1',
            street: 'Street1',
            postalCode: '12345'
          },
          phoneNumber: '123-456-7890',
          photoUrl: '../../../assets/images/rafon1.png'
        },
        {
          id: 2,
          role: 'Trainer',
          name: 'Jane',
          lastName: 'Smith',
          address: {
            id: 2,
            city: 'City2',
            street: 'Street2',
            postalCode: '67890'
          },
          phoneNumber: '987-654-3210',
          photoUrl: '../../../assets/images/harry1.png'
        },
        {
          id: 3,
          role: 'Trainer',
          name: 'Bob',
          lastName: 'Johnson',
          address: {
            id: 3,
            city: 'City3',
            street: 'Street3',
            postalCode: '13579'
          },
          phoneNumber: '555-123-4567',
          photoUrl: '../../../assets/images/diho1.png'
        },
        {
          id: 4,
          role: 'Trainer',
          name: 'Alice',
          lastName: 'Williams',
          address: {
            id: 4,
            city: 'City4',
            street: 'Street4',
            postalCode: '24680'
          },
          phoneNumber: '777-987-6543',
          photoUrl: '../../../assets/images/sentino1.png'
        },
        {
          id: 5,
          role: 'Trainer',
          name: 'Chris',
          lastName: 'Brown',
          address: {
            id: 5,
            city: 'City5',
            street: 'Street5',
            postalCode: '10101'
          },
          phoneNumber: '111-222-3333',
          photoUrl: '../../../assets/images/rafon2.png'
        },
        {
          id: 6,
          role: 'Trainer',
          name: 'David',
          lastName: 'Miller',
          address: {
            id: 6,
            city: 'City6',
            street: 'Street6',
            postalCode: '20202'
          },
          phoneNumber: '444-555-6666',
          photoUrl: '../../../assets/images/harry2.png'
        },
        {
          id: 7,
          role: 'Trainer',
          name: 'Emma',
          lastName: 'Davis',
          address: {
            id: 7,
            city: 'City7',
            street: 'Street7',
            postalCode: '30303'
          },
          phoneNumber: '777-888-9999',
          photoUrl: '../../../assets/images/sentino2.png'
        },
        {
          id: 8,
          role: 'Trainer',
          name: 'Frank',
          lastName: 'Jones',
          address: {
            id: 8,
            city: 'City8',
            street: 'Street8',
            postalCode: '40404'
          },
          phoneNumber: '333-222-1111',
          photoUrl: '../../../assets/images/diho2.png'
        },
        {
          id: 9,
          role: 'Trainer',
          name: 'Grace',
          lastName: 'Taylor',
          address: {
            id: 9,
            city: 'City9',
            street: 'Street9',
            postalCode: '50505'
          },
          phoneNumber: '999-888-7777',
          photoUrl: '../../../assets/images/diho3.png'
        },
        {
          id: 10,
          role: 'Trainer',
          name: 'Henry',
          lastName: 'White',
          address: {
            id: 10,
            city: 'City10',
            street: 'Street10',
            postalCode: '60606'
          },
          phoneNumber: '666-555-4444',
          photoUrl: '../../../assets/images/harry3.png'
        },
        {
          id: 11,
          role: 'Trainer',
          name: 'Ivy',
          lastName: 'Moore',
          address: {
            id: 11,
            city: 'City11',
            street: 'Street11',
            postalCode: '70707'
          },
          phoneNumber: '111-222-3333',
          photoUrl: '../../../assets/images/sentino3.png'
        },
        {
          id: 12,
          role: 'Trainer',
          name: 'Jack',
          lastName: 'Johnson',
          address: {
            id: 12,
            city: 'City12',
            street: 'Street12',
            postalCode: '80808'
          },
          phoneNumber: '444-555-6666',
          photoUrl: '../../../assets/images/rafon3.png'
        },
        {
          id: 13,
          role: 'Trainer',
          name: 'Karen',
          lastName: 'Lee',
          address: {
            id: 13,
            city: 'City13',
            street: 'Street13',
            postalCode: '90909'
          },
          phoneNumber: '777-888-9999',
          photoUrl: '../../../assets/images/harry4.png'
        },
        {
          id: 14,
          role: 'Trainer',
          name: 'Luke',
          lastName: 'Davis',
          address: {
            id: 14,
            city: 'City14',
            street: 'Street14',
            postalCode: '101010'
          },
          phoneNumber: '333-222-1111',
          photoUrl: '../../../assets/images/sentino4.png'
        },
        {
          id: 15,
          role: 'Trainer',
          name: 'Mia',
          lastName: 'Martin',
          address: {
            id: 15,
            city: 'City15',
            street: 'Street15',
            postalCode: '111111'
          },
          phoneNumber: '999-888-7777',
          photoUrl: '../../../assets/images/rafon4.png'
        },
        {
          id: 16,
          role: 'Trainer',
          name: 'Nathan',
          lastName: 'White',
          address: {
            id: 16,
            city: 'City16',
            street: 'Street16',
            postalCode: '121212'
          },
          phoneNumber: '666-555-4444',
          photoUrl: '../../../assets/images/diho4.png'
        },
        {
          id: 17,
          role: 'Trainer',
          name: 'Olivia',
          lastName: 'Brown',
          address: {
            id: 17,
            city: 'City17',
            street: 'Street17',
            postalCode: '131313'
          },
          phoneNumber: '111-222-3333',
          photoUrl: '../../../assets/images/rafon5.png'
        },
        {
          id: 18,
          role: 'Trainer',
          name: 'Peter',
          lastName: 'Jones',
          address: {
            id: 18,
            city: 'City18',
            street: 'Street18',
            postalCode: '141414'
          },
          phoneNumber: '444-555-6666',
          photoUrl: '../../../assets/images/sentino5.png'
        },
        {
          id: 19,
          role: 'Trainer',
          name: 'Quinn',
          lastName: 'Taylor',
          address: {
            id: 19,
            city: 'City19',
            street: 'Street19',
            postalCode: '151515'
          },
          phoneNumber: '777-888-9999',
          photoUrl: '../../../assets/images/harry5.png'
        },
        {
          id: 20,
          role: 'Trainer',
          name: 'Rachel',
          lastName: 'Miller',
          address: {
            id: 20,
            city: 'City20',
            street: 'Street20',
            postalCode: '161616'
          },
          phoneNumber: '333-222-1111',
          photoUrl: '../../../assets/images/diho5.png'
        },
      ];

      /* OnTrainerDetailsClicked = new EventEmitter<Trainer>(); 
      currentTrainer: Trainer;

    

      OnShowTrainerDetails(trainer: Trainer){
        this.OnTrainerDetailsClicked.emit(trainer);
      } */
      currentTrainer: Trainer | undefined;
      setTrainer(trainer: Trainer){
        this.currentTrainer=trainer;
      }

      getTrainer(){
        return this.currentTrainer;
      }

      GetAllTrainers(){
        return this.trainers;
      }
}