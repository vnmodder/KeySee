<template>
    <table v-if="config && config?.headers?.length" class="table bg-white rounded shadow-sm table-hover">
        <thead>
            <tr class="primary-bg  text-white ">
                <th width="50" class="text-center align-middle" v-if="config.options?.showRowHeader">#</th>
                <template v-for="h in config?.headers" :key="h.name">
                    <th class="text-center align-middle" v-if="!h.hidden">
                        <div class="row " v-if="h.columnStyle == ColumnStyle.checkbox && h.attribute?.showCheckAll">
                            <input type="checkbox" @change="(e) => checkAllChanged(e, h)" />
                        </div>
                        {{ h.name }}
                    </th>
                </template>
                <th class="text-center align-middle"
                    v-if="config.options?.showDel || config.options?.showEdit || config.options?.showDetail">Tùy chỉnh
                </th>
            </tr>
        </thead>
        <tbody v-if="items?.length">
            <tr v-for="(row, index1) in items" :key="index1" :class="index1 % 2 == 1 ? 'event' : ''"
                @click="rowSlected(row, index1)">
                <td class="text-center align-middle" v-if="config.options?.showRowHeader">{{ index1 + (startIndex ?? 0)
                    +
                    1 }}
                </td>
                <template v-for="(h, index) in config?.headers" :key="index">
                    <td v-if="!h.hidden" class="align-middle" :class="[
                        h.textAlign ? 'text-' + h.textAlign : 'text-left', h.className]" :width="h.width">
                        <span v-if="h.columnStyle == ColumnStyle.text || !h.columnStyle">
                            {{ row[h.id] }}
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.number">
                            {{ new Intl.NumberFormat(h.attribute?.locale?.toString() ?? 'vi-VN', {
                                minimumFractionDigits: h.attribute?.decimalPlaces ?? 0,
                                maximumFractionDigits: h.attribute?.decimalPlaces ?? 0
                            }).format(row[h.id]) }}
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.checkbox">
                            <input type="checkbox" v-model="row[h.id]" />
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.dropdown && h.attribute?.data">
                            <select v-model="row[h.id]" class="form-select">
                                <option v-for="item in h.attribute?.data" :key="item[h.attribute?.valueMember ?? 'key']"
                                    :value="item[h.attribute?.valueMember ?? 'key']">{{ item[
                                        h.attribute?.displayMember ?? 'value']
                                    }}</option>
                            </select>
                        </span>
                    </td>
                </template>
                <td v-if="config.options?.showDel || config.options?.showEdit || config.options?.showDetail"
                    :style="'text-align: center; cursor: pointer'" class="align-middle">
                    <i v-if="config.options?.showDetail" class="fas fa-eye primary-text" @click="detailClick(row)"></i>
                    <i v-if="config.options?.showEdit" class="fas fa-pen ms-2" @click="editClick(row)"></i>
                    <i v-if="config.options?.showDel" class="fas fa-trash ms-2 text-danger" @click="delClick(row)"></i>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script setup lang="ts">
import { ColumnStyle } from '@/enums/admin.enums';
import { defineProps, ref } from 'vue'
import type { TableConfig, HeaderTable } from './interface';

interface Props {
    config?: TableConfig,
    items?: Array<any>,
    startIndex?: number
}
const props = defineProps<Props>()

const rowSlected = (row: any, index: number) => {
    if (props.config?.options?.rowSlected)
        props.config.options?.rowSlected(row, index + (props.startIndex ?? 0))
}

const detailClick = (row: any) => {
    if (props.config?.options?.detailClick)
        props.config.options?.detailClick(row)
}

const delClick = (row: any) => {
    if (props.config?.options?.delClick)
        props.config.options?.delClick(row)
}

const editClick = (row: any) => {
    if (props.config?.options?.editClick)
        props.config.options?.editClick(row)
}

const checkAllChanged = (event: Event, header: HeaderTable) => {
    if (event.target instanceof HTMLInputElement
        && header.attribute?.checkAllChanged) {
        header.attribute?.checkAllChanged(event.target.checked)
    }
}
</script>