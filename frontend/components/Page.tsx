import { ReactNode } from "react";

type Props = {
  children: ReactNode | ReactNode[];
};

export const Page = ({ children }: Props) => {
  return (
    <div
      className={
        "w-full h-full flex flex-col items-center justify-start p-4 gap-4"
      }
    >
      {children}
    </div>
  );
};
