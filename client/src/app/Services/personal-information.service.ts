import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonalInformation } from '../models/PersonalInformation';
import { Observable } from 'rxjs/internal/Observable';
import { Vaccine_company } from '../models/Vaccine_company';
import { Personal } from '../models/Personal';
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
  Delete(personal:PersonalInformation):Observable<PersonalInformation>
  {
    console.log(personal);
    let p=new Personal()
   
    return this.http.post<PersonalInformation>(`${this.url}/delete`,personal)
  }
  Add():Observable<string>
  {
    return this.http.post<string>(`${this.url}/add`,this.client)
  }

 

}
