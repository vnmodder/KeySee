<template>
    <div>
        <label v-if="labelValue" class="col-md-1 col-sm-4" :for="id">{{ labelValue }}</label>
        <input :class="labelValue ? 'col-md-' + (colControl - 1) + ' col-sm-8' : 'cal-sm-12 col-md-' + colControl"
            type="text" :value="inputValue" :id="id" :placeholder="placeholder" />
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Props {
    id?: string,
    labelValue?: string
    inputValue?: string
    placeholder?: string
    colControl?: number
}
withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    inputValue: '',
    placeholder: '',
    colControl: 4,
})
</script>