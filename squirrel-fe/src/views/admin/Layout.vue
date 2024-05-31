<template>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <div id="admin">
        <div class="d-flex" id="wrapper" :class="menuToggle ? 'toggled' : ''">
            <LeftMenu :items="menuItem" :onClick="onClick" />
            <div id="page-content-wrapper">
                <Topbar :menuToggleClick="menuToggleClick" :title="headerTitle" />
                <div class="container-fluid px-4 mt-3">
                    <RouterView />
                </div>
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { LeftMenu, PageFooter, Topbar } from '@/components/admin'
import { reactive, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { menuItems } from '@/views/admin/admin.menu'
import type { MenuItem } from '@/components/admin/commons/interface'
const route = useRoute()

const menuItem = reactive(menuItems)
const menuToggle = ref(false)
const headerTitle = ref<string | undefined>('')

const menuToggleClick = () => {
    menuToggle.value = !menuToggle.value
}

const onClick = (item: MenuItem) => {
    menuItem.forEach(x => {
        x.isAtive = item.id == x.id
    });
    headerTitle.value = menuItem.find(x => x.isAtive)?.name
}

watch(route, (newRoute) => {
    menuItem.forEach(x => {
        x.isAtive = newRoute.path == x.href || newRoute.path == x.href +'/'
    });
    headerTitle.value = menuItem.find(x => x.isAtive)?.name
}, { immediate: true });
</script>
