<template>
    <template v-for="groupItem in config" :key="groupItem?.id">
        <div class="row d-flex">
            <template v-for="item in groupItem.groupItem" :key="item.id">
                <InputItem v-if="item.controlStyle == ControlStyle.input" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" />
                <DropdownItem v-if="item.controlStyle == ControlStyle.dropdown" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" />
                <DateTimeItem v-if="item.controlStyle == ControlStyle.dateTime" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" />
                <FileInputItem v-if="item.controlStyle == ControlStyle.file" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" />
                <CheckboxItem v-if="item.controlStyle == ControlStyle.checkbox" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" />
                <RadioItem v-if="item.controlStyle == ControlStyle.radio" :labelValue="item.labelValue"
                    v-model="item.modelValue" :id="item.id" :className="item.className" :colControl="item.colControl"
                    :attribute="item.attribute" :name="item.name" />
                <ButtonItem v-if="item.controlStyle == ControlStyle.button" :labelValue="item.labelValue" :id="item.id"
                    :className="item.className" :colControl="item.colControl" :attribute="item.attribute" />
                <LabelItem v-if="item.controlStyle == ControlStyle.label" :labelValue="item.labelValue" :id="item.id"
                    :className="item.className" :colControl="item.colControl" :attribute="item.attribute" />
            </template>
        </div>
    </template>
</template>

<script setup lang="ts">
import { defineProps, } from 'vue'
import { InputItem, DropdownItem, ButtonItem, DateTimeItem, FileInputItem, LabelItem ,CheckboxItem, RadioItem} from '.';
import { ControlStyle } from '@/enums/admin.enums';
import type { BaseAttribute } from './interface';


interface Props {
    config: Array<GroupItemConfig>
}

interface GroupItemConfig {
    id?: string | number,
    groupStyle?: string,
    groupItem?: Array<ItemConfig>
}

interface ItemConfig extends BaseAttribute {
    controlStyle: ControlStyle
    attribute?: object
    modelValue?: any
}

withDefaults(defineProps<Props>(), {
    config: Array,
})
</script>