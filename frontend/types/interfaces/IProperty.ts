import { PropertyStatusEnum } from "../enums/PropertyStatusEnum";

export interface IProperty{
    id: string,
    name:string,
    location:string,
    price: number,
    numberRooms:number,
    status: PropertyStatusEnum
}