<template>
  <div class="TourSearch">
    <div class="container-fluid">
      <div class="row">
        <div class="TourSearch__left col-12 col-md-6 col-lg-3">
          <div class="container-fluid">
            <h2 class="TourSearch__title">Lọc kết quả</h2>

            <div class="TourSearch__left--select">
              <h5 class="l-title">Loại hình tour</h5>
              <select class="form-control" name="" id="">
                <option selected value="0">--- Tất cả ---</option>
                <option value="1">Tour trọn gói</option>
                <option value="2">Tour gia đình</option>
              </select>
              <h5 class="l-title">Điểm đi</h5>
              <select class="form-control" name="" id="">
                <option selected value="0">--- Tất cả ---</option>
                <option value="1">Bình Dương</option>
                <option value="2">TP. Hồ Chí Minh</option>
                <option value="3">Hà Nội</option>
                <option value="3">Vũng Tàu</option>
              </select>
              <h5 class="l-title">Điểm đến</h5>
              <select class="form-control" name="" id="">
                <option selected value="0">--- Tất cả ---</option>
                <option value="1">Bình Dương</option>
                <option value="2">TP. Hồ Chí Minh</option>
                <option value="3">Hà Nội</option>
                <option value="3">Vũng Tàu</option>
              </select>
            </div>

            <div class="TourSearch__left--day">
              <h5 class="l-title">Số ngày</h5>
              <div class="TourSearch__btn">
                <div class="row g-2">
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNgay1_3"
                      value="1-3"
                      class="btn w-100"
                      checked
                    >
                      1-3 ngày
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNgay4_7"
                      value="4-7"
                      class="btn w-100"
                    >
                      4-7 ngày
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNgay8_14"
                      value="8-14"
                      class="btn w-100"
                    >
                      8-14 ngày
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNgay14"
                      value="15-31"
                      class="btn w-100"
                    >
                      Trên 14 ngày
                    </button>
                  </div>
                </div>
              </div>
            </div>

            <div class="TourSearch__left--departure">
              <h5 class="l-title">Ngày đi</h5>
              <input
                type="date"
                class="form-control"
                id=""
                name="tourCheckoutDays"
                autocomplete="off"
                
              />
            </div>

            <div class="TourSearch__left--member">
              <h5 class="l-title">Số người</h5>
              <div class="TourSearch__btn">
                <div class="row g-2">
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNguoi1"
                      value="1"
                      class="btn w-100"
                      checked
                    >
                      1 người
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNguoi2"
                      value="2"
                      class="btn w-100"
                    >
                      2 người
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNguoi3-5"
                      value="3-5"
                      class="btn w-100"
                    >
                      3-5 người
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="SoNguoi5"
                      value="5"
                      class="btn w-100"
                    >
                      5+ người
                    </button>
                  </div>
                </div>
              </div>
            </div>

            <div class="TourSearch__left--tour">
              <h5 class="l-title">Dòng tour</h5>
              <div class="TourSearch__btn">
                <div class="row g-2">
                  <div class="col-6">
                    <button
                      type="button"
                      id="DongTour1"
                      value="1"
                      class="btn w-100"
                      checked
                    >
                      Cao cấp
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="DongTour2"
                      value="2"
                      class="btn w-100"
                    >
                      Tiêu chuẩn
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="DongTour3"
                      value="3"
                      class="btn w-100"
                    >
                      Tiết kiệm
                    </button>
                  </div>
                  <div class="col-6">
                    <button
                      type="button"
                      id="DongTour4"
                      value="4"
                      class="btn w-100"
                    >
                      Giá tốt
                    </button>
                  </div>
                </div>
              </div>

              <div class="TourSearch_viewer">
                <h5 class="l-title">Hiện thị những chuyến đi có</h5>
                <div class="mb-3">
                  <label class="toggle" for="toggle">
                    <input type="checkbox" id="toggle" />
                    <div class="slider"></div>
                    <span class="label-text">Khuyến mãi</span>
                  </label>
                </div>
                <div class="mb-3">
                  <label class="toggle" for="toggle1">
                    <input type="checkbox" id="toggle1" />
                    <div class="slider"></div>
                    <span class="label-text">Còn chỗ</span>
                  </label>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!----------------------------------------------->
        <div class="TourCard tours_card col-12 col-md-6 col-lg-9">
          <div class="TourCard__content row row-cols-lg-3 row-cols-1 p-2">
            <div
              class="my-5 text-danger text-center"
              v-if="this.products.length <= 0"
            >
              <h2 class="fst-italic">Không tìm thấy sản phẩm nào phù hợp</h2>
            </div>
            <div
              class="col mb-5"
              v-for="product in displayedCarts"
              :key="product.tourID"
            >
              <div class="card">
                <div class="img">
                  <router-link
                    :to="{ name: 'details-id', params: { id: product.tourID } }"
                  >
                    <img
                      :src="
                        require(`@/../public/images/card/${product.tourImage}`)
                      "
                      class="card-img-top"
                      width="100%"
                      :alt="product.tourName"
                    />
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
                      <span>{{ product.tourType }}</span>
                    </div>
                    <div class="img-sumary--review">
                      <h3 class="fw-bold">Tuyệt vời</h3>
                      <p class="fw-lighter">358 quan tâm</p>
                    </div>
                  </div>
                </div>

                <div class="body card-body">
                  <p class="p-date">{{ product.date }}</p>
                  <p class="p-title">
                    <router-link
                      :to="{
                        name: 'details-id',
                        params: { id: product.tourID },
                      }"
                    >
                      {{ product.tourName }}
                    </router-link>
                  </p>
                  <div class="code">
                    <p>Mã tour:</p>
                    <p>
                      <i class="fa-solid fa-ticket"></i> {{ product.tourCode }}
                    </p>
                  </div>
                  <p class="p-startPlace">
                    Nơi khởi hành:
                    <span class="fw-bold">{{ product.departure }}</span>
                  </p>
                  <p class="p-startPlace">
                    Nơi đến: <span class="fw-bold">{{ product.destination }}</span>
                  </p>
                  <div class="price">
                    <p class="price-old">
                      Giá:
                      <span
                        class="text-decoration-line-through"
                        v-if="product.price != product.promotionPrice"
                        >{{ formatter.format(product.price) }}</span
                      >
                    </p>
                    <div class="price-now">
                      <span class="price-now-number">{{
                        formatter.format(product.promotionPrice)
                      }}</span>
                      <span
                        class="price-now-discount"
                        v-if="product.discountTour != 0"
                        >{{ product.discountTour }} GIẢM</span
                      >
                    </div>
                  </div>
                  <div class="timer">
                    <span>{{ product.tourCheckinDays }}</span>
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
                        {{ product.tourAvailableSit }}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <Nagination
              v-if="this.products.length > this.perPage"
              :current-page="currentPage"
              :total-pages="totalPages"
              @page-change="changePage"
            />
          </div>

          <!-------------------------------->
          <div class="TourSearch__right">
            <div class="TourSearch__right--search">
              <h2 class="TourSearch__title">Các tour đang tìm phổ biến</h2>
              <a href="#" class="btn-search">
                <i class="fa fa-search" aria-hidden="true"></i>
                <span>Đà lạt</span>
              </a>
              <a href="#" class="btn-search">
                <i class="fa fa-search" aria-hidden="true"></i>
                <span>Hạ long</span>
              </a>
              <a href="#" class="btn-search">
                <i class="fa fa-search" aria-hidden="true"></i>
                <span>Phan Thiết</span>
              </a>
              <a href="#" class="btn-search">
                <i class="fa fa-search" aria-hidden="true"></i>
                <span>Du lịch đà nẵng</span>
              </a>
            </div>

            <div class="TourSearch__right--location">
              <h2 class="TourSearch__title">Các điểm ưa chuộng</h2>
              <div class="row">
                <div class="col-12 col-lg-3">
                  <div class="card TourSearch__right--card">
                    <a href="#">
                      <img
                        src="@/../public/images/diadanh/haiphong.jpg"
                        alt="Hải phòng"
                      />
                      <p>Hải phòng</p>
                    </a>
                  </div>
                </div>
                <div class="col-12 col-lg-3">
                  <div class="card TourSearch__right--card">
                    <a href="#">
                      <img
                        src="@/../public/images/diadanh/halong.jpg"
                        alt="Hạ Long"
                      />
                      <p>Hạ Long</p>
                    </a>
                  </div>
                </div>
                <div class="col-12 col-lg-3">
                  <div class="card TourSearch__right--card">
                    <a href="#">
                      <img
                        src="@/../public/images/diadanh/danang.jpg"
                        alt="Đà Nẵng"
                      />
                      <p>Đà Nẵng</p>
                    </a>
                  </div>
                </div>
                <div class="col-12 col-lg-3">
                  <div class="card TourSearch__right--card">
                    <a href="#">
                      <img
                        src="@/../public/images/diadanh/dalat.jpg"
                        alt="Đà Lạt"
                      />
                      <p>Đà Lạt</p>
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Nagination from "@/components/ThePagination.vue";

