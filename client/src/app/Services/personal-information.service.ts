import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonalInformation } from '../models/PersonalInformation';
import { Observable } from 'rxjs/internal/Observable';
import { Vaccine_company } from '../models/Vaccine_company';
@Injectable({
  providedIn: 'root'
})
export class PersonalInformationService {
  url=" https://localhost:7055/api/personalinformation"
  client:PersonalInformation=new PersonalInformation();
  status!: string;
  constructor(private http:HttpClient) { }

  getAll():Observable<PersonalInformation[]>
  {
    return  this.http.get<PersonalInformation[]>(`${this.url}/getall`)
    
  }

  updateClient():Observable<string>
  {
 
    return this.http.post<string>(`${this.url}/update`,this.client);
  }
  Delete(personal:PersonalInformation):Observable<string>
  {
    return this.http.post<string>(`${this.url}/delete`,personal)
  }
  Add():Observable<string>
  {
    return this.http.post<string>(`${this.url}/add`,this.client)
  }

 

}
