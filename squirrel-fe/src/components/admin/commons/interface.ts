import type {
  ColumnStyle,
  ControlStyle,
  GroupStyle,
} from "@/enums/admin.enums";

export interface BaseAttribute {
  id?: string;
  name?: string;
  labelValue?: string;
  colControl?: number;
  className?: string;
}

export interface GroupItemConfig {
  id?: string | number;
  groupStyle?: GroupStyle;
  groupItem?: Array<ItemConfig>;
  groupValue?: any;
}

export interface ItemConfig extends BaseAttribute {
  controlStyle: ControlStyle;
  attribute?: object;
  modelValue?: any;
  labelClassName?: string;
  colLabel?: number;
}

export interface HeaderTable {
  id: string;
  name: string;
  textAlign?: string;
  fomatValue?: string;
  columnStyle?: ColumnStyle;
  hidden?: boolean;
  className?: string;
  width?: number;
  attribute?: HeaderColumn;
}

interface HeaderColumn {
  data?: Array<any>;
  displayMember?: string;
  valueMember?: string;
  showCheckAll?: boolean;
  checkAllChanged?: (isChecked: boolean) => void;
}

interface HeaderTableOption {
  showDel?: boolean;
  showEdit?: boolean;
  showDetail?: boolean;
  showRowHeader?: boolean;
  showCheck?: boolean;
  checkMember?: string;
  delClick?: (row: any) => void;
  editClick?: (row: any) => void;
  detailClick?: (row: any) => void;
  rowSlected?: (row: any, index: number) => void;
}

export interface TableConfig {
  headers: Array<HeaderTable>;
  options?: HeaderTableOption;
}

export interface MenuItem {
  id: number;
  name?: string;
  href?: string;
  icon?: string;
  isAtive: boolean;
}
