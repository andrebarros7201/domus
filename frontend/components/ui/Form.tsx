import { Activity, FormEvent, ReactNode } from "react";

type Props = {
  children: ReactNode | ReactNode[];
  title?: string;
  onSubmit: (e: FormEvent) => void;
};

export const Form = ({ children, title, onSubmit }: Props) => {
  return (
    <form
      className={
        "max-w-120 w-full rounded p-4 gap-8 flex flex-col items-center justify-start box-border"
      }
      onSubmit={onSubmit}
    >
      <Activity mode={title ? "visible" : "hidden"}>
        <h3>{title}</h3>
      </Activity>
      {children}
    </form>
  );
};
