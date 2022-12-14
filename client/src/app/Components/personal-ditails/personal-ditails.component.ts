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
date:Date=new Date()
  constructor(public personalinformationService:PersonalInformationService, private vaccinCompanyServer:VaccineCompanyService) { 
    console.log(personalinformationService.client.vaccines)
    console.log(this.personalinformationService.status)
   
  }

  ngOnInit(): void {
    var coronavaccin:Corona_vaccine[]=[]
    this.date=new Date(this.personalinformationService.client.birthday)
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
  console.log(this.personalinformationService.status)
  this.personalinformationService.Add().subscribe(message=>{
    alert(message);
  })
}
else
{
  this.personalinformationService.updateClient().subscribe(message=>{
   alert(message);
  })
}

}
selected(i:number,company:any)
{
  console.log(i)
  console.log(company.value)
this.personalinformationService.client.vaccines[i].vaccine_Company.company_name=company.value;
console.log(this.personalinformationService.client)
}

}

function getDate(birthday: Date): any {
  throw new Error('Function not implemented.');
}
