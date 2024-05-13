<template>
    <table v-if="headers?.length" class="table bg-white rounded shadow-sm table-hover">
        <thead>
            <tr class="primary-bg  text-white">
                <th scope="col" width="50" class="text-center">#</th>
                <th v-for="h in headers" :key="h.name" class="text-center" scope="col">{{ h.name }}</th>
            </tr>
        </thead>
        <tbody v-if="items?.length">
            <tr v-for="(row, index1) in items" :key="index1" :class="index1 % 2 == 1 ? 'event' : ''">
                <td v-if="row.length" class="text-center" scope="row">{{ index1 + 1 }}</td>
                <td v-if="row.length" v-for="(col, index) in row" :key="index" :class="[
                    headers[index].textAlign ? 'text-' + headers[index].textAlign : 'text-left']">
                    <span v-if="(!headers[index].columnStyle || headers[index].columnStyle == ColumnStyle.text)">
                        {{ col }}
                    </span>
                    <span v-if="headers[index].columnStyle == ColumnStyle.number">
                        {{ new Intl.NumberFormat('vi-VN').format(col) }}
                    </span>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script setup lang="ts">
import { ColumnStyle } from '@/assets/enums/admin.enums';


interface Props {
    headers?: Array<Header>,
    items?: Array<Array<any>>
}

interface Header {
    name: string,
    textAlign?: string,
    fomatValue?: string
    columnStyle?: ColumnStyle
}

withDefaults(defineProps<Props>(), {
    headers: Array,
    items: Array
})
</script>