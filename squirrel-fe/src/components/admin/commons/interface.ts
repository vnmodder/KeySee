import type { ColumnStyle, ControlStyle, GroupStyle } from "@/enums/admin.enums"

export interface BaseAttribute {
    id?: string
    name?:string
    labelValue?: string
    colControl?: number
    className?: string
}

export interface GroupItemConfig {
    id?: string | number,
    groupStyle?: GroupStyle,
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

export interface HeaderTable {
    id:string
    name: string,
    textAlign?: string,
    fomatValue?: string
    columnStyle?: ColumnStyle
    hidden?: boolean
    className?: string
    width?:number
    data?:Array<any>
}
interface HeaderTableOption{
    showDel: boolean
    showEdit: boolean
    showDetail: boolean
    showRowHeader:boolean
    delClick: (row: any)=> void
    editClick: (row: any)=> void
    detailClick: (row: any)=> void
    rowSlected: (row: any, index: number) => void,
}


export interface TableConfig{
    headers: Array<HeaderTable>
    options:HeaderTableOption

}