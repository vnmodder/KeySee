<template>
    <table v-if="config && config?.headers?.length" class="table bg-white rounded shadow-sm table-hover">
        <thead>
            <tr class="primary-bg  text-white ">
                <th class="text-center align-middle">{{ config?.headers.find(x => x.id == 'name')?.name }}</th>
                <template v-for="h in config?.headers.filter(x => x.id != 'name')" :key="h.name">
                    <th class="text-center align-middle">{{ h.name }}</th>
                </template>
                <th class="text-center align-middle"
                    v-if="config?.options?.showDel || config?.options?.showEdit || config?.options?.showDetail">
                    Tùy chỉnh
                </th>
            </tr>
        </thead>
        <tbody>
            <TreeTableItem :nodes="nodes" :depth="0" :config="config" />
        </tbody>
    </table>
</template>

<script setup lang="ts">

import { TreeTableItem } from './'
import type { TableConfig } from './interface';

interface Node {
    data: any
    children?: Node[];
}

interface Props {
    config?: TableConfig,
    nodes?: Node[];

}
defineProps<Props>()

</script>
