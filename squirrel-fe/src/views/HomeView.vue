<template>
  <!-- Package Start -->
  <div class="container-xxl py-5">
    <div class="container">
      <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
        <h6 class="section-title bg-white text-center text-primary px-3">Khóa học mới cập nhật</h6>
        <h1 class="mb-5">Các khóa học mới</h1>
      </div>
      <div class="row g-4 justify-content-center">
        <div class="col-lg-4 col-md-6 wow fadeInUp" v-for="(item , index) in items" :key="index" data-wow-delay="0.1s">
          <div class="package-item">
            <div class="text-center py-2 w-auto ">
              <h3 class="mb-0">{{ item.name }}</h3>
            </div>
            <!-- <div class="overflow-hidden">
              <img class="img-fluid" :src="'@/assets/img/package-'+ ((index%2)+1) +'.jpg'" alt="">
            </div> -->
            <div class="d-flex border-bottom">
              <small class="flex-fill text-center border-end py-2"><i
                  class="fa fa-globe text-primary me-2"></i>C#</small>
              <small class="flex-fill text-center border-end py-2"><i class="fa fa-clock text-primary me-2"></i>60 hours</small>
              <small class="flex-fill text-center py-2"><i class="fa fa-layer-group text-primary me-2"></i>Cơ bản</small>
            </div>
            <div class="text-center p-4">
              <h3 class="mb-0">149,000đ</h3>
              <div class="mb-3">
                <small class="fa fa-star text-primary"></small>
                <small class="fa fa-star text-primary"></small>
                <small class="fa fa-star text-primary"></small>
                <small class="fa fa-star text-primary"></small>
                <small class="fa fa-star text-primary"></small>
              </div>
              <p>Lớp học viết web</p>
              <div class="d-flex justify-content-center mb-2">
                <a href="#" class="btn btn-sm btn-primary px-3 border-end" style="border-radius: 30px 0 0 30px;">Xem chi tiết</a>
                <a href="#" class="btn btn-sm btn-primary px-3" style="border-radius: 0 30px 30px 0;">Đăng ký</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Package End -->

  <!-- Process Start -->
  <div class="container-xxl py-5">
    <div class="container">
      <div class="text-center pb-4 wow fadeInUp" data-wow-delay="0.1s">
        <h6 class="section-title bg-white text-center text-primary px-3">Tại sao nên chọn Squirrel</h6>
        <h1 class="mb-5">3 Lý do để chọn chúng tôi</h1>
      </div>
      <div class="row gy-5 gx-4 justify-content-center">
        <div class="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp" data-wow-delay="0.1s">
          <div class="position-relative border border-primary pt-5 pb-4 px-4">
            <div
              class="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
              style="width: 100px; height: 100px;">
              <i class="fa fa-globe fa-3x text-white"></i>
            </div>
            <h5 class="mt-4">Nhiều ngôn ngữ</h5>
            <hr class="w-25 mx-auto bg-primary mb-1">
            <hr class="w-50 mx-auto bg-primary mt-0">
            <p class="mb-0">Các khóa học được thiết kế trên các ngôn ngữ lập trình đang hot hiện nay.</p>
          </div>
        </div>
        <div class="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp" data-wow-delay="0.5s">
          <div class="position-relative border border-primary pt-5 pb-4 px-4">
            <div
              class="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
              style="width: 100px; height: 100px;">
              <i class="fa fa-clock fa-3x text-white"></i>
            </div>
            <h5 class="mt-4">Chủ động thời gian</h5>
            <hr class="w-25 mx-auto bg-primary mb-1">
            <hr class="w-50 mx-auto bg-primary mt-0">
            <p class="mb-0">Hình thức học online thông qua video và các bài tập nên bạn hoàn toàn có thể tự do về thời gian</p>
          </div>
        </div>
        <div class="col-lg-4 col-sm-6 text-center pt-4 wow fadeInUp" data-wow-delay="0.3s">
          <div class="position-relative border border-primary pt-5 pb-4 px-4">
            <div
              class="d-inline-flex align-items-center justify-content-center bg-primary rounded-circle position-absolute top-0 start-50 translate-middle shadow"
              style="width: 100px; height: 100px;">
              <i class="fa fa-dollar-sign fa-3x text-white"></i>
            </div>
            <h5 class="mt-4">Giá cả phải chăng</h5>
            <hr class="w-25 mx-auto bg-primary mb-1">
            <hr class="w-50 mx-auto bg-primary mt-0">
            <p class="mb-0">bên cạnh các khóa học có phí thì cũng có rất nhiều khóa học miễn phí để bạn lựa chọn </p>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Process Start -->


  <!-- Team Start -->
  <div class="container-xxl py-5">
    <div class="container">
      <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
        <h6 class="section-title bg-white text-center text-primary px-3">Đội ngũ</h6>
        <h1 class="mb-5">Với nhiều giảng viên, nhân viên </h1>
      </div>
      <div class="row g-4">
        <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.1s">
          <div class="team-item">
            <div class="overflow-hidden">
              <img class="img-fluid" src="@/assets/img/team-1.jpg" alt="">
            </div>
            <div class="position-relative d-flex justify-content-center" style="margin-top: -19px;">
              <a class="btn btn-square mx-1" href=""><i class="fab fa-facebook-f"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-twitter"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-instagram"></i></a>
            </div>
            <div class="text-center p-4">
              <h5 class="mb-0">Full Name</h5>
              <small>Giảng viên ĐH Bách khoa</small>
            </div>
          </div>
        </div>
        <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.3s">
          <div class="team-item">
            <div class="overflow-hidden">
              <img class="img-fluid" src="@/assets/img/team-2.jpg" alt="">
            </div>
            <div class="position-relative d-flex justify-content-center" style="margin-top: -19px;">
              <a class="btn btn-square mx-1" href=""><i class="fab fa-facebook-f"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-twitter"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-instagram"></i></a>
            </div>
            <div class="text-center p-4">
              <h5 class="mb-0">Full Name</h5>
              <small>Project manager tại Cty ABC</small>
            </div>
          </div>
        </div>
        <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.5s">
          <div class="team-item">
            <div class="overflow-hidden">
              <img class="img-fluid" src="@/assets/img/team-3.jpg" alt="">
            </div>
            <div class="position-relative d-flex justify-content-center" style="margin-top: -19px;">
              <a class="btn btn-square mx-1" href=""><i class="fab fa-facebook-f"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-twitter"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-instagram"></i></a>
            </div>
            <div class="text-center p-4">
              <h5 class="mb-0">Full Name</h5>
              <small>Giảng viên trường R</small>
            </div>
          </div>
        </div>
        <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.7s">
          <div class="team-item">
            <div class="overflow-hidden">
              <img class="img-fluid" src="@/assets/img/team-4.jpg" alt="">
            </div>
            <div class="position-relative d-flex justify-content-center" style="margin-top: -19px;">
              <a class="btn btn-square mx-1" href=""><i class="fab fa-facebook-f"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-twitter"></i></a>
              <a class="btn btn-square mx-1" href=""><i class="fab fa-instagram"></i></a>
            </div>
            <div class="text-center p-4">
              <h5 class="mb-0">Full Name</h5>
              <small>Team lead của team XXXX</small>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Team End -->

</template>

<script setup lang="ts">
import { ref } from 'vue';
import userApi from '../api/user-api';
const items = ref([] as any[]);

const fetchData = async () => {
  const response = await userApi.getAllUser();
  if (response.data.result.isSuccess) {
    items.value = response.data.result.users;
  }
  else {
    items.value = [] as any[]
    alert(response.data.result.errorMessage)
  }
};

fetchData();
</script>