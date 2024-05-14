<template>
    <template v-for="item in config" :key="item.id">
        <InputItem v-if="item.controlStyle == ControlStyle.input" :labelValue="item.labelValue" :id="item.id"
            :colControl="item.colControl" :attribute="item.attribute" />
        <DropdownItem v-if="item.controlStyle == ControlStyle.dropdown" :labelValue="item.labelValue" :id="item.id"
            :colControl="item.colControl" :attribute="item.attribute" />
        <ButtonItem v-if="item.controlStyle == ControlStyle.button" :labelValue="item.labelValue" :id="item.id"
            :colControl="item.colControl" :attribute="item.attribute" />
    </template>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import { InputItem, DropdownItem, ButtonItem } from '.';
import { ControlStyle } from '@/enums/admin.enums';

interface Props {
    config: Array<ItemConfig>
}

interface ItemConfig {
    id?: string,
    labelValue?: string
    inputValue?: string
    colControl?: number
    controlStyle: ControlStyle
    attribute?: object
}

withDefaults(defineProps<Props>(), {
    config: Array,
})
</script>