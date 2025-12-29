import { ChangeEvent } from "react";

type Props = {
  label: string;
  id: string;
  name: string;
  type?: "number" | "text" | "password";
  required?: boolean;
  onChange: (field: string, value: string | number) => void;
};

export const Input = ({
  label,
  id,
  name,
  type = "text",
  required = true,
  onChange,
}: Props) => {
  return (
    <span className={"w-full flex flex-col gap-2"}>
      <label htmlFor={id} className={"text-xl"}>
        {label}
      </label>
      <input
        className={
          "w-full px-2 py-4 border-b-2 border-green-800 outline-0 text-xl bg-neutral-200"
        }
        type={type}
        required={required}
        name={name}
        id={id}
        onChange={(e: ChangeEvent<HTMLInputElement>) =>
          onChange(id, e.target.value)
        }
      />
    </span>
  );
};
