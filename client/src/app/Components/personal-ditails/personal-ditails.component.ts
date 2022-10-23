import { Component, OnInit } from '@angular/core';
import { Corona_vaccine } from 'src/app/models/Corona_vaccine';
import { IllnessDate } from 'src/app/models/IllnessDate';
import { PersonalInformation } from 'src/app/models/PersonalInformation';
import { Vaccine_company } from 'src/app/models/Vaccine_company';
import { PersonalInformationService } from 'src/app/Services/personal-information.service';
import { VaccineCompanyService } from 'src/app/Services/vaccine-company.service';

@Component({
  selector: 'app-personal-ditails',
  templateUrl: './personal-ditails.component.html',
  styleUrls: ['./personal-ditails.component.css']
})
export class PersonalDitailsComponent implements OnInit {
vaccinCompanies:Vaccine_company[]=[]
  constructor(public personalinformationService:PersonalInformationService, private vaccinCompanyServer:VaccineCompanyService) { 
    console.log(personalinformationService.client.vaccines)
   
  }

  ngOnInit(): void {
    var coronavaccin:Corona_vaccine[]=[]
   
    this.getVaccinCompany()
    console.log(this.vaccinCompanies)
     this.personalinformationService.client.vaccines.forEach(element => {
    if(element!=null)
    {
      coronavaccin.push(element)
    }
    this.personalinformationService.client.vaccines=coronavaccin
  });
 
  }

getVaccinCompany()
{
  this.vaccinCompanyServer.getAll().subscribe(companies=>{this.vaccinCompanies=companies})
}
addLine()
{
  this.personalinformationService.client.vaccines.push(new Corona_vaccine())
}
deleteLine(vaccine:Corona_vaccine)
{
this.personalinformationService.client.vaccines.splice(this.personalinformationService.client.vaccines.indexOf(vaccine))
}
addLineillness()
{
  this.personalinformationService.client.illnessDates.push(new IllnessDate())

}
deleteLineillness(illness:IllnessDate)
{
this.personalinformationService.client.illnessDates.splice(this.personalinformationService.client.illnessDates.indexOf(illness))
}
save()
{
if(this.personalinformationService.status=="Add")
{
  this.personalinformationService.Add().subscribe(client=>{
    if(client==null)
    {
      alert("השמירה נכשלה")
    }
    else
    {
      alert("השמירה בוצעה בהצלחה")
    }
  })
}
else
{
  this.personalinformationService.updateClient().subscribe(client=>{
    if(client==null)
    {
      alert("השמירה נכשלה")
    }
    else
    {
      alert("השמירה בוצעה בהצלחה")
    }
  })
}

}}