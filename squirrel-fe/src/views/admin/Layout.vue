<template>
    <!-- <div id="wrapper">
        <LeftMenu />
        <div id="content-wrapper" class="d-flex flex-column">
            <div id="content">
                <div class="container-fluid">
                    <Topbar/>
                    <router-view />
                </div>
            </div>
            <PageFooter/>
        </div>
    </div> -->

    <div class="w-screen h-screen flex">
        <div class="w-[400px] h-full bg-gray-200 text-white" v-if="isShowLeft">
            <div class="h-[50px] px-3  bg-gray-900 flex justify-start items-center">
                <span class="fa fa-bars mr-2 cursor-pointer" @click="showLeft"></span>
                <router-link to="/admin" >
                Admin
            </router-link>
            </div>
            <div class="h-[calc(100vh-50px)]  bg-gray-800">
                <div class="px-2 flex flex-col space-y-1"> 
                    <router-link to="/admin" class="inline-flex relative items-center p-1 w-full rounded-md border-gray-200 hover:bg-gray-300">
                        <span class="fa fa-home mr-2" ></span>
                        Trang chủ
                    </router-link>
                    <router-link to="/admin/about" class="inline-flex relative items-center p-1 w-full rounded-md border-gray-200 hover:bg-gray-300">
                        <span class="fa fa-user mr-2"></span>
                         Tài khoản                   
                    </router-link>
                    <router-link to="/admin/about" class="inline-flex relative items-center p-1 w-full rounded-md border-gray-200 hover:bg-gray-300">
                        <span class="fa fa-book-open mr-2"></span>
                        Khóa học                    
                    </router-link>
                    <router-link to="/admin/about" class="inline-flex relative items-center p-1 w-full rounded-md border-gray-200 hover:bg-gray-300">
                        <span class="fa fa-list-ul mr-2"></span>
                        Bài học                   
                    </router-link>
                </div>
            </div>
        </div>
        <div class="w-full h-full bg-gray-400">
            <div class="h-[50px] px-3  bg-gray-200 shadow-sm boder-b z-10 w-full flex items-center">
                <span class="fa fa-bars mr-2 cursor-pointer" @click="showLeft" v-if="!isShowLeft"></span>
                <div class="flex w-[calc(100%-30px)]">
                    <div class="w-[calc(100%-200px)] justify-center flex">
                        <div class="w-[200px]" >
                            <label for="headerSearch" class="sr-only">Search</label>
                            <div class="relative w-full">
                                <span class="fa fa-search flex absolute  cursor-pointer right-0 items-center pr-3 pt-3"></span>
                                <input id="headerSearch" class=" boder text-gray-800 rounded-lg boder-gray-300 bg-gray-50" />
                            </div>
                        </div>
                    </div>
                    <div class="w-[200px] items-center space-x-4 justify-start flex" >
                        <div class="w-10 h-10 bg-gray-500 rounded-full border-2">XXXX</div>
                        <div class=""></div>
                    </div>
                </div>
            </div>
            <div class="h-[calc(100vh-100px)]  bg-white">
                <router-view />
            </div>
            <div class="h-[50px] px-3 bg-gray-100 text-white">
                
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { LeftMenu, PageFooter, Topbar } from '@/components/admin'
import { ref } from 'vue';

const isShowLeft = ref(true)

const showLeft = ()=>{
    isShowLeft.value =!isShowLeft.value;
}
</script>

<style scoped>
@import '@/assets/admin/style.admin.css';
</style>
