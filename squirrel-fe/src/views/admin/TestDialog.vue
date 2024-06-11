<template>
    <div>
      <button class="btn btn-primary" @click="openDialog">Open Dialog</button>
      <DialogComponent :modelValue="isDialogOpen" @update:modelValue="isDialogOpen = $event">
        <template #title>
          Test View Dialog
        </template>
        <CategoryView />
      </DialogComponent>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  import CategoryView from './CategoryView.vue';
  import {
    DialogComponent,
} from "@/components/admin/commons";
  
  const isDialogOpen = ref(false);
  
  const openDialog = () => {
    isDialogOpen.value = true;
  };
  </script>