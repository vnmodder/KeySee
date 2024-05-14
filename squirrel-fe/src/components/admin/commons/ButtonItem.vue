<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <button type="button" :id="id" class="btn btn-success col-12"
        :class="attribute?.class??''"
        >{{ labelValue}}</button>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Attribute extends BaseAttribute{
  
}

interface Props {
    id?: string,
    labelValue?: string
    colControl?: number
    attribute?: Attribute
}

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
})
</script>