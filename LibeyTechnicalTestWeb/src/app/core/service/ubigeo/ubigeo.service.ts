import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class UbigeoService {
  private baseUrl = `${environment.pathLibeyTechnicalTest}api/Ubigeo/`;

  constructor(private http: HttpClient) { }

  FindResponse(UbigeoId: string): Observable<any> {
    const uri = `${this.baseUrl}${UbigeoId}`;
    return this.http.get<any>(uri);
  }

  GetByRegionAndProvince(regionCode: string, provinceCode: string): Observable<any[]> {
    const uri = `${this.baseUrl}${regionCode}, ${provinceCode}`;
    return this.http.get<any[]>(uri);
  }

  FindAll(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
