import { IllnessDate } from "./IllnessDate";
import { Vaccine_company } from "./Vaccine_company";

export class PersonalInformation{
    _id!: string;
    first_name:string | undefined;
    last_name!: string;
    id!: number;
    address!: string;
    city!: string;
    birthday!: Date;
    phone!: number;
    mobile!: number;
    vaccines!: Vaccine_company[];
    illnessDates!: IllnessDate[];
    
}