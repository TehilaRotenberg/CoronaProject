import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Corona_vaccine } from 'src/app/models/Corona_vaccine';
import { IllnessDate } from 'src/app/models/IllnessDate';

import { PersonalInformation } from 'src/app/models/PersonalInformation';
import { Vaccine_company } from 'src/app/models/Vaccine_company';
import { PersonalInformationService } from 'src/app/Services/personal-information.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  prsonalInformations:PersonalInformation[]=[]
  constructor(private personalInfomationService:PersonalInformationService,private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
 this.load()
  }
  load()
  {
    this.personalInfomationService.getAll().subscribe(PersonalInformation=>{this.prsonalInformations=PersonalInformation})
    console.log(PersonalInformation)
  }
  DisplayingPersonalDetails(client:PersonalInformation)
  {
    this.personalInfomationService.status="diplay"
    this.personalInfomationService.client=client
  this.router.navigate(['app-personal-ditails']);
  }
  update(client:PersonalInformation)
  {
    this.personalInfomationService.client=client;
    this.personalInfomationService.status="update";
    this.router.navigate(['app-personal-ditails']);

    
 
  }
  delete(p:PersonalInformation)
  {
  this.personalInfomationService.Delete(p).subscribe(p=>{})
  }
  AddMember()
  {
    this.personalInfomationService.client=new PersonalInformation();
    this.personalInfomationService.client.vaccines.push(new Corona_vaccine())
    this.personalInfomationService.client.illnessDates.push(new IllnessDate())
    this.personalInfomationService.status="Add";
    this.router.navigate(['app-personal-ditails']);
  }
  
}
