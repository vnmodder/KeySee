<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <span v-if="labelValue" class="input-group-text black-text secondary-bg btn-outline-secondary"
                :id="'inputGroup-sizing-' + id">{{ labelValue }}</span>
            <select class="form-select btn-outline-secondary admin-form-item" v-model="model" >
                <option v-for="item in attribute?.data" 
                :key="item[attribute?.valueMember??'']" 
                :value="item[attribute?.valueMember??'key']">{{ item[attribute?.displayMember??'value'] }}</option>
            </select>
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
    data?: Array<any>,
    valueMember?: string,
    displayMember?: string,
    placeholder?: string
}

interface Props extends BaseAttribute  {
    attribute?: Attribute
}

const model = defineModel()

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    placeholder: '',
    colControl: 4,
})
</script>