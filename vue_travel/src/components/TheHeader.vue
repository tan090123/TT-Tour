<template>
    <nav class="navbar navbar-expand-lg fixed-top text-danger">
        <div class="container-fluid">
            <router-link class="navbar-brand logo" :to="{ name: 'HomePage' }">
                <img src="@/../public/images/nav/logo.png" class="w-100" alt="Vietravel logo">
            </router-link>

            <div class="d-flex">
                <!-- Icon user trong dạng mobile -->
                <router-link class="nav-link d-lg-none user_mobile" :to="{ name: 'login_component' }">
                    <i class="fa-regular fa-user"></i>
                </router-link>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                    aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation"
                    data-bs-auto-close="outside">
                    <span class="navbar-toggler-icon"
                        style="color: #2d4271; font-size: 20px; outline: none;box-shadow: none; ">
                        <i class="fa fa-bars mt-2" aria-hidden="true"></i>
                    </span>
                </button>
            </div>

            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item dropdown nav-full">
                        <a class="nav-link dropdown-toggle" href="#" id="navlink-du-lich" role="button"
                            data-bs-toggle="dropdown" aria-expanded="false">
                            Du lịch
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navlink-du-lich">
                            <!-- Menu items here -->
                    <li>
                        <a class="dropdown-item" href="#" target="_blank" rel="nofollow noreferrer">Tour du lịch
                            trong nước</a>
                    </li>
            </div>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#" target="_blank" rel="nofollow">Vietravel
                    MICE</a>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navlink-van-chuyen" role="button" data-bs-toggle="dropdown"
                    aria-expanded="false">
                    Vận chuyển
                </a>
                <ul class="dropdown-menu mt-3" aria-labelledby="navlink-van-chuyen">
                    <li><a class="dropdown-item" href="#" target="_blank" rel="nofollow noreferrer">Thuê xe</a></li>
                    <li><a class="dropdown-item" href="#" target="_blank" rel="nofollow noreferrer">Vé máy bay</a>
                    </li>
                </ul>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navlink-tin-tuc" role="button" data-bs-toggle="dropdown"
                    aria-expanded="false">
                    Tin tức
                </a>
                <ul class="dropdown-menu mt-3" aria-labelledby="navlink-tin-tuc">
                    <li><a class="dropdown-item" href="#">Tin mới</a></li>
                    <li><a class="dropdown-item" href="#">Tin tức du lịch</a></li>
                    <li><a class="dropdown-item" href="#">Cẩm nang du lịch</a>
                    </li>
                    <li><a class="dropdown-item" href="#">Kinh nghiệm du
                            lịch</a></li>
                </ul>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#" data-bs-toggle="modal" data-bs-target="#khuyen-mai-modal">Khuyến
                    mãi</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="!#">VietravelPlus</a>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: 'contact' }">Liên hệ</router-link>
                <!-- <a class="nav-link" href="/contact">Liên hệ</a> -->
            </li>
            </ul>
        </div>

        <ul class="navbar-nav ms-auto nav-right">
            <form class="d-flex" v-if="!userEmail">
                <input class="form-control" type="text" placeholder="Bắt đầu tìm kiếm..." aria-label="Search">
                <button class="form-btn btn" type="submit">
                    <i class="fa fa-search" aria-hidden="true"></i>
                </button>
            </form>
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: 'login_component' }">
                    <i class="fa-regular fa-user" @click="showLogin = true" v-if="!userEmail" ></i>
                </router-link>
            </li>
            <li class="nav-item">
                <span v-if="userEmail"  class="user-email nav-link">{{ userEmail }}</span>
            </li>
            <li  class="nav-item">
                <p v-if="userEmail" class="logout nav-link" @click="logout">
                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                </p>
            </li>
        </ul>
        </div>
    </nav>
</template>

<script>
export default {
    name: 'header-component',
    data() {
        return {
            userEmail: '',
        }
    },
    mounted() {
    // Lấy email từ localStorage hoặc sessionStorage
    this.userEmail = localStorage.getItem('userEmail');
  },
  methods: {
    logout() {
      // Xóa email từ localStorage hoặc sessionStorage
      localStorage.removeItem('userEmail');
      // Điều hướng đến trang đăng nhập hoặc trang chủ
      window.location.href = '/login';
    }
    }
}
</script>

<style lang="scss">
@import '@/assets/scss/_header.scss';
</style>