<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <div class="form-control admin-datetime-picker">
                <Datepicker v-model="model" :locale="vi" :id="id" class="form-control btn-outline-custom" :inputFormat="'dd/MM/yyyy'" :typeable="true"  />
            </div>
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

<style scoped>
.v3dp__datepicker{
    width:100%;
}

.admin-datetime-picker{
    margin: 0;
    padding: 0;
    background-color: transparent;
    border: none;
}
</style>