<template>
            <nav class="navbar navbar-expand-lg fixed-top text-danger">
                <div class="container-fluid">
                    <a class="navbar-brand logo" href="#">
                        <img src="../assets/nav/logo.png" class="w-100" alt="Vietravel logo">
                    </a>

                    <div class="d-flex">
                        <!-- Icon user trong dạng mobile -->
                        <a class="nav-link d-lg-none user_mobile" href="!#">
                            <!-- <i class="fa fa-user" @click="showLogin = true"></i> -->
                            <i class="fa-regular fa-user"></i>
                        </a>

                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                            data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                            aria-label="Toggle navigation" data-bs-auto-close="outside">
                            <span class="navbar-toggler-icon" style="color: #2d4271; font-size: 20px; outline: none;box-shadow: none; ">
                                <i class="fa fa-bars mt-2" aria-hidden="true"></i>
                            </span>
                        </button>
                    </div>

                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" id="navlink-du-lich" role="button"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                    Du lịch
                                </a>
                                <ul class="dropdown-menu" aria-labelledby="navlink-du-lich">
                                    <!-- Menu items here -->
                                    <li><a class="dropdown-item" href="#" target="_blank"
                                            rel="nofollow noreferrer">Thuê xe</a></li>
                                </ul>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#" target="_blank"
                                    rel="nofollow">Vietravel
                                    MICE</a>
                            </li>
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" id="navlink-van-chuyen" role="button"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                    Vận chuyển
                                </a>
                                <ul class="dropdown-menu" aria-labelledby="navlink-van-chuyen">
                                    <li><a class="dropdown-item" href="#" target="_blank"
                                            rel="nofollow noreferrer">Thuê xe</a></li>
                                    <li><a class="dropdown-item" href="#"
                                            target="_blank" rel="nofollow noreferrer">Vé máy bay</a></li>
                                </ul>
                            </li>
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" id="navlink-tin-tuc" role="button"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                    Tin tức
                                </a>
                                <ul class="dropdown-menu" aria-labelledby="navlink-tin-tuc">
                                    <li><a class="dropdown-item" href="#">Tin mới</a></li>
                                    <li><a class="dropdown-item" href="#">Tin tức du lịch</a></li>
                                    <li><a class="dropdown-item" href="#">Cẩm nang du lịch</a>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Kinh nghiệm du
                                            lịch</a></li>
                                </ul>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#" data-bs-toggle="modal"
                                    data-bs-target="#khuyen-mai-modal">Khuyến
                                    mãi</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="!#">VietravelPlus</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="!#">Liên hệ</a>
                            </li>
                        </ul>
                    </div>

                    <ul class="navbar-nav ms-auto nav-right">
                        <form class="d-flex">
                            <input class="form-control" type="text" placeholder="Bắt đầu tìm kiếm..."
                                aria-label="Search">
                            <button class="form-btn btn" type="submit">
                                <i class="fa fa-search" aria-hidden="true"></i>
                            </button>
                        </form>
                        <li class="nav-item">
                            <a class="nav-link" href="!#">
                                <i class="fa-regular fa-user" @click="showLogin = true"></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
    
</template>

<script>
import '@/scss/_header.scss';

    export default {
        name: 'header-component',
    }
</script>