<template>
    <div class="row d-flex">
        <h1 v-if="title" class="fs-4 mb-3 primary-text fw-bold col-md-6">{{ title }}</h1>
        <div class="col-md-6 d-flex justify-content-end">
            <button v-if="showSearch" class="btn primary-bg  mb-1 ms-1 fw-bold text-white col-md-2">Tìm kím</button>
        </div>
    </div>
    <div class="row">
        <slot></slot>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

interface Props {
    title?: string
    showSearch?:boolean
}
withDefaults(defineProps<Props>(), {
    title: '',
    showSearch: false
})
</script>