type Props = {
  label: string;
  type: "button" | "submit" | "reset";
  variety: "primary" | "secondary" | "danger";
  isDisabled?: boolean;
};

export const Button = ({
  label,
  type,
  variety = "primary",
  isDisabled = false,
}: Props) => {
  const varietyStyle = {
    primary: "bg-green-800 hover:bg-green-900",
    secondary: "bg-gray-600 hover:bg-gray-700",
    danger: "bg-red-800 hover:bg-red-900",
  };

  return (
    <button
      type={type}
      disabled={isDisabled}
      className={`w-full text-bold text-white font-bold flex justify-center items-center p-4 hover:cursor-pointer ${varietyStyle[variety]}
      disabled:cursor-not-allowed disabled:bg-gray-400`}
    >
      {label}
    </button>
  );
};
