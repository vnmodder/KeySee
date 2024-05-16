<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group">
            <input class="form-control btn-outline-custom" type="text" v-model="model" :id="id"
                :placeholder="attribute && attribute?.placeholder" aria-label="Input"
                aria-describedby="'inputGroup-sizing-'+id" />
            <button v-if="attribute && attribute?.showClear" @click="clear" class="btn btn-outline-custom-2">
                <i class="fas fa-times "></i>
            </button>
            <button v-if="attribute && attribute?.showSearch"
                @click="attribute?.onSearchClick && attribute.onSearchClick(model)" class="btn btn-outline-custom-2">
                <i class="fas fa-search "></i>
            </button>
            <button v-if="attribute && attribute?.showOption"
                @click="attribute?.onOptionClick() && attribute.onOptionClick(model)" class="btn btn-outline-custom-2">
                <i class="fas fa-cog "></i>
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
    placeholder?: string
    showClear?: boolean
    showSearch?: boolean
    showOption?:boolean
    onSearchClick?: (value: any | undefined) => void
    onOptionClick?: (value: any | undefined) => void
}

interface Props extends BaseAttribute {
    attribute?: Attribute,
}

const model = defineModel()

const clear = () => {
    model.value = ''
}

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
    attribute: undefined
})

</script>
