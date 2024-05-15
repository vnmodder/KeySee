<template>
    <div class="row d-flex">
        <h1 v-if="label" class="fs-4 mb-3 primary-text fw-bold col-md-6">{{ label }}</h1>
        <div class="col-md-6 d-flex justify-content-end">
            <button class="btn primary-bg  mb-1 ms-1 fw-bold text-white">Haha</button>
            <button class="btn primary-bg  mb-1 ms-1 fw-bold text-white">Haha2</button>
        </div>
    </div>
    <div class="row">
        <slot></slot>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Props {
    label?: string
}
withDefaults(defineProps<Props>(), {
    label: ''
})
</script>