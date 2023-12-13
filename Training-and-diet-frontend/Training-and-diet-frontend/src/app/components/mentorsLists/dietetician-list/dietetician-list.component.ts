import { Component, OnInit } from '@angular/core';
import { Mentor } from 'src/app/models/mentor';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dietetician-list',
  templateUrl: './dietetician-list.component.html',
  styleUrls: ['./dietetician-list.component.css']
})
export class DieteticianListComponent implements OnInit{

  constructor(private userService: UserService){
    
  }
  dieteticians: Mentor[]=[];

ngOnInit(): void{
  this.userService.GetAllDieteticians().subscribe({
    next:(dieteticians)=>{
      this.dieteticians=dieteticians;
    },
    error: (response)=>{
      console.log(response);
    }
  })
}

}

