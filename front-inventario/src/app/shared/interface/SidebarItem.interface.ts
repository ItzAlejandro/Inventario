export interface SidebarItem {
  label: string;
  icon: string;
  url?: string;
  expanded?: boolean;
  subitems?: SidebarItem[];
}
