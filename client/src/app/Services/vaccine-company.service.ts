import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retryWhen } from 'rxjs';
import { Vaccine_company } from '../models/Vaccine_company';

@Injectable({
  providedIn: 'root'
})
export class VaccineCompanyService {
url="https://localhost:7055/api/vaccine_company"
  constructor(private http:HttpClient) { }
  getAll():Observable<Vaccine_company[]>
  {
    return this.http.get<Vaccine_company[]>(`${this.url}/getall`)
  }
}
