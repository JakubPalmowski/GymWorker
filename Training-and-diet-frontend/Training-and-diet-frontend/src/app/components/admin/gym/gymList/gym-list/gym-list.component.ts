import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { GymAdminInfo } from 'src/app/models/admin/gymAdminInfo';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-gym-list',
  templateUrl: './gym-list.component.html',
  styleUrls: ['./gym-list.component.css']
})
export class GymListComponent implements OnInit {
  
  constructor(private route: ActivatedRoute, private adminService: AdminService) { }

  status: string = '';
  gyms: GymAdminInfo[] = [];
  searchTerm: string = '';
  filteredGyms: GymAdminInfo[] = [];
  error:boolean = false;


  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => {
        this.status = params.get('status') ?? '';
        return this.adminService.getAllGymsAdmin(this.status);
      })
    ).subscribe({
      next: gyms => {
        this.gyms = gyms;
        this.filteredGyms = gyms;
        this.filterGyms(); // Ponownie zastosuj filtr, jeśli jest potrzebny.
      },
      error: err => {
        this.error = true;
      }
    });
  }
  
  filterGyms() {
    if (!this.searchTerm) {
      this.filteredGyms = this.gyms; 
    } else {
      this.filteredGyms = this.gyms.filter(gym =>
        gym.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        gym.city.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        gym.street.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

  deleteGym(gymId: number) {
    const gym = this.filteredGyms.find(g => g.idGym === gymId);
  
    if (gym) {
      const confirmDelete = confirm(`Czy na pewno chcesz usunąć siłownię:\nNazwa: ${gym.name}\nMiasto: ${gym.city}\nUlica: ${gym.street}?`);
      
      if (confirmDelete) {
        this.adminService.deleteGym(gymId).subscribe({
          next: () => {
            this.gyms = this.gyms.filter(g => g.idGym !== gymId);
            this.filteredGyms = this.filteredGyms.filter(g => g.idGym !== gymId);
            alert('Siłownia została usunięta.');
          },
          error: err => {
            alert('Wystąpił błąd podczas usuwania. Siłownia nie została usunięta.');
          }
        });
      }
    } else {
      alert('Siłownia nie została znaleziona.'); 
    }
  }
}
