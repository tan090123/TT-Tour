<template lang="">
    <!-- ========== Start TourMain ========== -->
    <div class="tourMain">
    <div class="tourMain__img">
      <img src="../../assets/banner/banner.jpg" class="w-100" alt="" />
    </div>
    <div class="tourMain__both container shadow">

      <div class="tourMain__both-nav">

        <ul class="nav nav-tabs" id="myTab" role="tablist">
          <li class="nav-item" role="presentation">
            <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button"
              role="tab" aria-controls="home" aria-selected="true">
              <i class="fa-solid fa-bus mb-2 fs-3"></i>
              <p>Tour du lịch <br>trọn gói </p>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button"
              role="tab" aria-controls="profile" aria-selected="false">
              <i class="fa-solid fa-hotel mb-2 fs-3"></i>
              <p>Khách sạn</p>
              <small class="badge btn-danger">Ưu đãi hot</small>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="messages-tab" data-bs-toggle="tab" data-bs-target="#messages" type="button"
              role="tab" aria-controls="messages" aria-selected="false">
              <i class="fa-solid fa-jet-fighter-up mb-2 fs-3"></i>
              <p>Vé máy bay</p>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="settings-tab" data-bs-toggle="tab" data-bs-target="#settings" type="button"
              role="tab" aria-controls="settings" aria-selected="false">
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
            <button class="nav-link" id="carAndres-tab" data-bs-toggle="tab" data-bs-target="#carAndres" type="button"
              role="tab" aria-controls="carAndres" aria-selected="false">
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
            <button class="nav-link" id="search-tab" data-bs-toggle="tab" data-bs-target="#search" type="button"
              role="tab" aria-controls="search" aria-selected="false">
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
                      data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home"
                      aria-selected="true">
                      Du lịch trong nước
                    </button>
                  </li>
                  <li class="nav-item" role="presentation">
                    <button class="nav-link dlnn" id="pills-profile-tab" data-bs-toggle="pill"
                      data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile"
                      aria-selected="false">
                      Du lịch nước
                      ngoài
                    </button>
                  </li>
                </ul>
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
                    <img src="../../assets/owl_carousel/bn_230403_TourHongKong_1024-768px.png" alt="Hong Kong">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn_230403_HANQUOC-DAINHACHOI_1024-768px.png" alt="Dai hoi han quoc">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn__230511_.png" alt="Dai hoi han quoc 4 ngay 3 dem">
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../../assets/owl_carousel/bn__230510_.png" alt="Trai nghiem mua he nuoc uc">
                </a>
            </div>
        </div>
    </div>
    </div>
    <!-- ========== End Tour Carousel ========== -->

    <!-- ========== Start Tour Khám Phá ========== -->
    
    <!-- ========== End Tour Khám Phá ========== -->

    <!-- ========== Start Tour Card ========== -->
    <div class="TourCard">
        <div class="container-fluid">
            <h1 class="TourCard__title">Ưu đãi tour giờ chót</h1>
            <div class="TourCard__content row row-cols-lg-3 row-cols-1">
                <div class="col mt-sm-auto" v-for="(card, index) in cards.slice(0, 3)" :key="index">
                    <div class="card">
                        <div class="img">
                            <a href="">
                                <img :src="require(`@/assets/card/${card.images}`)" class="card-img-top" width="100%"
                                    :alt="card.name">
                            </a>
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
                                    <span>{{ card.point }}</span>
                                </div>
                                <div class="img-sumary--review">
                                    <h3 class="fw-bold">{{ feedback }}</h3>
                                    <p class="fw-lighter">358 quan tâm</p>
                                </div>
                            </div>
                        </div>

                        <div class="body card-body">
                            <p class="p-date">{{ card.date }}</p>
                            <p class="p-title">
                                <a href="">
                                    {{ card.name }}
                                </a>
                            </p>
                            <div class="code">
                                <p>Mã tour:</p>
                                <p><i class="fa-solid fa-ticket"></i>
                                    {{ card.code_tour }}</p>
                            </div>
                            <p class="p-startPlace">Nơi khởi hành: {{ card.starting_gate }}</p>
                            <div class="price">
                                <p class="price-old">
                                    Giá: <span class="text-decoration-line-through">{{ formatter.format(card.price)
                                    }}</span>
                                </p>
                                <div class="price-now">
                                    <span class="price-now-number">{{ formatter.format(card.discount) }}</span>
                                    <span class="price-now-discount">{{ card.preferential }}% GIẢM</span>
                                </div>
                            </div>
                            <div class="timer">
                                <span>{{ card.date }}</span>
                            </div>
                            <div class="addList-numberSit">
                                <div class="addList">
                                    <i class="fa-solid fa-circle-plus me-2"></i>
                                    <a href="">Thêm vào danh sách</a>
                                </div>
                                <div class="numberSit d-flex align-items-center justify-content-center">
                                    <p class="text-decoration-underline me-2">Số chỗ còn</p>
                                    <p class="text-danger fw-bold" style="font-size: 22px;">{{ card.num_seats }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="TourCard__btn text-end">
                <a href=""><button>Xem tất cả <i class="fa-sharp fa-solid fa-arrow-right-long ms-2"></i></button></a>
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
                                <img :src="require(`@/assets/product/${product.images}`)"
                                    :alt="product.name">
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
                                        <span class="card-price__current--number">{{ formatter.format(product.price) }}</span>
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
                            <a href=""><img src="../../assets/place/hanoi.jpg" class="card-img-top" alt="Hà Nội"></a>
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
                            <a href=""><img src="../../assets/place/haiphong.jpg" class="card-img-top" alt="Haỉ Phòng"></a>
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
                            <a href=""><img src="../../assets/place/danang.jpg" class="card-img-top" alt="Đà Nẵng"></a>
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
                            <a href=""><img src="../../assets/place/dalat.jpg" class="card-img-top" alt="Đà Lạt"></a>
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
                            <a href=""><img src="../../assets/place/chaua.jpg" class="card-img-top" alt="Châu Á"></a>
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
                            <a href=""><img src="../../assets/place/chaumy.jpg" class="card-img-top" alt="Châu Mỹ"></a>
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
                            <a href=""><img src="../../assets/place/chauau.jpg" class="card-img-top" alt="Châu Âu"></a>
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
                            <a href=""><img src="../../assets/place/bi.jpg" class="card-img-top" alt="Bỉ"></a>
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
    
    <!-- ========== End Tour .... ========== -->
</template>
<script>
import "@/scss/_tourMain.scss";
import "@/scss/_tourProduct.scss";
import cardData from '@/data/cardData.js';
import productData from '@/data/productData.js';
export default {
    data() {
        return {
            cards: cardData,
            products: productData,
            formatter: new Intl.NumberFormat('vi-VN', {
                style: 'currency',
                currency: 'VND'
            }),
        }
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
                        items: 2
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 3
                    }
                },
                autoplay: true,
                autoplayTimeout: 4000,
                autoplayHoverPause: true
            });
        });
    },
}
</script>
<style>
/* Start Carousel */
.carousel {
    margin: 3rem 0;
}
.carousel-title {
    font-size: 3rem;
    color: #2d4271;
    font-weight: bold;
    margin-bottom: 2rem;
    padding:0 10px;
}
.owl-carousel {
    padding: 0 10px;
}

