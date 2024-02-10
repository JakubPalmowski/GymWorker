import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Certificate } from '../models/certificate/certificate.model';
import { CertificateCreate } from '../models/certificate/certificate-create.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CertificateService {

  constructor(private http: HttpClient) { }

  public GetUserCertificates():Observable<Certificate[]> {
    return this.http.get<Certificate[]>(environment.apiUrl+'Certificate');
  }

  addCertificate(certificate: CertificateCreate): Observable<any> {
    const formData: FormData = new FormData();
    if (certificate.pdfFile) {
        formData.append('PdfFile', certificate.pdfFile, certificate.pdfFile.name);
    }
    formData.append('Description', certificate.description);

    return this.http.post<FormData>(environment.apiUrl+'Certificate', formData);
}


  
  
  
}
