type Props = {
  label: string;
  type: "button" | "submit" | "reset";
  variety: "primary" | "secondary" | "danger";
};

export const Button = ({ label, type, variety = "primary" }: Props) => {
  return (
    <button
      type={type}
      className={`w-full text-bold text-white font-bold flex justify-center items-center p-4 hover:cursor-pointer ${
        variety === "primary"
          ? "bg-green-900"
          : variety === "secondary"
          ? "bg-gray-600"
          : "bg-red-800"
      }`}
    >
      {label}
    </button>
  );
};
