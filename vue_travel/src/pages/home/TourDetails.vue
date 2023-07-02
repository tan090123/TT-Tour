<template lang="">
  <div class="TourDetails">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 col-md-6">
          <div class="TourDetails__ticket">
            <i class="fa fa-ticket" aria-hidden="true"></i>
            <span>{{ tour.tourCode }}</span>
          </div>
          <div class="TourDetails__title">
            <p>{{ tour.tourName }}</p>
          </div>
          <div class="TourDetails__rating">
            <span class="TourDetails__rating--point">9</span>
            <span class="TourDetails__rating--feedback">Tuyệt vời</span>
          </div>
        </div>
        <div class="col-12 col-md-6 text-end mt-5">
          <div class="row">
            <div class="col-6 col-md-9">
              <div
                class="TourDetails__discount"
                v-if="tour.price != tour.promotionPrice"
              >
                <p>
                  Giá <span>{{ formatter.format(tour.price) }}</span
                  >/ khách
                </p>
              </div>
              <div class="TourDetails__price">
                <p>
                  <span>{{ formatter.format(tour.promotionPrice) }}</span
                  >/ khách
                </p>
              </div>
            </div>

            <div class="col-6 col-md-3">
              <div class="TourDetails__cart">
                <button
                  type="button"
                  class="cart"
                  data-bs-toggle="modal"
                  data-bs-target="#myModal"
                >
                  <i class="fa fa-cart-shopping" aria-hidden="true"></i>
                  <span> Đặt ngay </span>
                </button>
                <a class="group" href="#">Liên hệ tư vấn</a>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- <div class="carousel mt-5">
        <div class="owl-carousel owl-theme p-0">
          <div class="item" v-for="(tourimg, index) in tourImage" :key="index">
            <a href="#">
               <img :src="'/images/details/' + tourimg.images" alt="TQ1" />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_1.jpg"
                alt="TQ1"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_1.jpg"
                alt="TQ1"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_1.jpg"
                alt="TQ1"
              />
            </a>
          </div>
        </div>
      </div> -->
      <!-- Images -->
      <section class="tour-images">
        <div class="row">
          <div class="col-12 col-md-12 col-lg-7 left">
            <img
              :src="tour.tourImage"
              style="object-fit: cover; width: 100%"
              alt=""
            />
          </div>
          <div class="col-12 col-md-12 col-lg-5 right">
            <div class="row gy-4">
              <div class="col-12 col-md-12 small">
                <div class="row">
                  <div class="col-6">
                    <img src="@/../public/images/details/tq_1.jpg" alt="" />
                  </div>
                  <div class="col-6">
                    <img src="@/../public/images/details/tq_2.jpg" alt="" />
                  </div>
                </div>
                <div class="col-12 col-md-12 big mt-3">
                  <img src="@/../public/images/details/tq_3.jpg" alt="" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <!-- End images -->
      <div class="TourDetails__section row">
        <div class="col-12 col-md-5">
          <div class="TourDetails__section--detail row">
            <div class="col-12 col-md-8">
              <p class="text">
                Khởi hành: <span>{{ tour.tourCheckinDays }}</span>
              </p>
              <p class="text">Tập trung <span>12:25 ngày 30/05/2023</span></p>
              <p class="text">
                Thời gian <span>{{ tour.tour_NumberDays }} ngày</span>
              </p>
              <p class="text">
                Nơi khởi hành <span>{{ tour.departure }}</span>
              </p>
              <p class="text">
                Số chỗ còn nhận <span>{{ tour.tourAvailableSit }}</span>
              </p>
            </div>
            <div class="col-12 col-md-4 text-end">
              <a href="#">
                <i class="fa fa-calendar-check-o" aria-hidden="true"></i>
                <span>Ngày khác</span>
              </a>
            </div>
          </div>
          <div class="TourDetails__section--support">
            <h5>Quý khách cần hỗ trợ?</h5>
            <div class="group-contact">
              <a href="#" class="phone d-flex">
                <i class="fa fa-phone" aria-hidden="true"></i>
                <p>Gọi miễn phí qua internet</p>
              </a>
              <a href="#" class="mail d-flex">
                <i class="fa fa-envelope" aria-hidden="true"></i>
                <p>Gửi yêu cầu hỗ trợ ngay</p>
              </a>
            </div>
          </div>
        </div>
        <div class="col-12 col-md-7">
          <div class="TourDetails__section--icon">
            <div class="row">
              <div
                class="col-12 col-md-3 mb-3"
                v-for="tourService in ServicesTour"
                :key="tourService.tourID"
              >
                <img
                  src="@/../public/images/icon/thoi_gian.png"
                  alt="Thời gian"
                />
                <h5>{{ tourService.servicesTourName }}</h5>
                <p>{{ tourService.servicesTourDesc }}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="TourDetails__desc row my-5 py-5">
    <h3 class="text-center">Lịch Trình</h3>
    <div class="TourDetails__desc--short col-3">
      <div
        class="d-flex justify-content-between align-items-center row mt-2"
        v-for="(tourSche, index) in TourSchedule"
        :key="index"
      >
        <div class="date-left col-1">
          <span>Ngày</span>
        </div>
        <div
          class="date-center bg-danger rounded-circle text-center ms-3 col-2 text-light pt-2"
          style="width: 2em; height: 2em"
        >
          {{ index + 1 }}
        </div>
        <div class="date-right ms-3 col-9">
          <span class="fs-5">11/06/2023</span>
          <h4 class="fs-4 fw-bold">
            {{ tourSche.scheduleName }}
          </h4>
        </div>
      </div>
    </div>
    <div
      class="TourDetails__desc--desc col-9 border border-0 border-start border-success"
    >
      <div class="container-fluid">
        <div class="div" v-for="(tourSche, index) in TourSchedule" :key="index">
          <h3 class="fs-2">
            Ngày {{ index + 1 }} - {{ tourSche.scheduleName }}
          </h3>
          <p class="ps-5">
            {{ tourSche.scheduleDesc }}
          </p>
        </div>
      </div>
    </div>
  </div>

  <div class="TourDetails__info my-5">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 col-md-6">
          <h2>Giá tour & phụ thu phòng đơn</h2>
          <div class="TourDetails__info--bill">
            <table>
              <thead>
                <tr>
                  <th style="width: 35rem">Loại khách</th>
                  <th>Giá tour</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(trist_price,index) in TristType_price" :key="index">
                  <td>{{trist_price.touristTypeName}}</td>
                  <td class="price">{{formatter.format(trist_price.touristType_Prices)}}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="col-12 col-md-6">
          <h2>Thông tin hướng dẫn viên</h2>
          <div class="TourDetails__info--item">
            <p class="title">
              HDV dẫn đoàn:
              <span>{{ TourGuide.guideName }}</span>
            </p>
            <p class="address">Địa chỉ : {{ TourGuide.guideAddress }}</p>
            <p class="mobile">Số đt : {{ TourGuide.guidePhone }}</p>
            <div class="desc">Đang cập nhật</div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="TouDetails__help">
    <div class="container-fluid">
      <h3>Những thông tin cần lưu ý</h3>
      <div class="row">
        <div class="col-12 col-md-6">
          <div class="accordion accordion-flush" id="accordionFlushExample">
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingOne">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseOne"
                  aria-expanded="false"
                  aria-controls="flush-collapseOne"
                >
                  Giá tour bao gồm
                </button>
              </h2>
              <div
                id="flush-collapseOne"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingOne"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>- Visa nhập cảnh Hàn Quốc.</p>
                  <p>
                    - Vé máy bay khứ hồi Sài Gòn – Incheon// Incheon - Sài Gòn ,
                    thuế phi trường & phụ thu xăng dầu
                  </p>
                  <p>
                    - Khách sạn 3 * tiêu chuẩn địa phương ( (2 người lớn/ phòng
                    2 giường đơn)
                  </p>
                  <p>- Ăn uống, tham quan và vận chuyển như chương trình.</p>
                  <p>
                    - Hướng dẫn viên của Vietravel nói tiếng Việt và đi theo
                    suốt tuyến
                  </p>
                  <p>
                    - Vé xem LOTTE DUTY FREE 32nd Family Concert (hạng vé ngồi
                    đặc biệt)
                  </p>
                  <p>- Xe máy lạnh sử dụng theo chương trình</p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingTwo">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseTwo"
                  aria-expanded="false"
                  aria-controls="flush-collapseTwo"
                >
                  Giá tour không bao gồm
                </button>
              </h2>
              <div
                id="flush-collapseTwo"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingTwo"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>- Hộ chiếu, hành lý quá cước.</p>
                  <p>- Chí phí cá nhân: điện thoại, giặt ủi, ...</p>
                  <p>- Tham quan ngoài chương trình.</p>
                  <p>
                    - Tiền bồi dưỡng cho hướng dẫn viên và tài xế địa phương:
                    140.000 VND/Khách/Ngày.....
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingThree">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseThree"
                  aria-expanded="false"
                  aria-controls="flush-collapseThree"
                >
                  Giá vé trẻ em
                </button>
              </h2>
              <div
                id="flush-collapseThree"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingThree"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>- Trẻ em dưới 2 tuổi: 30% giá tour người lớn.</p>
                  <p>
                    - Trẻ em từ 2 tuổi đến dưới 12 tuổi: 75% giá tour người lớn
                    (không có chế độ giường riêng).
                  </p>
                  <p>
                    - Trẻ em từ 2 tuổi đến dưới 12 tuổi: 90% giá tour người lớn
                    (có chế độ giường riêng).
                  </p>
                  <p>- Trẻ em đủ 12 tuổi trở lên: 100% giá tour người lớn.</p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingFour">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseFour"
                  aria-expanded="false"
                  aria-controls="flush-collapseFour"
                >
                  Điều kiện thanh toán
                </button>
              </h2>
              <div
                id="flush-collapseFour"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingFour"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>- Đợt 1: Đặt cọc 50% tổng giá trị tour/khách.</p>
                  <p>
                    - Đợt 2: Thanh toán số tiền còn lại trước ngày khởi hành 7
                    ngày (cho tour ngày thường) và trước 20 ngày (cho tour ngày
                    Lễ, Tết, Hoa Anh Đào)
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingFive">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseFive"
                  aria-expanded="false"
                  aria-controls="flush-collapseFive"
                >
                  Các điều kiện khi đăng ký tour
                </button>
              </h2>
              <div
                id="flush-collapseFive"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingFive"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    - Khi đăng ký tour du lịch, Quý khách vui lòng đọc kỹ chương
                    trình, giá tour, các khoản bao gồm cũng như không bao gồm
                    trong chương trình, các điều kiện hủy tour trên biên nhận
                    đóng tiền......
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingSix">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseSix"
                  aria-expanded="false"
                  aria-controls="flush-collapseSix"
                >
                  Liên hệ
                </button>
              </h2>
              <div
                id="flush-collapseSix"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingSix"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p class="text-center">
                    Thông tin tour và giá tour có thể thay đổi tại thời điểm
                    đăng ký và thanh toán. Mọi chi tiết xin vui lòng liên hệ
                    Tổng đài tư vấn 1900 1839 – ext: 1933, 1349 Công ty du lịch
                    Vietravel 190 Pasteur, Phường Võ Thị Sáu, Quận 3, TP.HCM
                    KÍNH CHÚC QUÝ KHÁCH CÓ MỘT CHUYẾN DU LỊCH VUI VẺ!
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-12 col-md-6">
          <div class="accordion accordion-flush" id="accordionFlushExample">
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingOne">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseOneR"
                  aria-expanded="false"
                  aria-controls="flush-collapseOneR"
                >
                  Lưu ý khi chuyển/hủy tour
                </button>
              </h2>
              <div
                id="flush-collapseOneR"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingOne"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    - Sau khi đóng tiền, nếu Quý khách muốn chuyển/huỷ tour xin
                    vui lòng mang Vé Du Lịch đến văn phòng đăng ký tour để làm
                    thủ tục chuyển/huỷ tour và chịu chi phí theo quy định của
                    Vietravel. Không giải quyết các trường hợp liên hệ
                    chuyển/huỷ tour qua điện thoại...
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingTwo">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseTwoR"
                  aria-expanded="false"
                  aria-controls="flush-collapseTwoR"
                >
                  Các điều kiện hủy tour đối với ngày thường
                </button>
              </h2>
              <div
                id="flush-collapseTwoR"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingTwo"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    - Nếu hủy hoặc chuyển sang các tuyến du lịch khác trước ngày
                    khởi hành 30: Không mất chi phí.
                  </p>
                  <p>
                    - Nếu hủy hoặc chuyển sang các chuyến du lịch khác từ 24-29
                    ngày trước ngày khởi hành: Chi phí chuyển/ huỷ tour là 50%
                    tiền cọc tour...
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingThree">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseThreeR"
                  aria-expanded="false"
                  aria-controls="flush-collapseThreeR"
                >
                  Các điều kiện hủy tour đối với ngày lễ, Tết
                </button>
              </h2>
              <div
                id="flush-collapseThreeR"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingThree"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    Áp dụng cho các tour có thời gian diễn ra rơi vào một trong
                    các ngày Lễ, Tết theo qui định
                  </p>
                  <p>
                    - Nếu hủy hoặc chuyển sang các tuyến du lịch khác trước ngày
                    khởi hành 45 ngày: Không mất chi phí.
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingFour">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseFourR"
                  aria-expanded="false"
                  aria-controls="flush-collapseFourR"
                >
                  Trường hợp bất khả kháng
                </button>
              </h2>
              <div
                id="flush-collapseFourR"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingFour"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    - Nếu chương trình du lịch bị hủy bỏ hoặc thay đổi bởi một
                    trong hai bên vì lý do bất khả kháng (hỏa hoạn, thời tiết,
                    tai nạn, thiên tai, chiến tranh, dịch bệnh, hoãn, dời, và
                    hủy chuyến hoặc thay đổi khác của các phương tiện vận chuyển
                    công cộng hoặc các sự kiến bất khả kháng khác theo quy định
                    pháp luật…)
                  </p>
                </div>
              </div>
            </div>
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingFive">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseFiveR"
                  aria-expanded="false"
                  aria-controls="flush-collapseFiveR"
                >
                  Thông tin visa
                </button>
              </h2>
              <div
                id="flush-collapseFiveR"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingFive"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body">
                  <p>
                    **Điều kiện để xin Visa Hàn Quốc (Hộ khẩu từ Bình Định, Kon
                    Tum trở vào Nam): Quý khách vui lòng chuẩn bị danh mục hồ sơ
                    dưới đây ....
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- The Modal -->
  <div class="modal fade" id="myModal">
    <div class="modal-dialog modal-lg">
      <div class="modal-content p-3">
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title py-3">DANH SÁCH DỊCH VỤ</h4>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
          ></button>
        </div>

        <!-- Modal body -->
        <div class="modal-body py-3">
          <h2 class="text-primary">Danh sách lựa chọn</h2>
          <div class="col-12 my-2">
            <table class="table caption-top">
              <tbody>
                <tr>
                  <td colspan="2" class="fs-4 fst-italic">
                    <span id="OptionName_1">
                      {{ tour.tourName }}
                    </span>
                  </td>
                  <td></td>
                  <td></td>
                  <td class="d-flex justify-content-end">
                    <span class="px-2 fs-4 fst-italic" id="optionPrice_1">
                      {{
                        tour.promotionPrice
                          ? formatter.format(tour.promotionPrice)
                          : formatter.format(tour.price)
                      }}
                    </span>
                    <div class="form-check">
                      <input
                        class="form-check-input"
                        checked=""
                        type="radio"
                        value="4990000"
                        name="flexRadioDefault"
                        id="option_1"
                      />
                    </div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- Modal footer -->
        <div class="modal-footer py-5 border border-0">
          <div class="container">
            <div class="row">
              <div class="col-12 d-flex justify-content-end fw-bold">
                <span class="px-4">Thành tiền :</span>
                <span class="px-2" id="TotalPriceService">
                  {{
                    tour.promotionPrice
                      ? formatter.format(tour.promotionPrice)
                      : formatter.format(tour.price)
                  }}
                </span>
              </div>
            </div>
          </div>
          <div class="col-12 d-flex justify-content-center">
            <button
              type="submit"
              id="btn-order"
              class="btn btn-danger text-uppercase btn-lg"
              @click="submitBooking()"
            >
              Đặt ngay
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapState } from 'vuex';
export default {
  name: "details-id",
  data() {
    return {
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
    };
  },
  mounted() {
    this.$store.dispatch("fetchTourDetails", { id: this.$route.params.id });
  },
  methods: {
    submitBooking() {
      this.$router.push({
        path: `/booking`,
        query: { tourID: this.tour.tourID },
      });

      window.location.href = `/booking?tourID=${this.tour.tourID}`;
    },
  },
  computed:{
    ...mapState(["tour","TourSchedule","TourGuide","ServicesTour","TristType_price"]),
  }
};
</script>

<style lang="scss" scoped>
@import "@/assets/scss/_details.scss";
@import "@/assets/scss/_carousel.scss";

.tour-images {
  margin: 3rem 0;

  img {
    border-radius: 15px;
    width: 100%;
    height: 100%;
    object-fit: cover;
  }
}
</style>
