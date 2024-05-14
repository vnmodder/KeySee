<template>
    <SessionItem :label="'Table'">
        <Table :headers="config" :items="items"  />
    </SessionItem>
</template>

<script setup lang="ts">
import { SessionItem, Table } from '@/components/admin/commons'
import { ColumnStyle } from '@/enums/admin.enums';


const config = [
    {
        id: 'cot1',
        name: 'Cột 1',
        textAlign: 'start',
        columnStyle: ColumnStyle.text
    },
    {
        id: 'cot2',
        name: 'Cột 2',
        textAlign: 'center',
        columnStyle: ColumnStyle.text
    },
    {
        id: 'cot3',
        name: 'Cột 3',
        textAlign: 'end',
        columnStyle: ColumnStyle.number
    }, 
]

const items = [
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
]
</script>