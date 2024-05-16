<template>
  <SessionItem :label="'Bảng điều khiển'">
      <Table :config="config" :items="dumydata"  />
  </SessionItem>
</template>

<script setup lang="ts">
import { SessionItem, Table } from '@/components/admin/commons'
import { ColumnStyle } from '@/enums/admin.enums';
import { dumydata } from "./dumydata.admin";


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
</script>
