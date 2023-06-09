<template lang="">
    <!-- ========== Start TourMain ========== -->
    <div class="tourMain">
        <div class="tourMain__img">
            <img src="@/../public/images/banner/banner.jpg" class="w-100" alt="" />
        </div>
        <div class="tourMain__both container shadow">

            <div class="tourMain__both-nav">

                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home"
                            type="button" role="tab" aria-controls="home" aria-selected="true">
                            <i class="fa-solid fa-bus mb-2 fs-3"></i>
                            <p>Tour du lịch <br>trọn gói </p>
                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile"
                            type="button" role="tab" aria-controls="profile" aria-selected="false">
                            <i class="fa-solid fa-hotel mb-2 fs-3"></i>
                            <p>Khách sạn</p>
                            <small class="badge btn-danger">Ưu đãi hot</small>
                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="messages-tab" data-bs-toggle="tab" data-bs-target="#messages"
                            type="button" role="tab" aria-controls="messages" aria-selected="false">
                            <i class="fa-solid fa-jet-fighter-up mb-2 fs-3"></i>
                            <p>Vé máy bay</p>
                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="settings-tab" data-bs-toggle="tab" data-bs-target="#settings"
                            type="button" role="tab" aria-controls="settings" aria-selected="false">
                            <div class="d-flex">
                                <i class="fa-solid fa-jet-fighter-up me-2 fs-3"></i>
                                <p>+</p>
                                <i class="fa-solid fa-hotel ms-2 fs-3"></i>
                            </div>
                            <p>Combo</p>
                            <p>Vé máy bay + Khách sạn</p>

                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="carAndres-tab" data-bs-toggle="tab" data-bs-target="#carAndres"
                            type="button" role="tab" aria-controls="carAndres" aria-selected="false">
                            <div class="d-flex">
                                <i class="fa-solid fa-car me-2 fs-3"></i>
                                <p>+</p>
                                <i class="fa-solid fa-hotel ms-2 fs-3"></i>
                            </div>
                            <p>Combo</p>
                            <p>Xe + Khách sạn</p>

                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="search-tab" data-bs-toggle="tab" data-bs-target="#search"
                            type="button" role="tab" aria-controls="search" aria-selected="false">
                            <i class="fa-solid fa-magnifying-glass mb-2 fs-3"></i>
                            <p>Tra cứu Booking</p>
                        </button>
                    </li>
                </ul>
            </div>

            <div class="tourMain__both-tab">
                <div class="tab-content">

                    <div class="tab-pane active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="p-4">

                            <div class="tab-nav">
                                <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                                    <li class="nav-item me-3" role="presentation">
                                        <button class="nav-link dltn active" id="pills-home-tab" data-bs-toggle="pill"
                                            data-bs-target="#pills-home" type="button" role="tab"
                                            aria-controls="pills-home" aria-selected="true">
                                            Du lịch trong nước
                                        </button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link dlnn" id="pills-profile-tab" data-bs-toggle="pill"
                                            data-bs-target="#pills-profile" type="button" role="tab"
                                            aria-controls="pills-profile" aria-selected="false">
                                            Du lịch nước
                                            ngoài
                                        </button>
                                    </li>
                                </ul>
                            </div>


                        </div>
                        <div class="tab-content p-4">

                            <div class="tab-pane active" id="pills-home" role="tabpanel"
                                aria-labelledby="pills-home-tab">

                                <ul class="nav nav-tablist mb-3" id="tablist-tab" role="tablist">
                                    <li class="nav-item me-3" role="presentation">
                                        <button class="nav-link active" id="nav-package-tab" data-bs-toggle="tab"
                                            data-bs-target="#nav-package" type="button" role="tab"
                                            aria-controls="nav-home" aria-selected="true">
                                            Tour trọn gói
                                        </button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="nav-destination-tab" data-bs-toggle="tab"
                                            data-bs-target="#nav-destination" type="button" role="tab"
                                            aria-controls="nav-home" aria-selected="false">
                                            Dịch vụ điểm đến
                                        </button>
                                    </li>
                                </ul>
                                <div class="tab-content p-4">
                                    <div class="tab-pane active" id="nav-package" role="tabpanel"
                                        aria-labelledby="nav-package-tab">
                                        <div class="row">
                                            <div class="col-6 row">
                                                <div class="col-5">
                                                    <select
                                                        class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                        aria-label="Default select example">
                                                        <option selected>Điểm đi</option>
                                                        <option value="1">One</option>
                                                        <option value="2">Two</option>
                                                        <option value="3">Three</option>
                                                    </select>

                                                </div>
                                                <div class="col-2 text-center mt-3"><i
                                                        class="fa-solid fa-right-left fa-2x"></i></div>
                                                <div class="col-5">
                                                    <select
                                                        class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                        aria-label="Default select example">
                                                        <option selected>Điểm đến</option>
                                                        <option value="1">One</option>
                                                        <option value="2">Two</option>
                                                        <option value="3">Three</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-3">
                                                <input type="date"
                                                    class='w-100 h-100 p-3 border border-warning border-5 text-center'
                                                    name="" id="">
                                            </div>
                                            <div class="col-2">
                                                <select
                                                    class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                    aria-label="Default select example">
                                                    <option selected>Số ngày</option>
                                                    <option value="1">One</option>
                                                    <option value="2">Two</option>
                                                    <option value="3">Three</option>
                                                </select>
                                            </div>
                                            <div class="col-1">
                                                <router-link :to="{ name: 'tours_search' }" type='submit'
                                                    class='btn btn-primary w-100 h-100'>
                                                    <i class="fa-solid fa-magnifying-glass fa-3x"></i>
                                                </router-link>
                                                <!-- <button type='submit' class='btn btn-primary w-100 h-100'>
                                                    <i class="fa-solid fa-magnifying-glass fa-3x"></i>
                                                </button> -->

                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane" id="nav-destination" role="tabpanel"
                                        aria-labelledby="nav-destination-tab">
                                        <div class="row">
                                            <div class="col-4">

                                                <select
                                                    class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                    aria-label="Default select example">
                                                    <option selected>Điểm đến</option>
                                                    <option value="1">One</option>
                                                    <option value="2">Two</option>
                                                    <option value="3">Three</option>
                                                </select>



                                            </div>

                                            <div class="col-4">
                                                <input type="date"
                                                    class='w-100 h-100 p-3 border border-warning border-5 text-center'
                                                    name="" id="">
                                            </div>
                                            <div class="col-4">
                                                <button type='submit' class='btn btn-primary w-100 h-100'>
                                                    <i class="fa-solid fa-magnifying-glass fa-3x"></i>
                                                </button>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="tab-pane" id="pills-profile" role="tabpanel"
                                aria-labelledby="pills-profile-tab">
                                <div class="row">
                                    <div class="col-6 row">
                                        <div class="col-5">
                                            <select
                                                class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                aria-label="Default select example">
                                                <option selected>Điểm đi</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>

                                        </div>
                                        <div class="col-2 text-center mt-3"><i class="fa-solid fa-right-left fa-2x"></i>
                                        </div>
                                        <div class="col-5">
                                            <select
                                                class="form-select text-center fs-3 border border-warning border-5 p-3"
                                                aria-label="Default select example">
                                                <option selected>Điểm đến</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <input type="date"
                                            class='w-100 h-100 p-3 border border-warning border-5 text-center' name=""
                                            id="">
                                    </div>
                                    <div class="col-2">
                                        <select class="form-select text-center fs-3 border border-warning border-5 p-3"
                                            aria-label="Default select example">
                                            <option selected>Số ngày</option>
                                            <option value="1">One</option>
                                            <option value="2">Two</option>
                                            <option value="3">Three</option>
                                        </select>
                                    </div>
                                    <div class="col-1">
                                        <button type='submit' class='btn btn-primary w-100 h-100'>
                                            <i class="fa-solid fa-magnifying-glass fa-3x"></i>
                                        </button>

                                    </div>
                                </div>
                            </div>



                        </div>

                    </div>

                    <div class="tab-pane" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                        this í 2
                    </div>
                    <div class="tab-pane" id="messages" role="tabpanel" aria-labelledby="messages-tab">
                        3
                    </div>
                    <div class="tab-pane" id="settings" role="tabpanel" aria-labelledby="settings-tab">
                        4
                    </div>
                    <div class="tab-pane" id="carAndres" role="tabpanel" aria-labelledby="carAndres-tab">
                        5
                    </div>
                    <div class="tab-pane" id="search" role="tabpanel" aria-labelledby="search-tab">
                        6
                    </div>
                </div>

            </div>
        </div>

    </div>
    <!-- ========== End TourMain ========== -->

    <!-- ========== Start Tour Carousel ========== -->
    <div class="carousel">
        <div class="container-fluid">
            <h2 class="carousel-title">Ưu đãi</h2>
            <div class="owl-carousel owl-theme">
                <div class="item">
                    <a href="#">
                        <img src="@/../public/images/owl_carousel/bn_230403_TourHongKong_1024-768px.png"
                            alt="Hong Kong">
                    </a>
                </div>
                <div class="item">
                    <a href="#">
                        <img src="@/../public/images/owl_carousel/bn_230403_HANQUOC-DAINHACHOI_1024-768px.png"
                            alt="Dai hoi han quoc">
                    </a>
                </div>
                <div class="item">
                    <a href="#">
                        <img src="@/../public/images/owl_carousel/bn__230511_.png" alt="Dai hoi han quoc 4 ngay 3 dem">
                    </a>
                </div>
                <div class="item">
                    <a href="#">
                        <img src="@/../public/images/owl_carousel/bn__230510_.png" alt="Trai nghiem mua he nuoc uc">
                    </a>
                </div>
            </div>
        </div>
    </div>
    <!-- ========== End Tour Carousel ========== -->

    <!-- ========== Start Tour Khám Phá ========== -->
    <div class="tourkp">
        <div class="container-fluid">
            <h2 class="tourkp__title">Khám phá sản phẩm Vietravel</h2>
            <div class="row justify-content-between">
                <div class="tourkp__card col-12 col-lg-2">
                    <div class="tourkp__img">
                        <a href="">
                            <img class="w-100" src="@/../public/images/tourkp/kp1.jpg"
                                alt="Tự hào nét Việt: Ưu đãi kích cầu du lịch trong nươc">
                        </a>
                    </div>
                    <div class="tourkp__text">
                        <a href="#">Tự hào nét Việt: Ưu đãi kích cầu du lịch trong nước</a>
                    </div>
                </div>
                <div class="tourkp__card col-12 col-lg-2">
                    <div class="tourkp__img">
                        <a href="">
                            <img class="w-100" src="@/../public/images/tourkp/kp2.jpg" alt="Đến Úc trượt tuyết mùa hè">
                        </a>
                    </div>
                    <div class="tourkp__text">
                        <a href="#">Đến Úc trượt tuyết mùa hè</a>
                    </div>
                </div>
                <div class="tourkp__card col-12 col-lg-2">
                    <div class="tourkp__img">
                        <a href="">
                            <img class="w-100" src="@/../public/images/tourkp/kp3.jpg"
                                alt="TLễ hội Pháo hoa Quốc tế Đà Nẵng 2023">
                        </a>
                    </div>
                    <div class="tourkp__text">
                        <a href="#">Lễ hội Pháo hoa Quốc tế Đà Nẵng 2023</a>
                    </div>
                </div>
                <div class="tourkp__card col-12 col-lg-2">
                    <div class="tourkp__img">
                        <a href="">
                            <img class="w-100" src="@/../public/images/tourkp/tourkp4.jpg"
                                alt="Dưới bầu trời Tây Âu thơ mộng">
                        </a>
                    </div>
                    <div class="tourkp__text">
                        <a href="#">Dưới bầu trời Tây Âu thơ mộng</a>
                    </div>
                </div>
                <div class="tourkp__card col-12 col-lg-2">
                    <div class="tourkp__img">
                        <a href="">
                            <img class="w-100" src="@/../public/images/tourkp/kp4.jpg"
                                alt="[ MỚI ] Tour trải nghiệm độc lạ, sự kiện, thể thao">
                        </a>
                    </div>
                    <div class="tourkp__text">
                        <a href="#">[ MỚI ] Tour trải nghiệm độc lạ, sự kiện, thể thao</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ========== End Tour Khám Phá ========== -->

    <!-- ========== Start Tour Card ========== -->
    <div class="TourCard">
        <div class="container-fluid">
            <h1 class="TourCard__title">Ưu đãi tour giờ chót</h1>
            <div class="TourCard__content row row-cols-lg-3 row-cols-1">
                <div class="col mt-sm-auto" v-for="card in cards.slice(0,3)" :key="card.tourID">
                    <div class="card">
                        <div class="img">
                            <router-link :to="{name:'details-id',params:{id:card.tourID}}">
                                <img :src="require(`@/../public/images/card/${card.tourImage}`)" class="card-img-top"
                                    width="100%" :alt="card.tourName">
                            </router-link>
                            <div class="img-icon">
                                <a href="">
                                    <i class="fa-regular fa-heart fs-1"></i>
                                </a>
                            </div>
                            <div class="img-bottom">
                                <span>
                                    <i class="fa-sharp fa-solid fa-circle-dollar-to-slot"></i>
                                    Giờ chót
                                </span>
                            </div>
                            <div class="img-sumary">
                                <div class="img-sumary--ratting">
                                    <span>5</span>
                                </div>
                                <div class="img-sumary--review">
                                    <h3 class="fw-bold">Rất tốt</h3>
                                    <p class="fw-lighter">358 quan tâm</p>
                                </div>
                            </div>
                        </div>

                        <div class="body card-body">
                            <p class="p-date">{{ card.tourCheckinDays }}</p>
                            <p class="p-title">
                                <a href="">
                                    {{ card.tourName }}
                                </a>
                            </p>
                            <div class="code">
                                <p>Mã tour:</p>
                                <p><i class="fa-solid fa-ticket"></i>
                                    {{ card.tourCode }}</p>
                            </div>
                            <p class="p-startPlace">Nơi khởi hành: {{ card.departure }}</p>
                            <div class="price">
                                <p class="price-old">
                                    Giá: <span class="text-decoration-line-through"
                                        v-if="card.price!=card.promotionPrice">{{ formatter.format(card.price)
                                        }}</span>
                                </p>
                                <div class="price-now">
                                    <span class="price-now-number">{{ formatter.format(card.promotionPrice) }}</span>
                                    <span class="price-now-discount" v-if="card.price!=card.promotionPrice">{{
                                        card.discountTour }} GIẢM</span>
                                </div>
                            </div>
                            <div class="timer">
                                <span>{{ card.tourCheckoutDays }}</span>
                            </div>
                            <div class="addList-numberSit">
                                <div class="addList">
                                    <i class="fa-solid fa-circle-plus me-2"></i>
                                    <a href="">Thêm vào danh sách</a>
                                </div>
                                <div class="numberSit d-flex align-items-center justify-content-center">
                                    <p class="text-decoration-underline me-2">Số chỗ còn</p>
                                    <p class="text-danger fw-bold" style="font-size: 22px;">{{ card.tourAvailableSit }}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="TourCard__btn d-block-inline text-end">
                <router-link class="nav-link" :to="{ name: 'tours_page' }">
                    <button>Xem tất cả <i class="fa-sharp fa-solid fa-arrow-right-long ms-2"></i></button>
                </router-link>
                <!-- <a href=""><button>Xem tất cả <i class="fa-sharp fa-solid fa-arrow-right-long ms-2"></i></button></a> -->
            </div>
        </div>
    </div>
    <!-- ========== End Tour Card ========== -->

    <!-- ========== Start Tour Product ========== -->
    <div class="tour-product">
        <div class="container-fluid">
            <h2 class="product-title">Gói ưu đãi đặc biệt</h2>
            <div class="product-item mb-5" v-for="(product, index) in products.slice(0, 3)" :key="index">
                <div class="row h-100">
                    <div class="col-12 col-lg-3 product-item__image">
                        <a href="!#">
                            <img :src="require(`@/../public/images/product/${product.images}`)" :alt="product.name">
                        </a>
                    </div>
                    <div class="col-12 col-lg-6 product-item__details">
                        <div class="product-item__category d-none p-2 d-lg-inline-block mt-4">
                            <a href="#" rel="nofollow no-referrer" target="_blank">Xe + khách sạn</a>
                        </div>
                        <h3 class="product-item__title mt-3">
                            <a href="!#">{{ product.name }}</a>
                        </h3>
                        <div class="product-item__rating">
                            <div class="d-inline-block star-booking" v-for="star in product.rating" :key="star">
                                <i class="icon fa fa-star" aria-hidden="true"></i>
                            </div>
                        </div>

                        <div class="product-item__price d-lg-none mt-3">
                            <div class="card-text">Giá chỉ từ</div>
                            <div class="card-price">
                                <div class="card-price__current--number">{{ formatter.format(product.price) }}</div>
                                <div class="card-price__current--text">/khách</div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-6">
                                    <a href="#" class="btn btn-primary btn-sm">
                                        <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                                        <label>Đặt ngay</label>
                                    </a>
                                </div>
                                <div class="col-6">
                                    <div class="btn ">
                                        <label for="">Ngày khác</label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-text">{{ product.date }}</div>
                        </div>

                        <p class="card-text hidden-sm text-muted">{{ product.desc }}</p>

                        <div class="product-item__review mt-5">
                            <span class="product-item__review--point">{{ product.point }}</span>
                            <span class="product-item__review--feedback">{{ product.feedback }}</span>
                        </div>

                        <div class="product-item__location d-none d-lg-block mt-5">
                            <i class="fa fa-location-dot"></i>
                            <span>{{ product.location }}</span>
                        </div>
                    </div>

                    <div class="col-12 col-lg-3 product-item__summary">
                        <div class="product-item__price d-none d-lg-block">
                            <div class="card-text mb-2">Giá chỉ từ</div>
                            <div class="card-price">
                                <div class="card-price__current mb-3">
                                    <span class="card-price__current--number">{{ formatter.format(product.price)
                                        }}</span>
                                    <span class="card-price__current--text">/khách</span>
                                </div>
                            </div>
                            <p class="card-date">{{ product.date }}</p>
                            <div class="row mb-3 product-item__btn">
                                <div class="col-12">
                                    <button class="btn">Ngày khác</button>
                                </div>
                                <div class="col-12">
                                    <a href="!#" class="btn btn-primary btn-sm">
                                        Đặt ngay
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="TourProduct__btn text-end">
            <a href="#">
                <button>Xem tất cả <i class="fa-sharp fa-solid fa-arrow-right-long ms-2"></i>
                </button>
            </a>
        </div>
    </div>
    <!-- ========== End Tour Product ========== -->

    <!-- ========== Start Tour Place ========== -->
    <div class="TourPlace">
        <div class="container-fluid">
            <div class="TourPlace__title">
                <h1>Điểm đến yêu thích</h1>
            </div>
            <div class="TourPlace__content row row-cols-lg-4 row-cols-md-2 row-cols-1">
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/hanoi.jpg" class="card-img-top"
                                    alt="Hà Nội"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/haiphong.jpg" class="card-img-top"
                                    alt="Haỉ Phòng"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/danang.jpg" class="card-img-top"
                                    alt="Đà Nẵng"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/dalat.jpg" class="card-img-top"
                                    alt="Đà Lạt"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/chaua.jpg" class="card-img-top"
                                    alt="Châu Á"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/chaumy.jpg" class="card-img-top"
                                    alt="Châu Mỹ"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/chauau.jpg" class="card-img-top"
                                    alt="Châu Âu"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col card border border-0">
                    <div class="card-body">
                        <div class="TourPlace__content-img">
                            <a href=""><img src="@/../public/images/place/bi.jpg" class="card-img-top" alt="Bỉ"></a>
                            <a href=""><i class="fa-sharp fa-solid fa-tower-observation fa-3x"></i></a>
                        </div>
                        <div class="div">
                            <div class="TourPlace__content-place">
                                <a href="">Hà Nội</a>
                            </div>
                            <div class="TourPlace__content-desc">
                                <p>Đã có <span>176.072</span> lượt khách </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ========== End Tour Place ========== -->

    <!-- ========== Start Tour .... ========== -->
    <div class="TourSelect">
        <div class="container-fluid">
            <div class="TourSelect__title">
                <h2>Vì sao chọn Vietravel</h2>
            </div>
            <div class="TourSelect_content row row-cols-lg-3 row-cols-md-2 row-cols-1">
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Mạng bán tour</h5>
                    <p class="TourSelect_content-text">Đầu tiên tại Viêt Nam</p>
                    <p class="TourSelect_content-text">Ứng dụng công nghệ mới nhất</p>
                </div>
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Sản phẩm & Dịch vụ</h5>
                    <p class="TourSelect_content-text">Đa dạng – Chất lượng – An toàn</p>
                </div>
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Giá cả</h5>
                    <p class="TourSelect_content-text">Luôn có mức giá tốt nhất</p>
                </div>
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Đặt tour</h5>
                    <p class="TourSelect_content-text">Dễ dàng & nhanh chóng chỉ với 3 bước</p>
                </div>
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Thanh toán</h5>
                    <p class="TourSelect_content-text">An toàn & linh hoạt</p>
                </div>
                <div class="col p-5">
                    <i class="fa-solid fa-house fa-4x"></i>
                    <h5 class="TourSelect_content-title">Hỗ trợ</h5>
                    <p class="TourSelect_content-text">Hotline & trực tuyến (08h00 - 22h00)</p>
                </div>

            </div>
        </div>
    </div>

    <!-- ========== End Tour .... ========== -->
