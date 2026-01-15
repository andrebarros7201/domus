"use client";

import { useSelector } from "react-redux";
import { SidebarLink } from "./ui/SidebarLink";
import { RootState } from "@/redux/store";
import { LogoutButton } from "./ButtonLogout";

export const SidebarDesktop = () => {
  const { isAuth } = useSelector((state: RootState) => state.user);
  return (
    <aside
      className={
        "invisible flex flex-col items-center p-4 gap-4 sm:visible h-screen max-w-80 w-full bg-green-900 text-white"
      }
    >
      <h2
        className={
          "font-bold text-2xl w-full flex items-center justify-center p-4 bg-green-950 rounded"
        }
      >
        Domus
      </h2>
      <div className={"w-full flex flex-col gap-4 items-center mt-auto"}>
        {!isAuth ? (
          <>
            <SidebarLink label={"Register"} href={"/register"} />
            <SidebarLink label={"Login"} href={"/login"} />
          </>
        ) : (
          <LogoutButton />
        )}
      </div>
    </aside>
  );
};
