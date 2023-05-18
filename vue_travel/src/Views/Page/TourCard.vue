<template>
    <div class="TourCard" onload="startCountdown()">
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
</template>

<script>
import cardData from '../../data/cardData.js';
// import { differenceInSeconds } from '@/../node_modules/date-fns';
export default {
    name: "TourCard-comp",
    data() {
        return {
            cards: cardData,
            formatter: new Intl.NumberFormat('vi-VN', {
                style: 'currency',
                currency: 'VND'
            }),
        };
    },
}
</script>

<style>
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
</style>