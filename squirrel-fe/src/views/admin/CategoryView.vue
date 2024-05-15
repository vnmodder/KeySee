<template>
    <SessionItem :label="'Danh mục dsad asd asd sa dsa đáa'">
        <GroupItem :config="items" />
    </SessionItem>
    <SessionItem :label="'Bảng dữ liệu'">
        <Table :headers="config" :items="data" />
    </SessionItem>
</template>

<script setup lang="ts">
import { SessionItem, GroupItem, Table } from '@/components/admin/commons'
import { ColumnStyle, ControlStyle } from '@/enums/admin.enums'
import { ref } from 'vue'

const btnSubmit = () => {
    console.log('To do')
}

const btnSearch = (value: string | undefined) => {
    console.log(value)
}

const items = ref([
    {
        id: 1,
        groupItem: [
            {
                id: 'input1',
                labelValue: 'Test sadsad 1',
                colControl: 5,
                controlStyle: ControlStyle.input,
                attribute: {
                    placeholder: 'sadsadsad sada',
                    showClear: true
                },
                modelValue: '1'
            },
            {
                id: 'input2',
                labelValue: 'Test 2',
                colControl: 5,
                controlStyle: ControlStyle.input,
                attribute: {
                    placeholder: 'aa sada',
                    showSearch: true,
                    onSearchClick: btnSearch
                },

            },
        ]
    }
    , {
        id: 2,
        groupItem: [
            {
                id: 'input3',
                labelValue: 'Test sadsada d 3',
                colControl: 5,
                controlStyle: ControlStyle.dropdown,
                attribute: {
                    data: [
                        { col: 1, col2: 'sdsadsa 2' },
                        { col: 2, col2: 'sdsadsad 3' },
                        { col: 3, col2: 'sdsadsa 3' },
                    ],
                    valueMember: 'col',
                    displayMember: 'col2'
                },
                modelValue: 2
            },
            {
                id: 'input5',
                labelValue: 'Test sadasd a 2',
                colControl: 5,
                controlStyle: ControlStyle.dateTime,
                modelValue: new Date()
            },
            {
                id: 'input4',
                labelValue: 'Mở',
                colControl: 1,
                controlStyle: ControlStyle.button,
                // className: 'text-danger',
                attribute: {
                    onClick: btnSubmit
                }
            },
        ]
    },
    {
        id: 3,
        groupItem: [
            {
                id: 'input6',
                labelValue: 'Test sadsada d 3',
                colControl: 5,
                controlStyle: ControlStyle.file,
                attribute: {
                    data: [
                        { col: 1, col2: 'sdsadsa 2' },
                        { col: 2, col2: 'sdsadsad 3' },
                        { col: 3, col2: 'sdsadsa 3' },
                    ],
                    valueMember: 'col',
                    displayMember: 'col2'
                },
                modelValue: 2
            },
            {
                id: 'input7',
                labelValue: 'Thử chỉ text không ở đây xem sao nè',
                colControl: 3,
                controlStyle: ControlStyle.label,
                className: 'text-danger',
            },
        ]
    },
    {
        id: 4,
        groupItem: [
        {
                id: 'input0',
                labelValue: 'Hàng check box',
                colControl: 2,
                controlStyle: ControlStyle.label,
                className: 'fw-bold',
            },
            {
                id: 'input8',
                labelValue: 'Check 1',
                colControl: 2,
                controlStyle: ControlStyle.checkbox,
            },
            {
                id: 'input9',
                labelValue: 'Check 2',
                colControl: 2,
                controlStyle: ControlStyle.checkbox,
                className: 'text-danger',
            },
        ]
    },
    {
        id: 5,
        groupItem: [
        {
                id: 'input0',
                labelValue: 'Hàng check radio',
                colControl: 2,
                controlStyle: ControlStyle.label,
                className: 'fw-bold',
            },
            {
                id: 'input10',
                labelValue: 'Radio 1',
                colControl: 2,
                name:'radioItem',
                controlStyle: ControlStyle.radio,
            },
            {
                id: 'input11',
                labelValue: 'Radio 2',
                colControl: 2,
                name:'radioItem',
                controlStyle: ControlStyle.radio,
                className: 'text-danger',
            },
            {
                id: 'input114',
                labelValue: 'Radio 3',
                colControl: 2,
                name:'radioItem',
                controlStyle: ControlStyle.radio,
                className: 'text-success',
            },
        ]
    }
])

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

const data = [
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
    { cot1: 'sadsadsa', cot2: 'sadsadad', cot3: 927792 },
]
</script>