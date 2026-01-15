"use client";

import { Page } from "@/components/Page";
import { Button } from "@/components/ui/Button";
import { Form } from "@/components/ui/Form";
import { Input } from "@/components/ui/Input";
import { setNotification } from "@/redux/slices/notificationSlice";
import { login } from "@/redux/slices/userSlice";
import { RootDispatch } from "@/redux/store";
import { INotification } from "@/types/interfaces/INotification";
import { FormEvent, useState } from "react";
import { useDispatch } from "react-redux";
import * as z from "zod";

export default function LoginPage() {
  // Form data initial state
  const initialState = {
    username: "",
    password: "",
  };

  const dispatch = useDispatch<RootDispatch>();
  const [data, setData] = useState(initialState);

  const formDataSchema = z.object({
    username: z
      .string()
      .min(3, "Username must have at least 3 characters")
      .nonempty(),
    password: z
      .string()
      .min(3, "Password must have at least 3 characters")
      .nonempty(),
  });

  function handleChange(field: string, value: string | number) {
    setData((prev) => ({ ...prev, [field]: value }));
  }

  async function handleSubmit(e: FormEvent) {
    e.preventDefault();

    const result = await formDataSchema.safeParseAsync({
      username: data.username,
      password: data.password,
    });

    if (!result.success) {
      const errorMessage = result.error.issues[0].message;
      dispatch(setNotification({ type: "error", message: errorMessage }));
      return;
    }

    try {
      const response = await dispatch(
        login({
          username: result.data.username,
          password: result.data.password,
        })
      ).unwrap();
      const { notification } = response;
      dispatch(setNotification(notification));
    } catch (e) {
      const error = e as { notification: INotification };
      dispatch(setNotification(error.notification));
    }
  }
  return (
    <Page>
      <div className={"w-full h-full flex items-center justify-center"}>
        <Form onSubmit={(e) => handleSubmit(e)}>
          <Input
            id="username"
            name="username"
            label="Username"
            onChange={handleChange}
          />
          <Input
            id="password"
            name="password"
            label="Password"
            type="password"
            onChange={handleChange}
          />
          <Button label={"Login"} type={"submit"} variety={"primary"} />
        </Form>
      </div>
    </Page>
  );
}
