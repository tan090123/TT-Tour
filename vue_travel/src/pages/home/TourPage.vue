<template>
  <div class="TourCard tours_card">
    <h2 class="TourCard__title text-center p-5">Danh sách các địa điểm Tour</h2>
    <p class="TourCard__desc">
      Du lịch giờ chót của Vietravel luôn đem đến cho Quý khách những niềm bất
      ngờ thú vị. Đó là những đường tour cuốn hút với mức giá đầy hấp dẫn,
      khuyến mại vào thời điểm cận ngày khởi hành. Với những giảm giá rất ưu đãi
      phối hợp với hệ thống đối tác lớn mạnh, Vietravel cho Quý khách cơ hội
      được tận hưởng những dịch vụ chất lượng vàng không đổi từ công ty lữ hành
      uy tín nhất Việt Nam.
    </p>
    <div class="TourCard__content row row-cols-lg-3 row-cols-1 p-2">
      <div class="col mb-5" v-for="card in displayedCarts" :key="card.tourID">
        <div class="card">
          <div class="img">
            <div style="cursor: pointer"
            >
              <img
                :src="card.tourImage"
                class="card-img-top"
                width="100%"
                :alt="card.tourName"
                @click="routeDetails(card.tourID)"
              />
          </div>
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
                <h3 class="fw-bold">Tuyệt vời</h3>
                <p class="fw-lighter">358 quan tâm</p>
              </div>
            </div>
          </div>

          <div class="body card-body">
            <p class="p-date">{{ card.tourCheckinDays }}</p>

            <p class="p-title fw-bold fs-3" @click="routeDetails(card.tourID)" style="cursor: pointer;">
             
                {{ card.tourName }}
              
            </p>
            <div class="code">
              <p>Mã tour:</p>
              <p><i class="fa-solid fa-ticket"></i> {{ card.tourCode }}</p>
            </div>
            <p class="p-startPlace">
              Nơi khởi hành: <span class="fw-bold">{{ card.departure }}</span>
            </p>
            <p class="p-startPlace">
              Nơi đến: <span class="fw-bold">{{ card.destination }}</span>
            </p>
            <div class="price">
              <p class="price-old">
                Giá:
                <span
                  class="text-decoration-line-through"
                  v-if="card.price != card.promotionPrice"
                  >{{ formatter.format(card.price) }}</span
                >
              </p>
              <div class="price-now">
                <span class="price-now-number">{{
                  formatter.format(card.promotionPrice)
                }}</span>
                <span class="price-now-discount" v-if="card.discountTour != null"
                  >{{ card.discountTour }} GIẢM</span
                >
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
              <div
                class="numberSit d-flex align-items-center justify-content-center"
              >
                <p class="text-decoration-underline me-2">Số chỗ còn</p>
                <p class="text-danger fw-bold" style="font-size: 22px">
                  {{ card.tourAvailableSit }}
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <Nagination
      :current-page="currentPage"
      :total-pages="totalPages"
      @page-change="changePage"
    />
  </div>
</template>
<script>
import { mapState,mapActions } from "vuex";

// import cardData from "@/data/cardData.js";
import Nagination from "@/components/ThePagination.vue";

export default {
  name: "TourPage",
  components: {
    Nagination,
  },
  data() {
    return {
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
      currentPage: 1,
      perPage: 6,
    };
  },
  created() {
    this.fetchTours();
  },
  computed: {
    ...mapState(["tourlist"]),
    totalPages() {
      return Math.ceil(this.tourlist.tours.length / this.perPage);
    },
    displayedCarts() {
      const start = (this.currentPage - 1) * this.perPage;
      const end = start + this.perPage;
      return this.tourlist.tours.slice(start, end);
    },
  },
  methods: {
    ...mapActions(["fetchTours","fetchTourDetails"]),
    changePage(page) {
      this.currentPage = page;
    },
    routeDetails(index) {
      this.fetchTourDetails({ id: index })
        .then(() => {
          this.$router.push({
            name: "details-id",
            params: { id: index },
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_card.scss";

.TourCard {
  margin: 5rem 0;
}

.tours_card {
  margin-top: 6.7rem;
  padding: 0 10px;
}
.p-title:hover{
  color:red;
}

.TourCard__desc {
  color: #2d4271;
  padding: 0 10px;
  font-size: 1.5rem;
  font-weight: 500;
}
</style>
