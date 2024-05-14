<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <span v-if="labelValue" class="input-group-text black-text secondary-bg btn-outline-secondary" :id="id">{{
                labelValue }}</span>
            <Datepicker v-model="model"  class="form-control btn-outline-secondary" :typeable="true"  />
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';
import Datepicker  from 'vue3-datepicker'
import { vi,enUS } from 'date-fns/locale'

interface Attribute {
    data?: Array<any>,
    valueMember?: string,
    displayMember?: string,
    placeholder?: string
}

interface Props extends BaseAttribute {
    attribute?: Attribute
}


const model = defineModel<Date>()

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
})
</script>