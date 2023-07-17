<template>
  <div class="TourSearch">
    <div class="container-fluid">
      <div class="row">
        <div class="TourSearch__left col-12 col-md-6 col-lg-3">
          <div class="container-fluid">
            <h2 class="TourSearch__title">Lọc kết quả</h2>

            <div class="TourSearch__left--select">
              <h5 class="l-title">Loại hình tour</h5>
              <select
                class="form-control"
                v-model="SelectedTourType"
                v-on:change="GetChangeByTourType(this.SelectedTourType)"
              >
                <option
                  :value="type.id"
                  v-for="type in TourType"
                  :key="type.id"
                >
                  {{ type.name }}
                </option>
              </select>
              <h5 class="l-title">Điểm đi</h5>
              <select
                class="form-control"
                v-model="SelectedDeparture"
                v-on:change="GetChangeByDeparture(this.SelectedDeparture)"
              >
                <option
                  :value="depart.id"
                  v-for="depart in Departure"
                  :key="depart.id"
                >
                  {{ depart.name }}
                </option>
              </select>
              <h5 class="l-title">Điểm đến</h5>
              <select
                class="form-control"
                v-model="SelectedDestination"
                v-on:change="GetChangeByDestination(this.SelectedDestination)"
              >
                <option
                  :value="des.id"
                  v-for="des in Destination"
                  :key="des.id"
                >
                  {{ des.name }}
                </option>
              </select>
            </div>

            <div class="TourSearch__left--day">
              <h5 class="l-title">Số ngày</h5>
              <div class="TourSearch__btn">
                <div class="row g-2">
                  <div
                    class="col-6"
                    v-for="button in SelectedNumberDays"
                    :key="button.id"
                  >
                    <button
                      type="button"
                      class="btn w-100"
                      :class="{ active: activeButton1 === button.id }"
                      @click="GetChangeByNumberDay(button.id)"
                    >
                      {{ button.name }}
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
                v-model="SelectedTime"
                :min="minDate"
                v-on:change="GetChangeByDateTime(this.SelectedTime)"
              />
            </div>

            <div class="TourSearch__left--member">
              <h5 class="l-title">Số người</h5>
              <div class="TourSearch__btn">
                <div class="row g-2">
                  <div
                    class="col-6"
                    v-for="button in SelectedPeople"
                    :key="button.id"
                  >
                    <button
                      type="button"
                      class="btn w-100"
                      :value="button.id"
                      :class="{ active: activeButton2 === button.id }"
                      @click="GetChangeByPeople(button.id)"
                    >
                      {{ button.name }}
                    </button>
                  </div>
                </div>
              </div>
            </div>

            
          </div>
        </div>

        <!----------------------------------------------->
        <div class="TourCard tours_card col-12 col-md-6 col-lg-9">
          <div class="d-flex justify-content-between my-4 px-3">
            <div class="text-center">
              <h2
                class="fst-italic text-danger"
                v-if="this.products.length <= 0"
              >
                Không tìm thấy sản phẩm nào phù hợp
              </h2>
              <h2 class="fw-lighter" v-else>
                Chúng tôi tìm thấy
                <span class="fw-bold fst-italic text-danger">{{
                  this.products.length
                }}</span>
                Tours cho quý khách
              </h2>
            </div>
            <div
              class="w-25 d-flex justify-content-center align-items-center"
              v-if="this.products.length > 0"
            >
              <h2 class="w-75 fw-lighter">Sắp xếp theo:</h2>
              <select
                class="form-control fs-3"
                v-model="SelectedOrderBy"
                v-on:change="GetChangeByOrderBy(this.SelectedOrderBy)"
              >
                <option value="-1">--- Chọn ---</option>
                <option value="0">Theo giá thấp -&gt; cao</option>
                <option value="1">Theo giá cao -&gt; thấp</option>
                <option value="2">Giảm giá nhiều nhất</option>
              </select>
            </div>
          </div>

          <div class="TourCard__content row row-cols-lg-3 row-cols-1 p-2">
            <div
              class="col mb-5"
              v-for="product in displayedCarts"
              :key="product.tourID"
            >
              <div class="card">
                <div class="img" style="cursor: pointer">
                  <img
                    :src="product.tourImage"
                    class="card-img-top"
                    width="100%"
                    :alt="product.tourName"
                    @click="routeDetails(product.tourID)"
                  />
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
                  <p class="p-date">
                    {{ product.tourCheckinDays.slice(0, 10) }} -
                    {{ product.tour_NumberDays }} Ngày -
                    {{ product.tour_AvalablePeople }} Người
                  </p>
                  <p
                    class="p-title fw-bolder fs-3"
                    @click="routeDetails(product.tourID)"
                    style="cursor: pointer"
                  >
                    {{ product.tourName }}
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
                    Nơi đến:
                    <span class="fw-bold">{{ product.destination }}</span>
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
          </div>
          <Nagination
            v-if="this.products.length > this.perPage"
            :current-page="currentPage"
            :total-pages="totalPages"
            @page-change="changePage"
          />

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
import { mapActions } from "vuex";
import Nagination from "@/components/ThePagination.vue";

