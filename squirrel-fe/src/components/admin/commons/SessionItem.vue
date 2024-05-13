<template>
    <h3 class="fs-4 mb-3">{{ label }}</h3>
    <div class="col">
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