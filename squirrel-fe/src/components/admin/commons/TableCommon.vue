<template>
    <table v-if="config && config?.length" class="table bg-white rounded shadow-sm table-hover">
        <thead>
            <tr class="primary-bg  text-white">
                <th v-for="h in config" :key="h.name" class="text-center" scope="col">{{ h.name }}</th>
            </tr>
        </thead>
        <tbody v-if="items?.length">
            <tr v-for="(row, index1) in items" :key="index1" :class="index1 % 2 == 1 ? 'event' : ''">
                <td  v-for="(h, index) in config" :key="index" :class="[
                    h.textAlign ? 'text-' + h.textAlign : 'text-left']">
                    <span v-if="h.columnStyle == ColumnStyle.text || !h.columnStyle ">
                        {{ row[h.id] }}
                    </span>
                    <span v-if="h.columnStyle == ColumnStyle.number">
                        {{ new Intl.NumberFormat('vi-VN').format(row[h.id] ) }}
                    </span>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script setup lang="ts">
import { ColumnStyle } from '@/enums/admin.enums';
import {defineProps} from 'vue'
import type { HeaderTable } from './interface';

interface Props {
    config?: Array<HeaderTable>,
    items?: Array<any>,
}

withDefaults(defineProps<Props>(), {
    config: Array,
    items: Array,
})
</script>