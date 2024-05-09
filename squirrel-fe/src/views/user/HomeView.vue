<template>
  
  <h1>Home</h1>

</template>

<script setup lang="ts">
import { ref } from 'vue';
import {userAPI} from '@/api/user';
const items = ref([] as any[]);

const fetchData = async () => {
  const response = await userAPI.getAllCourse();
  if (response.data.result.isSuccess) {
    console.log(response.data.result.courses)

    items.value = response.data.result.courses;
  }
  else {
    items.value = [] as any[]
    alert(response.data.result.errorMessage)
  }
};

fetchData();
</script>