</template>
<script>
    // import cardData from "@/data/cardData.js";
    import productData from "@/data/productData.js";
    export default {
        data() {
            return {
                cards: [],
                products: productData,
                formatter: new Intl.NumberFormat("vi-VN", {
                    style: "currency",
                    currency: "VND",
                }),
            };
        },

        mounted() {
            // eslint-disable-next-line no-undef
            $(document).ready(function () {
                // eslint-disable-next-line no-undef
                $(".owl-carousel").owlCarousel({
                    center: true,
                    loop: true,
                    margin: 20,
                    responsive: {
                        0: {
                            items: 2,
                        },
                        600: {
                            items: 2,
                        },
                        1000: {
                            items: 3,
                        },
                    },
                    autoplay: true,
                    autoplayTimeout: 4000,
                    autoplayHoverPause: true,
                });
            });
            this.getAllProduct();
        },
        methods: {
            getAllProduct() {
                // eslint-disable-next-line
                axios.get('api/Tour')
                    .then((response) => {
                        // handle success
                        this.cards = response.data;
                    })
                    .catch((error) => {
                        // handle error
                        console.log(error);
                    });
            },
        }
    };
</script>

<style lang="scss">
    @import "@/assets/scss/_tourMain.scss";
    @import "@/assets/scss/_tourProduct.scss";
    @import "@/assets/scss/_carousel.scss";
    @import "@/assets/scss/_card.scss";

    /* Start Tourkp */
    .tourkp {
        padding: 0 10px;
        margin-bottom: 2rem;
        cursor: pointer;
        border-radius: 10px;
    }

    .tourkp h2 {
        font: 30px roboto, sans-serif;
        font-weight: 700;
        color: #2d4271;
        margin-bottom: 24px;
    }

    .tourkp__card {
        position: relative;
        padding-right: 0;
        margin-bottom: 3rem;
    }

    .tourkp__img {
        width: 100%;
    }

    .tourkp__img img {
        height: 28rem;
        object-fit: cover;
        border-radius: 10px;
        width: 100%;
    }

    .tourkp__text a {
        position: absolute;
        bottom: 0rem;
        color: #fff;
        padding: 4rem 2rem;
        font-size: 1.8rem;
        font-weight: bold;
        text-decoration: none;
        border-radius: 10px;
        background-image: linear-gradient(180deg,
                rgba(45, 66, 113, 0) 0%,
                #2d4271 100%);
        width: 97%;
    }

    /* End Tourkp */


    /* Start Tour Place */
    .TourPlace {
        padding: 0 10px;
    }

    .TourPlace__title h1 {
        font: 30px roboto, sans-serif;
        font-weight: 700;
        color: #2d4271;
        margin-bottom: 24px;
    }

    .TourPlace__content .div {
        padding: 16px;
    }

    .TourPlace__content-img img {
        filter: brightness(0.75);
        min-height: 18em;
        object-fit: cover;
        border-radius: 10px;
        position: relative;
    }

    .TourPlace__content-img i {
        position: absolute;
        left: 50%;
        top: 40%;
        transform: translate(-50%, -40%);
        color: #ffff;
    }

    .TourPlace__content-place a {
        font: 17px roboto, sans-serif;
        color: #2d4271;
        font-weight: 700;
        line-height: 1.2em;
    }

    .TourPlace__content-desc p {
        font: 13px roboto, sans-serif;
        color: #2d4271;
    }

    /* End Tour Place */

    /*  Start: Tour Select */
    .TourSelect {
        padding: 0 10px;
    }

    .TourSelect__title h2 {
        font: 30px roboto, sans-serif;
        font-weight: 700;
        color: #2d4271;
        margin-bottom: 24px;
    }

    .TourSelect_content {
        text-align: center;
    }

    .TourSelect_content-title {
        font: 17px roboto, sans-serif;
        color: #2d4271;
        font-weight: 700;
        line-height: 24px;
        margin-bottom: 16px;
    }

    .TourSelect_content i {
        background: linear-gradient(180deg, #4d4aef, #adabff);
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        margin-bottom: 16px;
    }

    .TourSelect_content-text {
        font: 15px roboto, sans-serif;
        color: #2d4271;
        font-weight: 400;
        line-height: 24px;
    }

    /*  End: Tour Select */

</style>