.owl-carousel .owl-item {
    border-radius: 10px;
    overflow: hidden;
}

.owl-carousel .owl-stage {
    transition: all 0.7s ease-in-out !important;
}
.owl-dots button span {
    background-color: rgb(0 100 182 / 25%) ;
}

.owl-theme .owl-dots .owl-dot.active span, .owl-theme .owl-dots .owl-dot:hover span {
    background-color: #2d4271 ;
}

@media screen and (max-width: 992px) {
    .owl-dots {
        display: none;
    }
}
/* End Carousel */


/* Start TourCard */
.TourCard {
    padding: 0 10px;
}

.TourCard .card {
    border-radius: 10px;
}

.TourCard .card:hover {
    box-shadow: 3px 3px 10px rgba(95, 95, 95, 0.5);
    transform: translateY(-1%);
}

.TourCard img {
    border-radius: 10px 10px 0px 0px;
    object-fit: cover;
    height: 300px;
    overflow: hidden;
}

.TourCard__title {
    font: 30px roboto, sans-serif;
    font-weight: 700;
    color: #2d4271;
    margin-bottom: 24px;
}

.img {
    position: relative;
}

.img-icon,
.img-bottom,
.img-sumary {
    position: absolute;
}

.img-icon {
    top: 1em;
    left: 1em;
    color: #fff;
    background-color: #5c5c5c48;
    padding: 5px;
    border-radius: 10px;
    cursor: pointer;
}

