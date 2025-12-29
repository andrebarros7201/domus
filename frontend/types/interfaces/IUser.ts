import { IProperty } from "./IProperty";

export interface IUser {
  id: string;
  username: string;
  firstName: string,
  lastName: string
  properties: IProperty[]
}
