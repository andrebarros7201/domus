import { IUserSlice } from "@/types/slices/IUserSlice";
import { createSlice } from "@reduxjs/toolkit";

const initialState: IUserSlice = {
  isAuth: false,
  isLoading: false,
  user: null,
};

export const userSlice = createSlice({
  name: "userSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => builder,
});

export const userReducer = userSlice.reducer;
export const {} = userSlice.actions; // Export reducer methods
