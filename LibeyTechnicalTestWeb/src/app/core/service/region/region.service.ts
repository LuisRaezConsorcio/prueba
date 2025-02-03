import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class RegionService {
  private baseUrl = `${environment.pathLibeyTechnicalTest}api/Region/`;

  constructor(private http: HttpClient) { }

  FindResponse(RegionCode: string): Observable<any> {
    const uri = `${this.baseUrl}${RegionCode}`;
    return this.http.get<any>(uri);
  }

  FindAll(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
