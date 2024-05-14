<template>
    <template v-for="item in config" :key="item.id">
        <InputItem v-if="item.controlStyle == ControlStyle.input" :labelValue="item.labelValue" v-model="item.modelValue" :id="item.id" :className="item.className"
            :colControl="item.colControl" :attribute="item.attribute" />
        <DropdownItem v-if="item.controlStyle == ControlStyle.dropdown" :labelValue="item.labelValue" v-model="item.modelValue"  :id="item.id" :className="item.className"
            :colControl="item.colControl" :attribute="item.attribute" />
        <DateTimeItem v-if="item.controlStyle == ControlStyle.dateTime" :labelValue="item.labelValue" v-model="item.modelValue"  :id="item.id" :className="item.className"
            :colControl="item.colControl" :attribute="item.attribute" />
        <ButtonItem v-if="item.controlStyle == ControlStyle.button" :labelValue="item.labelValue"  :id="item.id" :className="item.className"
            :colControl="item.colControl" :attribute="item.attribute" />
    </template>
</template>

<script setup lang="ts">
import { defineProps,  } from 'vue'
import { InputItem, DropdownItem, ButtonItem,DateTimeItem } from '.';
import { ControlStyle } from '@/enums/admin.enums';
import type { BaseAttribute } from './interface';


interface Props {
    config: Array<ItemConfig>
}

interface ItemConfig extends BaseAttribute  {
    controlStyle: ControlStyle
    attribute?: object
    modelValue?: any
}

withDefaults(defineProps<Props>(), {
    config: Array,
})
</script>