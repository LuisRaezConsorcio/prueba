import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { catchError, Observable, tap, throwError } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
  providedIn: "root",
})
export class LibeyUserService {

  private baseUrl = `${environment.pathLibeyTechnicalTest}LibeyUser/`;

  constructor(private http: HttpClient) { }

  Find(documentNumber: string): Observable<LibeyUser> {
    const uri = `${this.baseUrl}${documentNumber}`;
    return this.http.get<LibeyUser>(uri);
  }

  FindAll(): Observable<LibeyUser[]> {
    return this.http.get<LibeyUser[]>(this.baseUrl);
  }

  Create(user: any): Observable<any> {
    return this.http.post<any>(this.baseUrl, user);
  }

  Update(documentNumber: string, user: LibeyUser): Observable<any> {
    const uri = `${this.baseUrl}${documentNumber}`;
    return this.http.put<any>(uri, user);
  }

  Delete(documentNumber: string): Observable<any> {
    const uri = `${this.baseUrl}${documentNumber}`;
    return this.http.delete<any>(uri);
  }
}