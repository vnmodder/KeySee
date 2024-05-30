<template>
    <table v-if="config && config?.headers?.length" class="table bg-white rounded shadow-sm table-hover">
        <thead>
            <tr class="primary-bg  text-white">
                <th scope="col" width="50" class="text-center" v-if="config.options?.showRowHeader">#</th>
                <template v-for="h in config?.headers" :key="h.name">
                    <th class="text-center" v-if="!h.hidden" scope="col">{{ h.name }}</th>
                </template>
                <th class="text-center"
                    v-if="config.options?.showDel || config.options?.showEdit || config.options?.showDetail"
                    scope="col">Tùy chỉnh</th>
            </tr>
        </thead>
        <tbody v-if="items?.length">
            <tr v-for="(row, index1) in items" :key="index1" :class="index1 % 2 == 1 ? 'event' : ''"
                @click="config.options?.rowSlected(row, index1 + startIndex)">
                <td class="text-center" scope="row" v-if="config.options?.showRowHeader">{{ index1 + startIndex + 1 }}
                </td>
                <template v-for="(h, index) in config?.headers" :key="index">
                    <td v-if="!h.hidden" :class="[
                        h.textAlign ? 'text-' + h.textAlign : 'text-left', h.className]" :width=" h.width" >
                        <span v-if="h.columnStyle == ColumnStyle.text || !h.columnStyle">
                            {{ row[h.id] }}
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.number">
                            {{ new Intl.NumberFormat('vi-VN').format(row[h.id]) }}
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.checkbox">
                            <input type="checkbox" v-model="row[h.id]" />
                        </span>
                        <span v-if="h.columnStyle == ColumnStyle.dropdown">
                            <select v-model="row[h.id]" class="form-select" >
                                <option v-for="item in h.data" :key="item['key']" :value="item['key']">{{ item['value']
                                    }}</option>
                            </select>
                        </span>
                    </td>
                </template>
                <td v-if="config.options?.showDel || config.options?.showEdit || config.options?.showDetail"
                    :style="'text-align: center; cursor: pointer'">
                    <i v-if="config.options?.showDetail" class="fas fa-eye primary-text"
                        @click="config.options?.detailClick(row)"></i>
                    <i v-if="config.options?.showEdit" class="fas fa-pen ms-2"
                        @click="config.options?.editClick(row)"></i>
                    <i v-if="config.options?.showDel" class="fas fa-trash ms-2 text-danger"
                        @click="config.options?.delClick(row)"></i>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script setup lang="ts">
import { ColumnStyle } from '@/enums/admin.enums';
import { defineProps, ref } from 'vue'
import type { TableConfig } from './interface';

interface Props {
    config?: TableConfig,
    items?: Array<any>,
    startIndex?: number
}



withDefaults(defineProps<Props>(), {
    items: undefined,
    startIndex: 0,
})

</script>