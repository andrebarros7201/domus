"use client";

import { clearNotification } from "@/redux/slices/notificationSlice";
import { RootDispatch, RootState } from "@/redux/store";
import { useDispatch, useSelector } from "react-redux";

export const Notification = () => {
  const { notification, isVisible } = useSelector(
    (state: RootState) => state.notification
  );
  const dispatch = useDispatch<RootDispatch>();

  function handleClose() {
    dispatch(clearNotification());
  }

  if (isVisible && notification) {
    return (
      <div
        className={`absolute top-4 right-4 w-80 p-4 flex flex-col gap-4 items-start justify-center shadow-2xl rounded ${
          notification.type === "error" ? "bg-red-800" : "bg-green-800"
        } `}
      >
        <div className={"w-full flex justify-between"}>
          <h4 className={"text-2xl font-bold text-white"}>
            {notification.type === "error" ? "Error" : "Success"}
          </h4>
          <button
            className={"text-white hover:cursor-pointer"}
            onClick={handleClose}
          >
            X
          </button>
        </div>
        <p className={"text-lg text-white"}>{notification.message}</p>
      </div>
    );
  }
};
