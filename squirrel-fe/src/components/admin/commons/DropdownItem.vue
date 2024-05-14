<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <span v-if="labelValue" class="input-group-text black-text secondary-bg btn-outline-secondary"
                :id="'inputGroup-sizing-' + id">{{ labelValue }}</span>
            <select class="form-select btn-outline-secondary" aria-label="Default select example">
                <option v-for="item in attribute?.data" 
                :key="item[attribute?.valueMember??'']"
                :value="item[attribute?.valueMember??'']">{{ item[attribute?.displayMember??''] }}</option>
            </select>
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Attribute extends BaseAttribute {
    data?: Array<any>,
    valueMember?: string,
    displayMember?: string,
}

interface Props {
    id?: string,
    labelValue?: string
    inputValue?: string
    placeholder?: string
    colControl?: number
    attribute?: Attribute
}

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    inputValue: '',
    placeholder: '',
    colControl: 4,
})
</script>