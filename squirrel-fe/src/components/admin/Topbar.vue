<template>
    <nav class="navbar navbar-expand-lg navbar-light primary-bg py-4 px-4">
        <div class="d-flex align-items-center">
            <i class="fas fa-align-left text-white fs-4 me-3" @click="menuToggleClick" id="menu-toggle"></i>
            <h2 class="fs-2 m-0 text-white">{{ title }}</h2>
        </div>

        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle text-white fw-bold" href="#" id="navbarDropdown" role="button"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        <i class="fas fa-user me-2"></i>{{ user?.name }}
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="#">Thông tin</a></li>
                        <li><a class="dropdown-item" href="#">Cài đặt</a></li>
                        <li><a class="dropdown-item" @click="logout" href="/login">Đăng xuất</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script setup lang="ts">
import {defineProps} from 'vue'
import { userStore } from '../../stores/auth';
import { storeToRefs } from 'pinia';
import Cookies from 'js-cookie'


const authStore = userStore();
const { user } = storeToRefs(authStore);

const logout = async () => {
    await authStore.logout();
    Cookies.remove('token')
};


interface Props {
    menuToggleClick?: ()=> void,
    title?:string,
}


withDefaults(defineProps<Props>(), {
    menuToggleClick: Function,
    title:"Dashboard",
})

</script>