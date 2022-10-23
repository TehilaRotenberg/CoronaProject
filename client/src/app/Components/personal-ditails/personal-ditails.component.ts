import { Component, OnInit } from '@angular/core';
import { PersonalInformationService } from 'src/app/Services/personal-information.service';

@Component({
  selector: 'app-personal-ditails',
  templateUrl: './personal-ditails.component.html',
  styleUrls: ['./personal-ditails.component.css']
})
export class PersonalDitailsComponent implements OnInit {

  constructor(public personalinformationService:PersonalInformationService) { 
    console.log(personalinformationService.client.vaccines)
  }

  ngOnInit(): void {
  }

}
