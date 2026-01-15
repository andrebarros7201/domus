import { useDispatch } from "react-redux";
import { Button } from "./ui/Button";
import { RootDispatch } from "@/redux/store";
import { logout } from "@/redux/slices/userSlice";
import { setNotification } from "@/redux/slices/notificationSlice";
import { INotification } from "@/types/interfaces/INotification";

export const LogoutButton = () => {
  const dispatch = useDispatch<RootDispatch>();

  async function handleLogout() {
    try {
      const response = await dispatch(logout()).unwrap();
      const { notification } = response;
      dispatch(setNotification(notification));
    } catch (e) {
      const error = e as { notification: INotification };
      dispatch(setNotification(error.notification));
    }
  }
  return (
    <Button
      label={"Logout"}
      type={"button"}
      variety={"danger"}
      onClick={handleLogout}
    />
  );
};
