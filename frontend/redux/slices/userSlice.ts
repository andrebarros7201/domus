import { INotification } from "@/types/interfaces/INotification";
import { IUser } from "@/types/interfaces/IUser";
import { IUserSlice } from "@/types/slices/IUserSlice";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios, { Axios, AxiosError } from "axios";

const initialState: IUserSlice = {
  isAuth: false,
  isLoading: false,
  user: null,
};

// ASYNC THUNKS

export const register = createAsyncThunk<
  { notification: INotification },
  { firstName: string; lastName: string; username: string; password: string },
  { rejectValue: { notification: INotification } }
>(
  "user/register",
  async ({ firstName, lastName, username, password }, { rejectWithValue }) => {
    try {
      const response = await axios.post(
        `${process.env.BACKEND_URL}/auth/register`,
        { firstName, lastName, username, password }
      );
      const { message } = response.data;
      return { notification: { type: "success", message } };
    } catch (e) {
      const error = e as AxiosError<{ message: string }>;
      return rejectWithValue({
        notification: { type: "error", message: error.message },
      });
    }
  }
);

export const login = createAsyncThunk<
  { notification: INotification; user: IUser },
  { username: string; password: string },
  { rejectValue: { notification: INotification } }
>("user/login", async ({ username, password }, { rejectWithValue }) => {
  try {
    const response = await axios.post(`${process.env.BACKEND_URL}/auth/login`, {
      username,
      password,
    });
    const { data } = response.data;
    return {
      notification: { type: "success", message: "Successfully logged in" },
      user: data,
    };
  } catch (e) {
    const error = e as AxiosError<{ message: string }>;
    return rejectWithValue({
      notification: { type: "error", message: error.message },
    });
  }
});

export const logout = createAsyncThunk<
  { notification: INotification },
  void,
  { rejectValue: { notification: INotification } }
>("user/logout", async (_, { rejectWithValue }) => {
  try {
    const response = await axios.get(`${process.env.BACKEND_URL}/auth/logout`, {
      withCredentials: true,
    });
    const { message } = response.data;
    return {
      notification: { type: "success", message },
    };
  } catch (e) {
    const error = e as AxiosError<{ message: string }>;
    return rejectWithValue({
      notification: { type: "error", message: error.message },
    });
  }
});

const userSlice = createSlice({
  name: "userSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) =>
    builder
      // REGISTER
      .addCase(register.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(register.fulfilled, (state) => {
        state.isLoading = false;
      })
      .addCase(register.rejected, (state) => {
        state.isLoading = false;
      })
      // LOGIN
      .addCase(login.pending, (state) => {
        state.isLoading = true;
        state.isAuth = false;
        state.user = null;
      })
      .addCase(login.fulfilled, (state, action) => {
        state.isLoading = false;
        state.isAuth = true;
        state.user = action.payload.user;
      })
      .addCase(login.rejected, (state) => {
        state.isLoading = false;
        state.user = null;
        state.isAuth = false;
      })
      // LOGOUT
      .addCase(logout.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(login.fulfilled, (state) => {
        state.isLoading = false;
        state.isAuth = false;
        state.user = null;
      })
      .addCase(login.rejected, (state) => {
        state.isLoading = false;
      }),
});

export const userReducer = userSlice.reducer;
export const {} = userSlice.actions; // Export reducer methods
