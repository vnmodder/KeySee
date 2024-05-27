
<template>
    <SessionItem :label="'Danh mục dsad asd asd sa dsa đáa'">
      <GroupItem :config="items" />
    </SessionItem>
    <SessionItem :label="'Bảng dữ liệu'">
      <PaginationPage :config="config" :dataItems="dumydata" :pageSize="8" >
        <template v-slot="{ config, items , startIndex}">
          <Table  :config="config" :items="items" :startIndex="startIndex"/>
        </template>
      </PaginationPage>
    </SessionItem>
  </template>
  
  <script setup lang="ts">
  import {
    SessionItem,
    GroupItem,
    Table,
    PaginationPage,
  } from "@/components/admin/commons";
  import { ColumnStyle, ControlStyle, GroupStyle } from "@/enums/admin.enums";
  import { getInputValue, setInputValue } from "@/helpers/input.helper";
  import { dumydata } from "./dumydata.admin";
  import { ref } from "vue";
  
  const btnSubmit = () => {
    setInputValue(items, "input10", "input10");
  };
  
  const btnOption = () => {
    alert("Đã click")
  };
  
  const btnSubmit2 = () => {
    console.log(getInputValue(items.value, "input10"));
  };
  
  const btnSearch = (value: string | undefined) => {
    console.log(value);
  };
  
  const items = ref([
    {
      id: 1,
      groupItem: [
        {
          id: "input1",
          labelValue: "Test sadsad 1",
          colControl: 5,
          controlStyle: ControlStyle.input,
          attribute: {
            placeholder: "sadsadsad sada",
            showClear: true,
          },
          modelValue: "1",
        },
        {
          id: "input2",
          colControl: 2,
          controlStyle: ControlStyle.input,
          attribute: {
            placeholder: "aa sada",
            showSearch: true,
            onSearchClick: btnSearch,
          },
        },
        {
          id: "input2",
          colControl: 3,
          controlStyle: ControlStyle.input,
          attribute: {
            placeholder: "aa sada",
            showOption: true,
            onOptionClick: btnOption,
          },
        },
        {
          id: "input4",
          labelValue: "Mở",
          colControl: 1,
          controlStyle: ControlStyle.button,
          // className: 'text-danger',
          attribute: {
            onClick: btnSubmit,
          },
        },
      ],
    },
    {
      id: 2,
      groupItem: [
        {
          id: "input3",
          labelValue: "Test sadsada d 3",
          colLabel: 2,
          colControl: 5,
          controlStyle: ControlStyle.dropdown,
          attribute: {
            data: [
              { col: 1, col2: "sdsadsa 2" },
              { col: 2, col2: "sdsadsad 3" },
              { col: 3, col2: "sdsadsa 3" },
            ],
            valueMember: "col",
            displayMember: "col2",
          },
          modelValue: 2,
        },
        {
          id: "input5",
          labelValue: "Test sadasd a 2",
          colControl: 5,
          controlStyle: ControlStyle.dateTime,
          modelValue: new Date(),
        },
  
        {
          id: "input99",
          labelValue: "Mở2",
          colControl: 1,
          controlStyle: ControlStyle.button,
          // className: 'text-danger',
          attribute: {
            onClick: btnSubmit2,
          },
        },
      ],
    },
    {
      id: 3,
      groupItem: [
        {
          id: "input6",
          labelValue: "Test sadsada d 3",
          colControl: 5,
          controlStyle: ControlStyle.file,
        },
        {
          id: "input7",
          labelValue: "Thử chỉ text không ở đây xem sao nè",
          colControl: 3,
          controlStyle: ControlStyle.label,
          className: "text-danger",
        },
      ],
    },
    {
      id: 4,
      groupItem: [
        {
          id: "input0",
          labelValue: "Hàng check box",
          colControl: 2,
          controlStyle: ControlStyle.label,
          className: "fw-bold",
        },
        {
          id: "input8",
          labelValue: "Check 1",
          colControl: 2,
          controlStyle: ControlStyle.checkbox,
          modelValue: true,
        },
        {
          id: "input9",
          labelValue: "Check 2",
          colControl: 2,
          controlStyle: ControlStyle.checkbox,
          className: "text-danger",
        },
      ],
    },
    {
      id: 5,
      groupStyle: GroupStyle.radio,
      groupItem: [
        {
          id: "input0",
          labelValue: "Hàng check radio",
          colControl: 2,
          controlStyle: ControlStyle.label,
          className: "fw-bold",
        },
        {
          id: "input10",
          labelValue: "Radio 1",
          colControl: 2,
          name: "radioItem",
          controlStyle: ControlStyle.radio,
          modelValue: "input10",
        },
        {
          id: "input11",
          labelValue: "Radio 2",
          colControl: 2,
          name: "radioItem",
          controlStyle: ControlStyle.radio,
          className: "text-danger",
        },
        {
          id: "input12",
          labelValue: "Radio 2",
          colControl: 2,
          name: "radioItem",
          controlStyle: ControlStyle.radio,
          className: "text-danger",
        },
        {
          id: "input13",
          labelValue: "Radio ",
          colControl: 2,
          name: "radioItem",
          controlStyle: ControlStyle.radio,
          className: "text-danger",
        },
        {
          id: "input14",
          labelValue: "Radio ",
          colControl: 2,
          name: "radioItem",
          controlStyle: ControlStyle.radio,
          className: "text-danger",
        },
      ],
    },
  ])
  
  const config = {
    headers: [
    {
      id: "cot1",
      name: "Cột 1",
      textAlign: "start",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "cot2",
      name: "Cột 2",
      textAlign: "center",
      columnStyle: ColumnStyle.text,
    },
    {
      id: "cot3",
      name: "Cột 3",
      textAlign: "end",
      columnStyle: ColumnStyle.number,
    },
  ],
  options:{
    showRowHeader:true,
    rowSlected:(r: any,a: number)=> aaaaa(r,a)
  }
}

const aaaaa = (r: any, i:number)=>{
console.log('row', r);
console.log('index', i);
}
  </script>
  