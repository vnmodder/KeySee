<template>
    <!-- Package Start -->
    <div class="container-xxl py-5">
        <div class="container">
            <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h6 class="section-title bg-white text-center text-primary px-3">Đăng ký</h6>
            </div>
            <div class="row g-4 justify-content-center ">
                <div class="container">
                    <div class="row justify-content-center text-center">
                        <div class="col-lg-4 pt-lg-3 mt-lg-3 text-center">
                            <div class="position-relative w-75 mx-auto animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100  py-3 ps-4 pe-5" type="text"
                                    placeholder="Tên" v-model="name">
                            </div>
                            <div class="position-relative w-75 mx-auto mt-3  animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100  py-3 ps-4 pe-5" type="text"
                                    placeholder="Tài khoản" v-model="loginId">
                            </div>
                            <div class="position-relative w-75 mx-auto mt-3 animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100 py-3 ps-4 pe-5" type="password"
                                    placeholder="Mật khẩu" v-model="password">
                            </div>
                            <div class="position-relative w-75 mx-auto mt-3 animated slideInDown">
                                <input class="form-control border-2 rounded-pill w-100 py-3 ps-4 pe-5" type="mail"
                                    placeholder="Email" v-model="email">
                            </div>
                            <button type="button" class="btn rounded-pill py-2 px-4  text-light mt-3 bg-primary me-2 "
                                @click="handleRegister">Đăng ký</button>
                        </div>
                        <a class=" mt-3 animated slideInDown" href="/login">Quay lại đăng nhập</a>
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
import authApi from '../api/authenticate-api'


const router = useRouter();
const loginId = ref('');
const password = ref('');
const name = ref('');
const email = ref('');


const handleRegister = async () => {
    if (loginId.value && password.value&& name.value && email.value) {
        const response = await authApi.register(loginId.value, password.value, name.value, email.value);
        if (response.status === 200) {
            alert("Đăng ký thành công!");
            router.push('/login');
        }else{
            console.log(response)
            alert(response.data.title);
        }
    } else {
        alert('Hãy nhập đủ thông tin.');
    }
};
</script>
