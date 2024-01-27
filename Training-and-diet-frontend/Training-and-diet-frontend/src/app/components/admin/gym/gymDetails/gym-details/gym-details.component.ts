import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GymDetailsAdmin } from 'src/app/models/admin/gym-details-admin.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-gym-details',
  templateUrl: './gym-details.component.html',
  styleUrls: ['./gym-details.component.css']
})
export class GymDetailsComponent implements OnInit {

gymId: string='';
gym: GymDetailsAdmin | undefined;
error: boolean = false;

constructor(private route: ActivatedRoute, private adminService: AdminService) {

  
}



  ngOnInit(): void {
    this.gymId = this.route.snapshot.params['id'];
    this.adminService.getGymById(this.gymId).subscribe({
      next: gym => {
        if(gym.status === "Pending"){
          this.error = true;
        }else{
        this.gym = gym;
        }
      },
      error: err => {
        this.error = true;
      }
    });
  }



}
