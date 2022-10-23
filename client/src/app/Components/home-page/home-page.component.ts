import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { PersonalInformation } from 'src/app/models/PersonalInformation';
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
    this.personalInfomationService.client=client
this.router.navigate(['app-personal-ditails']);
  }
  update(client:PersonalInformation)
  {
    this.personalInfomationService.updateClient(client).subscribe(a=>{console.log(a)})
  }

}
