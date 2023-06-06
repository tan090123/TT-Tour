<template>
    <div class="TourCard tours_card">
        <h2 class="TourCard__title text-center p-5">Danh sách các địa điểm Tour</h2>
        <p class="TourCard__desc">
            Du lịch giờ chót của Vietravel luôn đem đến cho Quý khách những niềm bất ngờ thú vị. Đó là những đường tour cuốn
            hút với mức giá đầy hấp dẫn, khuyến mại vào thời điểm cận ngày khởi hành. Với những giảm giá rất ưu đãi phối hợp
            với hệ thống đối tác lớn mạnh, Vietravel cho Quý khách cơ hội được tận hưởng những dịch vụ chất lượng vàng không
            đổi từ công ty lữ hành uy tín nhất Việt Nam.
        </p>
        <div class="TourCard__content row row-cols-lg-3 row-cols-1 p-2">
            <div class="col mb-5" v-for="(card, index) in cards" :key="index">
                <div class="card">
                    <div class="img">
                        <a href="">
                            <img :src="require(`@/../public/images/card/${card.tourImage}`)" class="card-img-top"
                                width="100%" :alt="card.tourName">
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
                                <span>{{ card.tourType }}</span>
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
                                Giá: <span class="text-decoration-line-through">{{ formatter.format(card.price)
                                }}</span>
                            </p>
                            <div class="price-now">
                                <span class="price-now-number">{{ formatter.format(card.promotionPrice) }}</span>
                                <span class="price-now-discount">{{ card.discountTour }} GIẢM</span>
                            </div>
                        </div>
                        <div class="timer">
                            <span>{{ card.tourCheckinDays }}</span>
                        </div>
                        <div class="addList-numberSit">
                            <div class="addList">
                                <i class="fa-solid fa-circle-plus me-2"></i>
                                <a href="">Thêm vào danh sách</a>
                            </div>
                            <div class="numberSit d-flex align-items-center justify-content-center">
                                <p class="text-decoration-underline me-2">Số chỗ còn</p>
                                <p class="text-danger fw-bold" style="font-size: 22px;">{{ card.tourTotalSit }}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <nav aria-label="pagination">
            <ul class="pagination">
                <li>
                    <a href="" @click.prevent="previousPage" :disabled="currentPage === 1">
                        <span aria-hidden="true">«</span><span class="visuallyhidden">previous</span>
                    </a>
                </li>

                <li v-for="(card, index) in currentPageData" :key="card.index">
                    <a href="">
                        <span class="visuallyhidden">page </span>{{ index + 1 }}
                    </a>
                </li>

                <li>
                    <a href="" @click.prevent="nextPage" :disabled="currentPage === totalPages">
                        <span class="visuallyhidden">next</span><span aria-hidden="true">»</span>
                    </a>
                </li>
            </ul>
        </nav>


    </div>
</template>
<script>
// import cardData from "@/data/cardData.js";
export default {
    data() {
        return {
            // cards: cardData,
            cards: [],
            formatter: new Intl.NumberFormat("vi-VN", {
                style: "currency",
                currency: "VND",
            }),
            currentPage: 1,
            pageSize: 4,
        };
    },
    created() {
        // eslint-disable-next-line
        axios.get('/api/Tour')
            .then((response) => {
                // handle success
                this.cards = response.data;
            })
            .catch((error) => {
                // handle error
                console.log(error);
            });
    },
    computed: {
        totalPages() {
            return Math.ceil(this.cards.length / this.pageSize);
        },
        currentPageData() {
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
            return this.cards.slice(startIndex, endIndex);
        },
    },
    methods: {
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        },
    }
}
</script>
<style lang="scss">
@import "@/assets/scss/_card.scss";

.tours_card {
    margin-top: 6.7rem;
    padding: 0 10px;
}

.TourCard__desc {
    color: #2d4271;
    padding: 0 10px;
    font-size: 1.5rem;
    font-weight: 500;
}
</style>