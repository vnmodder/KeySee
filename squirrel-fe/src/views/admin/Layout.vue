<template>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <div id="admin">
        <div class="d-flex" id="wrapper" :class="menuToggle ? 'toggled' : ''">
            <LeftMenu :items="menuItems" />
            <div id="page-content-wrapper">
                <Topbar :menuToggleClick="menuToggleClick" />
                <div class="container-fluid px-4 mt-3">
                    <RouterView />
                </div>
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { LeftMenu, PageFooter, Topbar } from '@/components/admin'
import { ref,watch  } from 'vue'
import { adminMenuStore} from '@/stores/admin/admin.menu.store'
import {storeToRefs} from 'pinia'
import { useRoute } from 'vue-router'
const route = useRoute()

const adminMenu = adminMenuStore()
const {menuItems} = storeToRefs(adminMenu)
const menuToggle = ref(false)

const menuToggleClick = () => {
    menuToggle.value = !menuToggle.value
}

watch(route, (newRoute) => {
  adminMenu.updateMenuState(newRoute.path);
}, { immediate: true });
</script>
