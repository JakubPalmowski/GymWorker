import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of } from 'rxjs';
import { UploadImageResponse } from '../models/file/uploadImageResponse';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http: HttpClient) { }

  getImage(imageUri: string): Observable<Blob> {
    return this.http.get('https://localhost:7259/api/File/' + imageUri, { responseType: 'blob' });
  }

  uploadImage(file: File): Observable<UploadImageResponse> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post<UploadImageResponse>('https://localhost:7259/api/File', formData);
  }

  deleteImage(imageUri: string): Observable<boolean> {
    return this.http.delete('https://localhost:7259/api/File/delete/' + imageUri, { responseType: 'text' })
      .pipe(
        map(response => response.includes('deleted successfully')), // zwróci `true`, jeśli odpowiedź zawiera tekst o sukcesie
        catchError(error => {
          console.error('Error during image deletion', error);
          return of(false); // zwróci `false` w przypadku błędu
        })
      );
  }
  

  
  
}
