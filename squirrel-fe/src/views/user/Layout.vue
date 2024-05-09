<template>
    <Topbar  />
    <Navbar />
    <RouterView />
    <PageFooter />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import { Topbar, Navbar, PageFooter } from "@/components/user"

</script>
<style scoped>
@import '@/assets/user/style.user.css';

</style>