<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import './css/main.css'

import {useDarkModeStore} from '@/stores/darkMode'
const darkModeStore = useDarkModeStore()

darkModeStore.set(true)
</script>

<template>
  <RouterView />
</template>

<style scoped>

</style>
