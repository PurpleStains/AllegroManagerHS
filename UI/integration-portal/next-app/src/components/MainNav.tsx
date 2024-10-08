import { Cable, Headset, Settings } from "lucide-react";
import Header from "./Header";
import { MenuItems } from "./MenuLinks/MenuItems";
import { MenuItem } from "./PortalMenu/PortalMenu";
import { useRouter } from "next/navigation";

const MainNav = () => {
  const router = useRouter();
  const title = "Integration Portal"

  const items: MenuItem[] = [
    {
      label: "Options",
      icon: <Settings />,
      onClick: () => { router.push('/options/main') }
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