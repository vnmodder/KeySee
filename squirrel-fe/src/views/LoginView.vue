<template>
    <!-- Package Start -->
    <div class="container-xxl py-5">
        <div class="container">
            <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h6 class="section-title bg-white text-center text-primary px-3">Đăng Nhập</h6>
            </div>
            <div class="row g-4 justify-content-center ">
                <div class="container">
                    <div class="row justify-content-center text-center">
                        <div class="col-lg-4 pt-lg-3 mt-lg-3 text-center">
                            <div class="position-relative w-75 mx-auto animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100  py-3 ps-4 pe-5" type="text"
                                    placeholder="Tài khoản" v-model="loginId">
                            </div>
                            <div class="position-relative w-75 mx-auto mt-3 animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100 py-3 ps-4 pe-5" type="password"
                                    placeholder="Mật khẩu" v-model="password">
                            </div>
                            <button type="button" class="btn rounded-pill py-2 px-4  text-light mt-3 bg-primary me-2 "
                                @click="handleLogin">Đăng nhập</button>
                        </div>
                        <p class=" mt-3 animated slideInDown">Quên mật khẩu?</p>
                        <RouterLink class="animated slideInDown" to="/register">Chưa có tài khoản?</RouterLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Package End -->
</template>


<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { userStore } from '../stores/auth';
import Cookies from 'js-cookie'
import authApi from '../api/authenticate-api'


const user = userStore();
const router = useRouter();

const loginId = ref('');
const password = ref('');

const handleLogin = async () => {
    if (loginId.value && password.value) {
        const loginModel = {
            loginId: loginId.value,
            password: password.value,
            rememberMe:false,
        }
        const response = await authApi.login(loginModel);
        if (response) {
            console.log(response)
            user.login(response.userInfo)
            Cookies.set("token", response.token)
            router.push('/');
        }
    } else {
        alert('Please fill in both fields.');
    }
};
</script>
