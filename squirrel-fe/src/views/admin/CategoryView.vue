<template>
    <SessionItem :label="'Category'">
      <GroupItem :config="items"/>
    </SessionItem>
</template>

<script setup lang="ts">
import { SessionItem, GroupItem } from '@/components/admin/commons'
import {ControlStyle} from '@/enums/admin.enums'

const btnSubmit= ()=>{
    console.log(items.find(x=>x.id == 'input1')?.modelValue)
}


const items = [
    {
        id: 'input1',
        labelValue: 'Test sadsad 1',
        colControl: 5,
        controlStyle: ControlStyle.input,
        attribute:{
            placeholder:'sadsadsad sada',
            showClear:true
        },
        modelValue:'123'
    },
    {
        id: 'input2',
        labelValue: 'Test 2',
        colControl: 3,
        controlStyle: ControlStyle.input

    },
    {
        id: 'input3',
        labelValue: 'Test sadsada d 3',
        colControl: 7,
        controlStyle: ControlStyle.dropdown,
        attribute:{
            data: [
                {col:1,col2:'sdsadsa 2'},
                {col:2,col2:'sdsadsad 3'},
                {col:3,col2:'sdsadsa 3'},
            ],
            valueMember: 'col',
            displayMember:'col2'
        },
        modelValue:2
    },
    {
        id: 'input4',
        labelValue: 'Button',
        colControl: 2,
        controlStyle: ControlStyle.button,
        className: 'text-danger',
        attribute:{
            onClick: btnSubmit
        }
    },
]

</script>