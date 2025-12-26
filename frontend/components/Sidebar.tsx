import { SidebarLink } from "./ui/SidebarLink";

export const SidebarDesktop = () => {
  return (
    <aside
      className={
        "invisible flex flex-col gap-4 items-center p-4 sm:visible h-screen max-w-80 bg-green-900 text-white"
      }
    >
      <h2
        className={
          "font-bold text-2xl w-full flex items-center justify-center p-4 bg-green-950 rounded"
        }
      >
        Domus
      </h2>
      <SidebarLink label={"Register"} href={"/register"} />
      <SidebarLink label={"Login"} href={"/login"} />
    </aside>
  );
};
