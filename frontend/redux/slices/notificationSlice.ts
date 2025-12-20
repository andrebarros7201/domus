import { INotification } from "@/types/interfaces/INotification";
import { INotificationSlice } from "@/types/slices/INotificationSlice";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";

const initialState: INotificationSlice = {
  isVisible: false,
  notification: null,
};

const notificationSlice = createSlice({
  name: "notificationSlice",
  initialState,
  reducers: {
    setNotification: (state, action: PayloadAction<INotification>) => {
      state.isVisible = true;
      state.notification = action.payload;
    },
    clearNotification: (state) => {
      state.isVisible = false;
      state.notification = null;
    },
  },
});

export const notificationReducer = notificationSlice.reducer;
export const { setNotification, clearNotification } = notificationSlice.actions;
