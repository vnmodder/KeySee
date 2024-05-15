<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <label v-if="labelValue" class="input-group-text black-text secondary-bg btn-outline-secondary"
               :for="id" >{{ labelValue }}</label>
            <input class="form-control btn-outline-custom"  type="file" :id="id"
                :placeholder="attribute &&attribute?.placeholder" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
    placeholder?: string
}

interface Props extends BaseAttribute {
    attribute?: Attribute,
}

const model = defineModel<any>()

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
    attribute:undefined
})

</script>

<style scoped> 
input[type="file"]::-webkit-file-upload-button {
    visibility: hidden;
    margin-left: -6.7rem;
}
</style>
