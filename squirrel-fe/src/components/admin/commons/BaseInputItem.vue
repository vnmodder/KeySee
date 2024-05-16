<template>
    <LabelItem v-if="item?.controlStyle == ControlStyle.label || item?.labelValue" :labelValue="item?.labelValue"
        :id="item?.id" :className="item?.className" :colControl="calLabeCol(item)" :attribute="item?.attribute" />
    <InputItem v-if="item?.controlStyle == ControlStyle.input" :labelValue="item?.labelValue" v-model="model"
        :id="item?.id" :className="item?.className" :colControl="calControlCol(item)" :attribute="item?.attribute" />
    <DropdownItem v-if="item?.controlStyle == ControlStyle.dropdown" :labelValue="item?.labelValue" v-model="model"
        :id="item?.id" :className="item?.className" :colControl="calControlCol(item)" :attribute="item?.attribute" />
    <DateTimeItem v-if="item?.controlStyle == ControlStyle.dateTime" :labelValue="item?.labelValue" v-model="model"
        :id="item?.id" :className="item?.className" :colControl="calControlCol(item)" :attribute="item?.attribute" />
    <FileInputItem v-if="item?.controlStyle == ControlStyle.file" :labelValue="item?.labelValue" v-model="model"
        :id="item?.id" :className="item?.className" :colControl="calControlCol(item)" :attribute="item?.attribute" />
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import { InputItem, DropdownItem, DateTimeItem, FileInputItem, LabelItem } from '.';
import { ControlStyle } from '@/enums/admin.enums';
import type { ItemConfig } from './interface';


interface Props {
    item: ItemConfig
}

const calLabeCol = (item: ItemConfig): number | undefined => {
    if (item.controlStyle == ControlStyle.label) {
        return item.colControl
    } else if (item?.colLabel) {
        return item?.colLabel
    } else {
        return item?.labelValue ? 2 : 0
    }
}

const calControlCol = (item: ItemConfig): number | undefined => {
    const label = item.labelValue ? item.colLabel ? item.colLabel : 2 : 0
    if(item.colControl){
        return item.colControl - label;
    }
    return item.colControl
}

const model = defineModel<any>()

withDefaults(defineProps<Props>(), {
    item: undefined
})

</script>