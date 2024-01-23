import { Component, Input, OnInit } from '@angular/core';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'app-mentor-opinion',
  templateUrl: './mentor-opinion.component.html',
  styleUrls: ['./mentor-opinion.component.css']
})
export class MentorOpinionComponent implements OnInit {
  
  imageUrl: string = "";
  
  constructor(private fileService: FileService) {

    
  }

  @Input()
  rate:number=0;

  @Input()
  imageUri:string | undefined;

  @Input()
  pupilName:string='';

  @Input()
  content:string='';

  @Input()
  date:string="";

  ngOnInit(): void {
    if(this.imageUri){
      this.fileService.getFile(this.imageUri).subscribe(
        blob => {
          if (blob) {
            const objectUrl = URL.createObjectURL(blob);
            this.imageUrl = objectUrl;
          }
        },
        error => {
          this.imageUrl = "assets/images/user.png";
        }
      );
    }else{
      this.imageUrl = "assets/images/user.png";
    }
  }
}
