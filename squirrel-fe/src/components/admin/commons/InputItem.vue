<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <span v-if="labelValue" class="input-group-text black-text secondary-bg btn-outline-secondary"
                :id="'inputGroup-sizing-' + id">{{ labelValue }}</span>
            <input class="form-control btn-outline-secondary" type="text" :value="inputValue" :id="id"
                :placeholder="attribute &&attribute?.placeholder" aria-label="Input" aria-describedby="'inputGroup-sizing-'+id" />
            <button v-if="attribute && attribute?.showClear" class="btn btn-outline-secondary">
                <i class="fas fa-times "></i>
            </button>
            <button v-if="attribute && attribute?.showSearch" class="btn btn-outline-secondary">
                <i class="fas fa-search "></i>
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Attribute extends BaseAttribute{
    placeholder?: string
    showClear?: boolean
    showSearch?: boolean
}

interface Props {
    id?: string,
    labelValue?: string
    inputValue?: string
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