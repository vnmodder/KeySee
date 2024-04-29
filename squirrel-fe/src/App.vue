<script setup lang="ts">
import {RouterView } from 'vue-router'
import Topbar from './components/Topbar.vue'
import Navbar from "./components/Navbar.vue";
import Footer from "./components/Footer.vue"

</script>

<template>
  
  <Topbar/>
  <Navbar/>

  <RouterView/>

  <Footer/>
</template>

<style scoped>


</style>
