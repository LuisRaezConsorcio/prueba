import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DocumenttypeService {

  private baseUrl = `${environment.pathLibeyTechnicalTest}api/DocumentType`;

  constructor(private http: HttpClient) { }

  Find(DocumentTypeId: number): Observable<any> {
    const uri = `${this.baseUrl}/${DocumentTypeId}`;
    return this.http.get<any>(uri);
  }

  FindAll(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
