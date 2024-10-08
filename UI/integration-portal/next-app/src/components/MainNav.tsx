import { Headset, LifeBuoy, LockKeyholeOpen, Settings } from "lucide-react";
import Header from "./Header";
import { MenuItems } from "./MenuLinks/MenuItems";
import { MenuItem } from "./PortalMenu/PortalMenu";

const MainNav = () => {
  const title = "Integration Portal"

  const items: MenuItem[] = [
    {
      label: "Settings",
      icon: <Settings />,
      onClick: () => { }
    },
    {
      label: "Contact",
      icon: <Headset />,
      onClick: () => { },
    },
  ]

  return (
    <Header
      title={title}
      links={MenuItems()}
      menuItems={items} />
  )
}

export default MainNav