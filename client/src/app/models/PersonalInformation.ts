import { KeyObject } from "crypto";
import { Corona_vaccine } from "./Corona_vaccine";
import { IllnessDate } from "./IllnessDate";
import { Vaccine_company } from "./Vaccine_company";

export class PersonalInformation{
   
    first_name:string | undefined;
    last_name!: string;
    id!: number;
    address!: string;
    //city!: string;
    birthday: Date=new Date();
    phone!: number;
    mobile!: number;
    vaccines: Corona_vaccine[]=[];
    illnessDates: IllnessDate[]=[];
    
}