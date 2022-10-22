import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonalInformation } from '../models/PersonalInformation';
import { Observable } from 'rxjs/internal/Observable';
@Injectable({
  providedIn: 'root'
})
export class PersonalInformationService {
  url="https://localhost:7186/api/personalinformation"
  constructor(private http:HttpClient) { }

  getAll():Observable<PersonalInformation[]>
  {
    return  this.http.get<PersonalInformation[]>(`${this.url}/getall`)
  }
  get():Observable<string>
  {
    return this.http.get<string>(`${this.url}/get`)
  }
}
