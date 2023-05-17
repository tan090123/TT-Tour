<template>
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
</template>

<script>
import "@/scss/_tourProduct.scss";
import data from '../../data/productData.js';
export default {
    name: "TourProduct-page",
    data() {
        return {
            products: data,
            formatter: new Intl.NumberFormat('vi-VN', {
                style: 'currency',
                currency: 'VND'
            })
        };
    }
}
</script>