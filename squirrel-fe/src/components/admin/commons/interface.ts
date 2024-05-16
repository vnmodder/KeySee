import type { ControlStyle } from "@/enums/admin.enums"

export interface BaseAttribute {
    id?: string
    name?:string
    labelValue?: string
    colControl?: number
    className?: string
}

export interface GroupItemConfig {
    id?: string | number,
    groupStyle?: string,
    groupItem?: Array<ItemConfig>
    groupValue?:any
}

export interface ItemConfig extends BaseAttribute {
    controlStyle: ControlStyle
    attribute?: object
    modelValue?: any
    labelClassName?:string
    colLabel?:number
}