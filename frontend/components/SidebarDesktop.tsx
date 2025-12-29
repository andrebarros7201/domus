import { SidebarLink } from "./ui/SidebarLink";

export const SidebarDesktop = () => {
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
      <SidebarLink label={"Register"} href={"/register"} />
      <SidebarLink label={"Login"} href={"/login"} />
    </aside>
  );
};
