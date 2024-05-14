<template>
    <SessionItem :label="'Category'">
      <GroupItem :config="items"/>
    </SessionItem>
</template>

<script setup lang="ts">
import { SessionItem, GroupItem } from '@/components/admin/commons'
import {ControlStyle} from '@/enums/admin.enums'
const items = [
    {
        id: 'sadsada',
        labelValue: 'Test sadsad 1',
        colControl: 5,
        controlStyle: ControlStyle.input,
        attribute:{
            placeholder:'sadsadsad sada',
            showClear:true
        }
    },
    {
        id: 'sadsada',
        labelValue: 'Test 2',
        colControl: 3,
        controlStyle: ControlStyle.input

    },
    {
        id: 'sadsada',
        labelValue: 'Test sadsada d 3',
        colControl: 7,
        controlStyle: ControlStyle.dropdown,
        attribute:{
            data: [
                {col:1,col2:'sdsadsa 2'},
                {col:1,col2:'sdsadsad 3'},
                {col:1,col2:'sdsadsa 3'},
            ],
            valueMember: 'col1',
            displayMember:'col2'
        }
    },
    {
        id: 'sadsada',
        labelValue: 'Button',
        colControl: 2,
        controlStyle: ControlStyle.button,
        attribute:{
            class: 'text-danger'
        }
    },
]
</script>