import { IUser } from "../interfaces/IUser"

export interface IUserSlice  {
    isAuth: boolean,
    isLoading: boolean
    user:IUser | null
}