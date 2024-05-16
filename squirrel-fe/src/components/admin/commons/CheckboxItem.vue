<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group admin-input-group">
            <input class="form-check-input" type="checkbox" v-model="model"  :id="id">
            <label v-if="labelValue" :class="className" :for="id" class="form-check-label black-text ms-2">{{labelValue }}</label>
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
    data?: Array<any>,
}

interface Props extends BaseAttribute {
    attribute?: Attribute
}


const model = defineModel<boolean>()

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
})
</script>