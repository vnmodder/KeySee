<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <button type="button" :id="id" class="btn btn-outline-success fw-bold col-12" @click="attribute?.onClick"
        :class="className">{{ labelValue}}</button>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
  onClick?:()=>void
}

interface Props extends BaseAttribute{
    attribute?: Attribute
}

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 1,
    attribute:undefined
})
</script>