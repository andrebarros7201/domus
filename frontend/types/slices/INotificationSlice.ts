import { INotification } from "../interfaces/INotification";

export interface INotificationSlice {
  notification: INotification | null;
  isVisible: boolean;
}
