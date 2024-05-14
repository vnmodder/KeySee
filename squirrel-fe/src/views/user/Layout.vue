<template>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet">
    <div id="user">
        <Topbar />
        <Navbar />
        <RouterView />
        <PageFooter />
    </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import { Topbar, Navbar, PageFooter } from "@/components/user"

</script>