<template>
  <SessionItem :title="'Test tree table'">
    <TreeTable :nodes="treeData3" :config="config" />
  </SessionItem>
  <SessionItem :title="'Test tree view'">
    <TreeView :node="treeData" :depth="0" />
  </SessionItem>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import {
  TreeView,
  SessionItem,
  TreeTable,
} from "@/components/admin/commons";
import { ColumnStyle } from "@/enums/admin.enums";

const config = {
  headers: [
    {
      id: "name",
      name: "Tên",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "path",
      name: "Đường link",
      columnStyle: ColumnStyle.link,
    },
    {
      id: "so1",
      name: "Số 1",
      columnStyle: ColumnStyle.text,
      textAlign: 'center'
    },
    {
      id: "so2",
      name: "Số 2",
      columnStyle: ColumnStyle.number,
      textAlign: 'end'
    },
    {
      id: "description",
      name: "Mô tả",
      columnStyle: ColumnStyle.text,
    },
  ],
  options: {
    showDetail: true,
    showCheck: true,
    checkMember: "checkNe",
  },
};

const treeData = reactive({
  name: "Trang chủ",
  path: "sadsadas/sadsa/sadas",
  description: "có 4 khoa",
  children: [
    {
      name: "Khoa 1",
      path: "sadsadas/sadsa/sadas",
      description: "khoa này có 0 lớp",
    },
    {
      name: "Khoa 2",
      children: [
        {
          name: "Môn học thứ 1",
          path: "sadsadas/sadsa/sadas",
          description: "lớp này có 7 người",
        },
        {
          name: "Môn học thứ 2",
          path: "sadsadas/sadsa/sadas",
          description: "lớp này có 9 người",
        },
      ],
      path: "sadsadas/sadsa/sadas",
      description: "khoa này có 9 lớp",
    },
    {
      name: "Khoa 3",
      children: [
        {
          name: "Môn học thứ 3",
        },
        {
          name: "Môn học thứ 4",
        },
      ],
    },
    {
      name: "Khoa 4",
    },
  ],
});

const treeData3 = reactive([
  {
    id: 1,
    name: "Khoa 1",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 0,
    so1: 1,
    so2:2111
  },
  {
    id: 2,
    name: "Khoa 2",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 0,
    so1: 1,
    so2:2234
  },
  {
    id: 3,
    name: "Môn 1",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 2,
    so1: 1,
    so2:221321
  },
  {
    id: 4,
    name: "Môn 2",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 2,
    so1: 1,
    so2:26546
  },
  {
    id: 5,
    name: "Lớp 1",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 3,
    so1: 1,
    so2:2878
  },
  {
    id: 6,
    name: "Lớp 1",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 4,
    so1: 1,
    so2:22679
  },
  {
    id: 7,
    name: "Sinh viên 1",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 5,
    so1: 1,
    so2:2754
  },
]);
</script>
