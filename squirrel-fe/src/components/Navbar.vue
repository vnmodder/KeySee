<template>
     <!-- Navbar & Hero Start -->
    <div class="container-fluid position-relative p-0">
        <nav class="navbar navbar-expand-lg navbar-light px-4 px-lg-5 py-3 py-lg-0 primary">
            <a href="" class="navbar-brand p-0">
                <h1 class="text-primary m-0"><i class="fa fa-map-marker-alt me-3"></i>Squirrel</h1>
                <!-- <img src="https://keysee.click/img/logo.png" alt="Logo"> -->
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="fa fa-bars"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav ms-auto py-0">
                    <RouterLink class="nav-item nav-link active" to="/" >Trang chủ</RouterLink>
                    <RouterLink class="nav-item nav-link " to="/about" >Giới thiệu</RouterLink>


                    <!-- <div class="nav-item dropdown">
                        <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown">Pages</a>
                        <div class="dropdown-menu m-0">
                            <a href="destination.html" class="dropdown-item">Destination</a>
                            <a href="booking.html" class="dropdown-item">Booking</a>
                            <a href="team.html" class="dropdown-item">Travel Guides</a>
                            <a href="testimonial.html" class="dropdown-item">Testimonial</a>
                            <a href="404.html" class="dropdown-item">404 Page</a>
                        </div>
                    </div> -->
                </div>
                <div v-if="user" class="nav-item nav-link" >{{ user.userName }}</div>
                <div v-if="user" @click="logout" class="btn btn-primary rounded-pill py-2 px-4" >Đăng xuất</div>
                <RouterLink  v-else  class="btn btn-primary rounded-pill py-2 px-4" to="/login">Đăng nhập</RouterLink>
            </div>
        </nav>

        <div class="container-fluid bg-primary py-5 mb-5 hero-header">
            <!-- <div class="container py-5">
                <div class="row justify-content-center py-5">
                    <div class="col-lg-10 pt-lg-5 mt-lg-5 text-center">
                        <h1 class="display-3 text-white mb-3 animated slideInDown">Enjoy Your Vacation With Us</h1>
                        <p class="fs-4 text-white mb-4 animated slideInDown">Tempor erat elitr rebum at clita diam amet diam et eos erat ipsum lorem sit</p>
                        <div class="position-relative w-75 mx-auto animated slideInDown">
                            <input class="form-control border-0 rounded-pill w-100 py-3 ps-4 pe-5" type="text" placeholder="Eg: Thailand">
                            <button type="button" class="btn btn-primary rounded-pill py-2 px-4 position-absolute top-0 end-0 me-2" style="margin-top: 7px;">Search</button>
                        </div>
                    </div>
                </div>
            </div> -->
        </div>
    </div>
     <!-- Navbar & Hero End -->
</template>

<script  setup lang="ts">
import Cookies from 'js-cookie'
import { userStore } from '../stores/auth';

const userSt = userStore();
let user :any = userSt.checkLogin();

const logout = () => {
    userSt.removeUserStore();
    Cookies.remove('token')
    user = userSt.checkLogin();
};

</script>