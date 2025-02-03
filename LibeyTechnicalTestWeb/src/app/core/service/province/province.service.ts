import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class ProvinceService {
  private baseUrl = `${environment.pathLibeyTechnicalTest}api/Province/`;

  constructor(private http: HttpClient) { }

  FindResponse(ProvinceId: string): Observable<any> {
    const uri = `${this.baseUrl}FindResponse?ProvinceId=${ProvinceId}`;
    return this.http.get<any>(uri);
  }

  GetByRegion(RegionCode: string): Observable<any[]> {
    const uri = `${this.baseUrl}GetByRegion?RegionCode=${RegionCode}`;
    return this.http.get<any[]>(uri);
  }

  FindAll(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
