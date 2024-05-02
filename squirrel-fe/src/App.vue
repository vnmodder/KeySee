<script setup lang="ts">
import { RouterView, useRoute } from 'vue-router'
import {Topbar, Navbar, PageFooter} from "@/components"

const route = useRoute()
</script>

<template>

  <Topbar v-if="route.meta.layout !== 'empty'" />
  <Navbar v-if="route.meta.layout !== 'empty'" />

  <RouterView />

  <PageFooter v-if="route.meta.layout !== 'empty'" />
</template>

<style scoped></style>
