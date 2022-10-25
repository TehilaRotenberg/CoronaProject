import { KeyObject } from "crypto";
import { Corona_vaccine } from "./Corona_vaccine";
import { IllnessDate } from "./IllnessDate";
import { Vaccine_company } from "./Vaccine_company";

export class Personal{
   
    first_name:string | undefined;
    last_name!: string;
    id!: number;
    address!: string;
    //city!: string;
    birthday!: Date;
    phone!: number;
    mobile!: number;
}