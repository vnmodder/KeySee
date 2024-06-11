<template>
  <SessionItem :title="'Test tree table'">
    <TreeTable :nodes="treeData2" :config="config" />
  </SessionItem>
  <SessionItem :title="'Test tree view'">
    <TreeView :node="treeData" :depth="0" />
  </SessionItem>
  <SessionItem :title="'Test tree table 1d'">
    <TreeTable1D :nodes="treeData3" :config="config" />
  </SessionItem>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import {
  TreeView,
  SessionItem,
  TreeTable,
  TreeTable1D,
} from "@/components/admin/commons";
import { ColumnStyle } from "@/enums/admin.enums";

const treeData2 = reactive([
  {
    data: {
      name: "Trang chủ",
      path: "sadsadas/sadsa/sadas",
      description: "có 4 khoa",
    },
    children: [
      {
        data: {
          name: "Khoa 1",
          path: "sadsadas/sadsa/sadas",
          description: "khoa này có 0 lớp",
        },
      },
      {
        data: {
          name: "Khoa 2",
          path: "sadsadas/sadsa/sadas",
          description: "khoa này có 9 lớp",
        },
        children: [
          {
            data: {
              name: "Môn học thứ 1",
              path: "sadsadas/sadsa/sadas",
              description: "lớp này có 7 người",
            },
          },
          {
            data: {
              name: "Môn học thứ 2",
              path: "sadsadas/sadsa/sadas",
              description: "lớp này có 9 người",
            },
          },
        ],
      },
      {
        data: {
          name: "Khoa 3",
        },
        children: [
          {
            data: {
              name: "Môn học thứ 3",
            },
          },
          {
            data: {
              name: "Môn học thứ 4",
            },
          },
        ],
      },
      {
        data: {
          name: "Khoa 4",
        },
      },
    ],
  },
]);

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
    name: "ssadsa",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 0,
  },
  {
    id: 2,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 0,
  },
  {
    id: 3,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 2,
  },
  {
    id: 4,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 2,
  },
  {
    id: 5,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 3,
  },
  {
    id: 6,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 4,
  },
  {
    id: 7,
    name: "dsadas",
    path: "sadsadas/sadsa/sadas",
    description: "có 4 khoa",
    parent: 5,
  },
]);
</script>
