<template>
    <SessionItem>
        <GroupItem :config="layoutConfig" />
    </SessionItem>
    <SessionItem :title="'Các danh mục'">
    <PaginationPage :config="tableConfig" :dataItems="items">
      <template v-slot="{ config, items }">
        <Table :config="config" :items="items" />
      </template>
    </PaginationPage>
  </SessionItem>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { SessionItem, Table, PaginationPage, GroupItem } from '@/components/admin/commons'
import { courseApi } from '@/api/admin'
import { ColumnStyle, ControlStyle } from '@/enums/admin.enums';
import { getInputValue } from '@/helpers/input.helper';

const items = ref([]);

const layoutConfig = ref([
    {
        id: 1,
        groupItem: [
            {
                id: "name",
                labelValue: "Tên khóa học",
                colControl: 4,
                controlStyle: ControlStyle.input,
                attribute: {
                    placeholder: "Tên danh mục",
                    showClear: true,
                },
            },]
    },
])

const fetchData = async () => {
  const response = await courseApi.getAllCourse();
  if (response.data.result.isSuccess) {
    console.log(response.data.result.courses)
    items.value = response.data.result.courses;
  }
  else {
    items.value = []
    alert(response.data.result.errorMessage)
  }
}


const tableConfig = {
  options: {
    showDel: true,
    //delClick: delClick
  },
  headers: [
    {
      id: "id",
      name: "Mã khóa học",
      columnStyle: ColumnStyle.text,
      hidden: true
    },
    {
      id: "title",
      name: "Tên khóa học",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "categoryName",
      name: "Tên danh mục",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "description",
      name: "Mô tả",
      columnStyle: ColumnStyle.text,
    },
  ]
}


/*  "title": "C# cơ bản",
        "description": "string",
        "price": 0,
        "imgUrl": "string",
        "categoryId": 1,
        "categoryName": "C#",
        "completedLessons": 0,
        "totalLessons": 0*/

fetchData()
</script>