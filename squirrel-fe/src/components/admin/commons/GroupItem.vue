<template>
    <template v-for="groupItem in config" :key="groupItem?.id">
        <div class="row d-flex">
            <template v-for="item in groupItem.groupItem" :key="item.id">
                <ButtonItem v-if="item.controlStyle == ControlStyle.button" :labelValue="item.labelValue" :id="item.id"
                    :className="item.className" :colControl="item.colControl" :attribute="item.attribute" />
                <CheckboxItem v-if="item?.controlStyle == ControlStyle.checkbox" :labelValue="item?.labelValue"
                    v-model="item.modelValue" :id="item?.id" :className="item?.className" :colControl="item?.colControl"
                    :attribute="item?.attribute" />
                <RadioItem v-if="item?.controlStyle == ControlStyle.radio" :labelValue="item?.labelValue"
                    v-model="groupItem.groupValue" :id="item?.id" :className="item?.className" :colControl="item?.colControl"
                    :attribute="item?.attribute" :name="item?.name" />
                <BaseInputItem
                    v-if="item.controlStyle != ControlStyle.button && item.controlStyle != ControlStyle.checkbox && item.controlStyle != ControlStyle.radio"
                    :item="item" v-model="item.modelValue" />
            </template>
        </div>
    </template>
</template>

<script setup lang="ts">
import { defineProps, } from 'vue'
import { ButtonItem, BaseInputItem, CheckboxItem, RadioItem } from '.';
import { ControlStyle } from '@/enums/admin.enums';
import type { GroupItemConfig } from './interface';


interface Props {
    config: Array<GroupItemConfig>
}

withDefaults(defineProps<Props>(), {
    config: Array,
})

</script>