export default {
  name: "TourSearch",
  components: {
    Nagination,
  },
  data() {
    return {
      products: [],
      SelectedDeparture: this.$route.params.departure,
      Departure: [
        { id: "All", name: "---Tất cả---" },
        { id: "TP. Hồ Chí Minh", name: "TP. Hồ Chí Minh" },
        { id: "Hà Nội", name: "Hà Nội" },
        { id: "Đà Nẵng", name: "Đà Nẵng" },
        { id: "Cần Thơ", name: "Cần Thơ" },
        { id: "Hải Phòng", name: "Hải Phòng" },
        { id: "Bình Dương", name: "Bình Dương" },
        { id: "Nha Trang", name: "Nha Trang" },
        { id: "Huế", name: "Huế" },
        { id: "Quy Nhơn", name: "Quy Nhơn" },
        { id: "Long Xuyên", name: "Long Xuyên" },
        { id: "Quảng Ngãi", name: "Quảng Ngãi" },
        { id: "Vũng Tàu", name: "Vũng Tàu" },
        { id: "Quảng Ninh", name: "Quảng Ninh" },
        { id: "Buôn Ma Thuột", name: "Buôn Ma Thuột" },
        { id: "Phú Quốc", name: "Phú Quốc" },
        { id: "Vinh", name: "Vinh" },
        { id: "Cà Mau", name: "Cà Mau" },
        { id: "Rạch Giá", name: "Rạch Giá" },
        { id: "Đà Lạt", name: "Đà Lạt" },
        { id: "Thanh Hóa", name: "Thanh Hóa" },
      ],
      SelectedDestination: this.$route.params.destination,
      Destination: [
        { id: "All", name: "---Tất cả---" },
        { id: "TP. Hồ Chí Minh", name: "TP. Hồ Chí Minh" },
        { id: "Bà Rịa - Vũng Tàu", name: "Bà Rịa - Vũng Tàu" },
        { id: "Bắc Cạn", name: "Bắc Cạn" },
        { id: "Côn Đảo", name: "Côn Đảo" },
        { id: "Bắc Ninh", name: "Bắc Ninh" },
        { id: "Bình Dương", name: "Bình Dương" },
        { id: "Nha Trang", name: "Nha Trang" },
        { id: "Huế", name: "Huế" },
        { id: "Bến Tre", name: "Bến Tre" },
        { id: "Long Xuyên", name: "Long Xuyên" },
        { id: "Mũi Né", name: "Mũi Né" },
        { id: "Phú Quốc", name: "Phú Quốc" },
        { id: "Sapa", name: "Sapa" },
        { id: "Hạ long", name: "Hạ long" },
        { id: "Quảng Ngãi", name: "Quảng Ngãi" },
        { id: "Vũng Tàu", name: "Vũng Tàu" },
        { id: "Hà Nội", name: "Hà Nội" },
        { id: "Buôn Ma Thuột", name: "Buôn Ma Thuột" },
        { id: "Cao Bằng", name: "Cao Bằng" },
        { id: "Ninh Bình", name: "Ninh Bình" },
        { id: "Thái Bình", name: "Thái Bình" },
        { id: "Phan Thiết", name: "Phan Thiết" },
        { id: "Đà Lạt", name: "Đà Lạt" },
        { id: "Thanh Hóa", name: "Thanh Hóa" },
      ],
      SelectedTime: this.$route.params.datetime,
      SelectedNumberDays: [
        { id: "1-3", name: "1-3 Ngày" },
        { id: "4-7", name: "4-7 Ngày" },
        { id: "8-14", name: "8-14 Ngày" },
        { id: "15-30", name: "Trên 14 Ngày" },
      ],
      SelectedPeople: [
        { id: "1", name: "1 Người" },
        { id: "2", name: "2 Người" },
        { id: "3-5", name: "3-5 Người" },
        { id: "5", name: "5+ Người" },
      ],
      TourType: [
        { id: 0, name: "---Tất cả---" },
        { id: 3, name: "Tour trọn gói" },
        { id: 4, name: "Tour gia đình" },
      ],
      SelectedTourType: this.$route.query.tourtype,
      SelectedOrderBy: -1,
      activeButton1: null,
      activeButton2: null,
      minDate: "",
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
      currentPage: 1,
      perPage: 6,
    };
  },
  mounted() {
    this.setMinDate();
  },
  methods: {
    ...mapActions(["fetchTourDetails"]),
    GetSearch(departure, destination, datetime, numberDay, tourtype) {
      // eslint-disable-next-line
      axios
        .get(
          `/api/Search/${departure}/${destination}/${datetime}/${numberDay}/${tourtype}`
        )
        .then((response) => {
          // handle success
          this.products = response.data;
          this.products.forEach((tour) => {
            tour.tourImage = `http://localhost:8080/api/Upload/${tour.tourImage}`;
          });
        })
        .catch((error) => {
          // handle error
          console.error(error);
        });
    },
    GetSearchBy(people, order) {
      // eslint-disable-next-line
      axios
        .get(
          `/api/Search/${this.$route.params.departure}/${this.$route.params.destination}/${this.$route.params.datetime}/${this.$route.params.numberDay}/${this.$route.query.tourtype}?people=${people}&orderby=${order}`
        )
        .then((response) => {
          // handle success
          this.products = response.data;
          this.products.forEach((tour) => {
            tour.tourImage = `http://localhost:8080/api/Upload/${tour.tourImage}`;
          });
        })
        .catch((error) => {
          // handle error
          console.error(error);
        });
    },

    changePage(page) {
      this.currentPage = page;
    },
    GetChangeByDeparture(departure) {
      this.$router.push({
        path: `/search/${departure}/${this.$route.params.destination}/${this.$route.params.datetime}/${this.$route.params.numberDay}`,
        query: { tourtype: this.$route.query.tourtype },
      });
    },
    GetChangeByDestination(destination) {
      this.$router.push({
        path: `/search/${this.$route.params.departure}/${destination}/${this.$route.params.datetime}/${this.$route.params.numberDay}`,
        query: { tourtype: this.$route.query.tourtype },
      });
    },
    GetChangeByNumberDay(numberDay) {
      this.$router.push({
        path: `/search/${this.$route.params.departure}/${this.$route.params.destination}/${this.$route.params.datetime}/${numberDay}`,
        query: { tourtype: this.$route.query.tourtype },
      });
    },
    GetChangeByPeople(avalablePeople) {
      this.$router.push({
        query: {
          tourtype: this.$route.query.tourtype,
          SoNguoi: `${avalablePeople}`,
          OrderBy: `${this.$route.query.OrderBy}`,
        },
      });
    },
    GetChangeByDateTime(datetime) {
      this.$router.push({
        path: `/search/${this.$route.params.departure}/${this.$route.params.destination}/${datetime}/${this.$route.params.numberDay}`,
        query: { tourtype: this.$route.query.tourtype },
      });
    },
    GetChangeByTourType(tourtype) {
      this.$router.push({
        path: `/search/${this.$route.params.departure}/${this.$route.params.destination}/${this.$route.params.datetime}/${this.$route.params.numberDay}`,
        query: { tourtype: tourtype },
      });
    },
    GetChangeByOrderBy(order) {
      this.$router.push({
        query: {
          tourtype: this.$route.query.tourtype,
          SoNguoi: `${this.$route.query.SoNguoi}`,
          OrderBy: `${order}`,
        },
      });
    },
    setMinDate() {
      const currentDate = new Date().toISOString().split("T")[0];
      this.minDate = currentDate;
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
  watch: {
    "$route.params.numberDay": {
      immediate: true,
      handler(newNumberDay) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.params.numberDay = newNumberDay;
        this.activeButton1 = newNumberDay;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearch(
          this.$route.params.departure,
          this.$route.params.destination,
          this.$route.params.datetime,
          newNumberDay,
          this.$route.query.tourtype
        );
        // this.SelectedOrderBy = this.$route.query.OrderBy;
        this.$route.query.OrderBy = this.SelectedOrderBy;

        this.GetSearchBy(this.$route.query.SoNguoi, this.$route.query.OrderBy);
      },
    },
    "$route.params.departure": {
      immediate: true,
      handler(newDeparture) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.params.departure = newDeparture;
        this.activeButton1 = this.$route.params.numberDay;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearch(
          newDeparture,
          this.$route.params.destination,
          this.$route.params.datetime,
          this.$route.params.numberDay,
          this.$route.query.tourtype
        );
        this.$route.query.OrderBy = this.SelectedOrderBy;
        this.GetSearchBy(this.$route.query.SoNguoi, this.$route.query.OrderBy);
      },
    },
    "$route.params.destination": {
      immediate: true,
      handler(newDestination) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.params.destination = newDestination;
        this.activeButton1 = this.$route.params.numberDay;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearch(
          this.$route.params.departure,
          newDestination,
          this.$route.params.datetime,
          this.$route.params.numberDay,
          this.$route.query.tourtype
        );
        this.$route.query.OrderBy = this.SelectedOrderBy;
        this.GetSearchBy(this.$route.query.SoNguoi, this.$route.query.OrderBy);
      },
    },
    "$route.query.tourtype": {
      immediate: true,
      handler(newTourType) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.query.tourtype = newTourType;
        this.activeButton1 = this.$route.params.numberDay;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearch(
          this.$route.params.departure,
          this.$route.params.destination,
          this.$route.params.datetime,
          this.$route.params.numberDay,
          newTourType
        );
        this.$route.query.OrderBy = this.SelectedOrderBy;
        this.GetSearchBy(this.$route.query.SoNguoi, this.$route.query.OrderBy);
      },
    },
    "$route.params.datetime": {
      immediate: true,
      handler(newDatetime) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.params.datetime = newDatetime;
        this.activeButton1 = this.$route.params.numberDay;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearch(
          this.$route.params.departure,
          this.$route.params.destination,
          newDatetime,
          this.$route.params.numberDay,
          this.$route.query.tourtype
        );
        this.$route.query.OrderBy = this.SelectedOrderBy;
        this.GetSearchBy(this.$route.query.SoNguoi, this.$route.query.OrderBy);

        // this.SelectedOrderBy=-1;
      },
    },
    "$route.query.SoNguoi": {
      immediate: true,
      handler(newPeople) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.query.SoNguoi = newPeople;
        this.activeButton1 = this.$route.params.numberDay;
        this.activeButton2 = newPeople;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearchBy(newPeople, this.$route.query.OrderBy);
        this.$route.query.OrderBy = this.SelectedOrderBy;
      },
    },
    "$route.query.OrderBy": {
      immediate: true,
      handler(newOrder) {
        // Cập nhật giá trị của biến this.$route.params.numberDay
        this.$route.query.OrderBy = newOrder;
        this.activeButton1 = this.$route.params.numberDay;
        this.activeButton2 = this.$route.query.SoNguoi;

        // Thực hiện các tác vụ khác dựa trên giá trị mới của numberDay
        this.GetSearchBy(this.$route.query.SoNguoi, newOrder);
      },
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_card.scss";
@import "@/assets/scss/_search.scss";

.p-title:hover {
  color: red;
}
</style>