.img-bottom {
    font: 15px roboto, sans-serif;
    bottom: 0%;
    left: 0%;
    background: #fff;
    padding: 5px 10px;
    color: #4d4aef;
}

.img-sumary {
    top: 1em;
    right: 1em;
    text-align: end;
}

.img-sumary .img-sumary--ratting {
    background: #fdc432;
    display: inline;
    font-weight: 700;
    font-size: 16px;
    line-height: 20px;
    color: #fff;
    padding: 5px 10px;
    border-radius: 5px 5px 0px 5px;
    position: relative;
}

.img-sumary .img-sumary--ratting::before {
    content: "";
    display: block;
    width: 0;
    height: 0;
    border-left: 5px solid transparent;
    border-top: 5px solid #fdc432;
    position: absolute;
    top: 100%;
    right: 0px;
    z-index: 1;
}

.img-sumary--review {
    background-color: #5c5c5c48;
    color: #fff;
    padding: 5px;
    font-weight: 700;
    font-size: 15px;
    margin-top: 1rem;
    border-radius: 10px;
}

.img-sumary--review p {
    background-color: #6d6d6d63;
    padding: 3px;
}

.body {
    padding: 16px;
    font: 15px roboto, sans-serif;
}

.body .p-date {
    font-size: 13px;
    color: #2d4271;
}

.body .p-title a {
    font-size: 16px;
    color: #2d4271;
    font-weight: 700;
    line-height: 20px;
}

.body .p-title {
    white-space: initial;
    overflow: hidden;
    text-overflow: ellipsis;
    max-height: 6rem;
}

.body .code,
.body .p-startPlace,
.body .price-old {
    font-size: 15px;
    color: #2d4271;
}

.TourCard .price-now {
    display: flex;
    justify-content: space-between;
}

.body .price-now-number {
    font-size: 18px;
    color: #fd5056;
    font-weight: 700;
}

.body .price-now-discount {
    font-size: 11px;
    font-weight: 700;
    border-radius: 5px;
    color: white;
    background: #fd5056;
    padding: 10px 5px;
}

.body .timer {
    font-size: 11px;
    border: 1px solid #4d4aef;
    font-weight: 700;
    text-align: center;
    border-radius: 5px;
    padding: 8px 0;
    margin: 10px 0px 20px;
    color: #4d4aef;
}

.body .addList-numberSit {
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-size: 13px;
    font-weight: bold;
    margin: 10px 0px;
}

.body .addList a,
.body .addList i {
    color: #4d4aef;
}

.TourCard__btn button {
    font: 16px roboto, sans-serif;
    font-weight: 700;
    border: 1px solid #ced4de;
    background: none;
    color: #2d4271;
    border-radius: 5px;
    cursor: pointer;
    padding: 8px 24px;
    margin: 24px 0px 0px 0px;
}

.TourCard__btn button:hover {
    border: 1px solid #2d4271;
    transition: border 0.5s ease;

}
/* End TourCard */

/* Start Tour Place */
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
    transform: translate(-50%,-40%);
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
</style>