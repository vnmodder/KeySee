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
import { categoryApi } from '@/api/admin'
import { ColumnStyle, ControlStyle } from '@/enums/admin.enums';
import { getInputValue } from '@/helpers/input.helper';

const items = ref();

const categoryItem = {
  id: undefined,
  name: '',
  description: '',
  imgUrl: undefined
}

// test
//hjkashdasjk dhsajd kahdsajk
const btnAddCategory = async () => {
  const payload = {
    ...categoryItem,
    name: getInputValue(layoutConfig.value, 'name'),
    description: getInputValue(layoutConfig.value, 'description'),
    imgUrl: getInputValue(layoutConfig.value, 'imgUrl'),
  }

  if (!payload.name) {
    alert("Vui lòng nhập tên danh mục")
    return
  }

  const response = await categoryApi.addAllCategory(payload)
  if (response && response.status == 200) {
    await fetchData()
  }
}

const fetchData = async () => {
  const response = await categoryApi.getAllCategory();
  if (response.data.result.isSuccess) {
    console.log(response.data.result.categorie)
    items.value = response.data.result.categories;
  }
  else {
    items.value = []
    alert(response.data.result.errorMessage)
  }
}
const delClick = async (row: any) => {
  if (!row?.id) {
    return;
  }
  const response = await categoryApi.deleteCategory({id: row.id})
  if (response && response.status == 200) {
    await fetchData()
  }
}

const tableConfig = {
  options: {
    showDel: true,
    delClick: delClick
  },
  headers: [
    {
      id: "id",
      name: "Mã danh mục",
      columnStyle: ColumnStyle.text,
      textAlign: 'center',
      className: 'text-danger'
    },
    {
      id: "name",
      name: "Tên danh mục",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "description",
      name: "Mô tả",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "imgUrl",
      name: "Hình minh họa",
      columnStyle: ColumnStyle.text,
    },
  ]
}



const layoutConfig = ref([
  {
    id: 1,
    groupItem: [
      {
        id: "name",
        labelValue: "Tên danh mục",
        colControl: 4,
        controlStyle: ControlStyle.input,
        attribute: {
          placeholder: "Tên danh mục",
          showClear: true,
        },
      },
      {
        id: "imgUrl",
        colControl: 6,
        labelValue: 'Hình Minh họa',
        controlStyle: ControlStyle.input,
        attribute: {
          placeholder: "Hình Minh họa",
          showClear: true,
        },
      }, {
        id: "btnAdd",
        colControl: 2,
        labelValue: 'Thêm danh mục',
        controlStyle: ControlStyle.button,
        attribute: {
          onClick: btnAddCategory
        },
      }
    ],
  },
  {
    id: 2,
    groupItem: [
      {
        id: "description",
        colControl: 10,
        labelValue: "Mô tả",
        controlStyle: ControlStyle.input,
        attribute: {
          showClear: true,
          placeholder: "Mô tả",
        },
      },
    ],
  },
])


fetchData()
</script>