export default {
  name: "TourSearch",
  components: {
    Nagination,
  },
  data() {
    return {
      products: [],
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
      currentPage: 1,
      perPage: 6,
    };
  },
  mounted() {
    this.SearchByDeparture(
      this.$route.params.departure,
      this.$route.params.destination
    );
  },
  methods: {
    SearchByDeparture(departure, destination) {
      if (departure != 0 && destination != 0) {
        // eslint-disable-next-line
        axios
          .get(`/api/Search?departure=${departure}&destination=${destination}`)
          .then((response) => {
            // handle success
            this.products = response.data;
            // console.log(this.products);
          })
          .catch((error) => {
            // handle error
            console.log(error);
          });
      } else if (departure != 0) {
        // eslint-disable-next-line
        axios.get(`/api/Search?departure=${departure}`).then((response) => {
          // handle success
          this.products = response.data;
          // console.log(this.products);
        });
      } else if (destination != 0) {
        // eslint-disable-next-line
        axios.get(`/api/Search?destination=${destination}`).then((response) => {
          // handle success
          this.products = response.data;
          // console.log(this.products);
        });
      } else {
        // eslint-disable-next-line
        axios.get(`/api/Search`).then((response) => {
          // handle success
          this.products = response.data;
          // console.log(this.products);
        });
      }
    },
    changePage(page) {
      this.currentPage = page;
    },
  },
  computed: {
    totalPages() {
      return Math.ceil(this.products.length / this.perPage);
    },
    displayedCarts() {
      const start = (this.currentPage - 1) * this.perPage;
      const end = start + this.perPage;
      return this.products.slice(start, end);
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_card.scss";
@import "@/assets/scss/_search.scss";
</style>
