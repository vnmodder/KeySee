<template>
    <div class="bg-white" id="sidebar-wrapper">
        <div class="sidebar-heading text-center py-4 primary-text fs-4 fw-bold text-uppercase border-bottom"><i
                class="fas fa-user-secret me-2"></i>{{ title }}</div>
        <div v-if="items" class="list-group list-group-flush my-3">
            <RouterLink  v-for="(item, index) in items" :key="index" :to="item.href ? item.href : '#'"
                class="list-group-item list-group-item-action bg-transparent "
                :class="item.isAtive ? 'acitve primary-text' : 'second-text text-bold'" @click="onClick(item)">
                <i class="fas me-2" :class="item.icon ? item.icon : ''"></i>
                {{ item.name }}
            </RouterLink>
        </div>
    </div>
</template>

<script setup lang="ts">
import {defineProps} from 'vue'
import type { MenuItem } from '@/components/admin/commons/interface';


interface Props {
    items?: Array<MenuItem>,
    title?: string,
    onClick?:(item: MenuItem)=>void
}

withDefaults(defineProps<Props>(), {
    items: Array,
    title: 'Squrrel',
    onClick:(item: MenuItem)=>{    }
})

</script>