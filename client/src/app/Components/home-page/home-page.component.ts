import { Component, OnInit } from '@angular/core';
import { PersonalInformation } from 'src/app/models/PersonalInformation';
import { PersonalInformationService } from 'src/app/Services/personal-information.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  prsonalInformations:PersonalInformation[]=[]
  constructor(private personalInfomationService:PersonalInformationService) { }

  ngOnInit(): void {
 this.load()
  }
  load()
  {
    this.personalInfomationService.getAll().subscribe(PersonalInformation=>{this.prsonalInformations=PersonalInformation})
  }
  DisplayingPersonalDetails()
  {
    
  }

}
