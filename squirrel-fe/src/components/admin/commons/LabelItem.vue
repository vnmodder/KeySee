<template>
    <div class="mb-3 d-flex align-items-center" :class="colControl ? 'col-md-' + colControl : ''">
        <span :class="className" >{{labelValue}}</span> 
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'
import type { BaseAttribute } from './interface';

interface Attribute {
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