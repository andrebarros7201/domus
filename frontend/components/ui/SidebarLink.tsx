import Link from "next/link";

type Props = {
  label: string;
  href: string;
};

export const SidebarLink = ({ label, href }: Props) => {
  return (
    <Link className={"font-bold hover:cursor text-xl"} href={href}>
      <h4>{label}</h4>
    </Link>
  );
};
