<template>
    <template v-for="(node, index) in nodes">
        <tr>
            <td class="align-middle">
                <span :style="'margin-left:' + depth + 'rem'">
                    <span v-if="node.children" @click="toggleNode">
                        <i v-if="isExpanded" class="fas fa-caret-down"></i>
                        <i v-else class="fas fa-caret-right"></i>
                    </span>
                    <span :style="!node.children || node.children.length < 1 ? 'margin-left:0.60rem' : ''">
                        {{ node.data['name'] }}
                    </span>
                </span>
            </td>
            <template v-for="col in config?.headers.filter(x => x.id != 'name')" :key="col.id">
                <td class="align-middle">
                    <a v-if="col.columnStyle == ColumnStyle.link" :href="node.data[col.id]"> {{ node.data[col.id] }}</a>
                    <span v-else>
                        {{ node.data[col.id] }}
                    </span>
                </td>
            </template>
            <td v-if="config?.options?.showDel || config?.options?.showEdit || config?.options?.showDetail"
                :style="'text-align: center; cursor: pointer'" class="align-middle">
                <i v-if="config.options?.showDetail" class="fas fa-eye primary-text" @click="detailClick(node)"></i>
                <i v-if="config.options?.showEdit" class="fas fa-pen ms-2" @click="editClick(node)"></i>
                <i v-if="config.options?.showDel" class="fas fa-trash ms-2 text-danger" @click="delClick(node)"></i>
            </td>
        </tr>
        <TreeTableItem v-if="isExpanded" :nodes="node.children" :config="config" :depth="depth + 1" />
    </template>
</template>


<script setup lang="ts">
import { ref } from 'vue'
import type { TableConfig } from './interface'
import { ColumnStyle } from '@/enums/admin.enums'

interface Node {
    data: any
    children?: Node[]
}
interface Props {
    config?: TableConfig
    nodes?: Node[]
    depth: number
}

const props = defineProps<Props>();

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


const isExpanded = ref(true)

const toggleNode = () => {
    isExpanded.value = !isExpanded.value
}
</script>


<style scoped>
.fas {
    cursor: pointer;
}
</style>