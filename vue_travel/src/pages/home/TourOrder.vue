<template lang="">
  <div class="TourOrder">
    <div class="container-fluid">
      <div class="TourOrder__card">
        <div class="row">
          <div class="TourOrder__img col-12 col-md-4">
            <img
              :src="'/images/card/' + tour.tourImage"
              alt="{{ tour.tourName }}"
            />
            <!-- <img
              :src="require(`@/../public/images/card/${tours.tourImage}`)"
              class="card-img-top"
              width="100%"
              :alt="products.tourName"
            /> -->
          </div>
          <div class="TourOrder__main col-12 col-md-8">
            <div class="TourOrder__rating">
              <span class="TourOrder__rating--point">9</span>
              <span class="TourOrder__rating--feedback">Tuyệt vời</span>
            </div>
            <div class="TourOrder__title">
              <h2>
                {{ tour.tourName }}
              </h2>
            </div>
            <div class="TourOrder__desc">
              <p class="text">
                Mã Tour: <span>{{ tour.tourCode }}</span>
              </p>
              <p class="text">
                Khởi hành: <span>{{ tour.tourCheckinDays }}</span>
              </p>
              <p class="text">
                Thời gian: <span>{{ tour.tour_NumberDays }} ngày</span>
              </p>
              <p class="text">
                Nơi khởi hành: <span>{{ tour.departure }}</span>
              </p>
              <p class="text">
                Số chỗ còn nhận: <span>{{ tour.tourAvailableSit }}</span>
              </p>
            </div>
          </div>
        </div>
      </div>

      <div class="TourOrder__info">
        <div class="row">
          <div class="TourOrder__info--detail col-12 col-md-8">
            <h2>Tổng quan về chuyến đi</h2>
            <div class="customer-contact">
              <h3>Thông tin liên lạc</h3>
              <div class="row">
                <div class="name col-12 col-md-6">
                  <input
                    class="form-control"
                    type="hidden"
                    v-model="infoContact.TourID"
                  />
                  <label>Họ và Tên <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="infoContact.ContactName"
                  />
                </div>
                <div class="mail col-12 col-md-6">
                  <label>Email <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="infoContact.ContactEmail"
                  />
                </div>
                <div class="phone col-12 col-md-6">
                  <label>Số điện thoại <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="infoContact.ContactPhone"
                  />
                </div>
                <div class="addess col-12 col-md-6">
                  <label>Địa chỉ</label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="infoContact.ContactAddress"
                  />
                </div>
              </div>
            </div>
            <h3>Hành khách</h3>
            <div class="customer-quantity">
              <div class="change">
                <div class="change-title">
                  <h4>Người lớn</h4>
                  <p>&gt; 12 tuổi</p>
                </div>
                <div class="change-number">
                  <span
                    class="minus btn-click"
                    @click="ChangeCustomer('-', 'Người lớn')"
                    style="cursor: pointer"
                  >
                    <i class="fa fa-minus-circle" aria-hidden="true"></i>
                  </span>
                  <span class="number" id="adult">{{ adults }}</span>
                  <span
                    class="plus btn-click"
                    @click="ChangeCustomer('+', 'Người lớn')"
                    style="cursor: pointer"
                  >
                    <i class="fa fa-plus-circle" id="adultPlus"></i>
                  </span>
                </div>
              </div>
              <div class="change">
                <div class="change-title">
                  <h4>Trẻ em</h4>
                  <p>Từ 5 - 11 tuổi</p>
                </div>
                <div class="change-number">
                  <span
                    class="minus btn-click"
                    @click="ChangeCustomer('-', 'Trẻ em')"
                    style="cursor: pointer"
                    ><i class="fa fa-minus-circle" id="childrenMinus"></i
                  ></span>
                  <span class="number" id="children">{{ children }}</span>
                  <span
                    class="plus btn-click"
                    @click="ChangeCustomer('+', 'Trẻ em')"
                    style="cursor: pointer"
                    ><i class="fa fa-plus-circle" id="childrenPlus"></i
                  ></span>
                </div>
              </div>
              <div class="change">
                <div class="change-title">
                  <h4>Trẻ nhỏ</h4>
                  <p>Từ 2 - 4 tuổi</p>
                </div>
                <div class="change-number">
                  <span
                    class="minus btn-click"
                    @click="ChangeCustomer('-', 'Trẻ nhỏ')"
                    style="cursor: pointer"
                    ><i class="fa fa-minus-circle" id="smallchildrenMinus"></i
                  ></span>
                  <span class="number" id="smallchildren">{{ young }}</span>
                  <span
                    class="plus btn-click"
                    @click="ChangeCustomer('+', 'Trẻ nhỏ')"
                    style="cursor: pointer"
                    ><i class="fa fa-plus-circle" id="smallchildrenPlus"></i
                  ></span>
                </div>
              </div>
              <div class="change">
                <div class="change-title">
                  <h4>Em bé</h4>
                  <p>Từ 0 - 2 tuổi</p>
                </div>
                <div class="change-number">
                  <span
                    class="minus btn-click"
                    @click="ChangeCustomer('-', 'Em bé')"
                    style="cursor: pointer"
                    ><i class="fa fa-minus-circle" id="babyMinus"></i
                  ></span>
                  <span class="number" id="baby">{{ baby }}</span>
                  <span
                    class="plus btn-click"
                    @click="ChangeCustomer('+', 'Em bé')"
                    style="cursor: pointer"
                    ><i class="fa fa-plus-circle" id="babyPlus"></i
                  ></span>
                </div>
              </div>
            </div>

            <div class="customer-notify">
              <div class="row">
                <div class="col-12 col-md-6">
                  <p>- Người lớn sinh trước ngày <span>28/05/2011</span></p>
                  <p>
                    - Trẻ nhỏ sinh từ <span>29/05/2018</span>đến
                    <span>28/05/2021</span>
                  </p>
                </div>
                <div class="col-12 col-md-6">
                  <p>
                    - Trẻ em sinh từ <span>29/05/2011</span>đến
                    <span>28/05/2018</span>
                  </p>
                  <p>
                    - Em bé sinh từ <span>29/05/2021</span>đến
                    <span>30/05/2023</span>
                  </p>
                </div>
              </div>
            </div>

            <div class="customer-info">
              <h3>Thông tin hành khách</h3>
              <div v-for="customer in customers" :key="customer.TypeName">
                <h5>{{ customer.TypeName }}</h5>
                <table>
                  <thead>
                    <tr>
                      <th>Họ tên</th>
                      <th>Giới tính</th>
                      <th>Ngày sinh</th>
                      <th>Dịch vụ</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>
                        <input
                          type="text"
                          placeholder="Vui lòng nhập Họ tên"
                          v-model="customer.touristName"
                        />
                      </td>
                      <td>
                        <select
                          class="form-control"
                          v-model="customer.touristSex"
                        >
                          <option value="">Giới tính</option>
                          <option value="Nam">Nam</option>
                          <option value="Nu">Nữ</option>
                        </select>
                      </td>
                      <td>
                        <input type="date" v-model="customer.touristDate" />
                      </td>
                      <td>
                        <div
                          v-for="tService in TServices"
                          :key="tService.tServicesID"
                        >
                          <input
                            type="checkbox"
                            :value="tService.servicesPrice"
                            v-model="customer.servicesPrice"
                          />{{ tService.servicesName }}
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
            <div class="customer-help">
              <h5>Quý khách có ghi chú lưu ý gì, hãy nói với chúng tôi !</h5>
              <div class="help">
                <textarea
                  rows="5"
                  cols="20"
                  placeholder="Vui lòng nhập nội dung lời nhắn bằng tiếng việt hoặc tiếng anh..."
                  v-model="customers.touristNote"
                ></textarea>
              </div>
            </div>
          </div>

          <div class="TourOrder__info--group col-12 col-md-4">
            <div class="group-support">
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
            <div class="group-sumary">
              <h3>Tóm tắt chuyến đi</h3>
              <p>
                Dịch vụ tùy chọn
                <b>Xe suốt tuyến - khách sạn tương đương 4* và 5*</b>
              </p>
              <p>
                <b>Tour trọn gói </b
                ><span class="number">({{ tour.tourAvailableSit }} khách)</span>
              </p>
              <div class="group-product row my-4">
                <div class="img col-4">
                  <img
                    :src="'/images/card/' + tour.tourImage"
                    alt="{{ tour.tourName }}"
                    class="w-100"
                  />
                </div>
                <div class="title col-8">
                  <h4>
                    {{ tour.tourName }}
                  </h4>
                </div>
              </div>
              <div class="group-go my-5">
                <div class="start">
                  <h4>Bắt đầu chuyến đi</h4>
                  <p>{{ tour.tourCheckinDays }}</p>
                </div>
                <div class="end">
                  <h4>Kết thúc chuyến đi</h4>
                  <p>{{ tour.tourCheckoutDays }}</p>
                </div>
              </div>
              <div class="group-tourist">
                <table>
                  <tbody>
                    <tr>
                      <th>Hành khách</th>
                      <th>
                        <div class="total d-flex justify-content-end">
                          <i class="fa-sharp fa-solid fa-users"></i>
                          <span class="mx-1">{{
                            adults + children + young + baby
                          }}</span>
                          người
                        </div>

                        <p class="details" v-for="people,index in customers" :key="index">
                          <span class="mx-1">{{people.TypeName}}</span>
                        </p>
                      </th>
                    </tr>
                    <tr
                      v-for="tristtype_price in TristType_price"
                      :key="tristtype_price.typeID"
                    >
                      <td>{{ tristtype_price.touristTypeName }}</td>
                      <th>
                        <span>{{ adults }}</span
                        >x
                        <span>{{
                          formatter.format(tristtype_price.touristType_Prices)
                        }}</span>
                      </th>
                    </tr>
                    <!-- <tr>
                      <td>Người lớn</td>
                      <th><span></span> <span>4,390,000</span>đ</th>
                    </tr>
                    <tr>
                      <td>Trẻ em</td>
                      <th><span></span> <span>0</span>đ</th>
                    </tr>
                    <tr>
                      <td>Trẻ nhỏ</td>
                      <th><span></span> <span>0</span>đ</th>
                    </tr>
                    <tr>
                      <td>Em bé</td>
                      <th><span></span> <span>0</span>đ</th>
                    </tr> -->
                    <tr>
                      <th>Phụ thu Dịch Vụ</th>
                      <th>
                        <span v-if="customers.servicesPrice == 0">0đ</span>
                        <span v-else>{{
                          formatter.format(totaltouristPrice)
                        }}</span>
                      </th>
                    </tr>
                    <tr class="price">
                      <th>Tổng cộng</th>
                      <th>
                        <p><span>5,890,000</span>đ</p>
                      </th>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div class="group-submit d-block">
                <button
                  type="submit"
                  class="btn btn-danger w-100 fs-2 py-3"
                  @click="submitOrder"
                >
                  ĐẶT NGAY
                </button>
                <p></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapState, mapActions } from "vuex";
// import {mapState} from "vuex"
export default {
  name: "booking-id",
  data() {
    return {
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
      customers: [
        {
          TypeName: "Người lớn",
          touristType: "",
          touristName: "",
          touristSex: "",
          touristDate: "",
          touristPrice: "",
          touristNote: "",
          servicesPrice: [],
        },
      ],
    };
  },
  mounted() {
    this.$store.dispatch("fetchTourOrder", { id: this.$route.query.tourID });
    this.customers[0] = this.FilterTristType_price;
    console.log(this.Tourist);
    console.log(this.customers);
    console.log(this.TristType_price);
  },
  computed: {
    ...mapState([
      "tour",
      "TServices",
      "TristType_price",
      "infoContact",
      "Tourist",
    ]),
    // eslint-disable-next-line vue/return-in-computed-property
    totaltouristPrice() {
      let sum = 0;
      this.customers.forEach((customer) => {
        sum += customer.servicesPrice.reduce((acc, val) => acc + val, 0);
      });
      return sum;
    },
    // eslint-disable-next-line vue/return-in-computed-property
    FilterTristType_price() {
      for (const value of this.TristType_price) {
        if (value.touristTypeName == "Người lớn") {
          // eslint-disable-next-line no-case-declarations, vue/no-side-effects-in-computed-properties
          return {
            TypeName: value.touristTypeName,
            touristType: value.typeID,
            touristName: "",
            touristSex: "",
            touristDate: "",
            touristPrice: value.touristType_Prices,
            touristNote: "",
            servicesPrice: [],
          };
        }
      }
      return null;
    },
    adults() {
      return this.customers.filter(
        (customer) => customer.TypeName === "Người lớn"
      ).length;
    },
    children() {
      return this.customers.filter((customer) => customer.TypeName === "Trẻ em")
        .length;
    },
    young() {
      return this.customers.filter(
        (customer) => customer.TypeName === "Trẻ nhỏ"
      ).length;
    },
    baby() {
      return this.customers.filter((customer) => customer.TypeName === "Em bé")
        .length;
    },
  },
  methods: {
    ...mapActions([
      "setInfoContact",
      "setTourist",
      "PlaceInfoContact",
      "PlaceTourist",
    ]),
    ChangeCustomer(key, type) {
      switch (key) {
        case "+":
          for (const value of this.TristType_price) {
            if (value.touristTypeName == type) {
              // eslint-disable-next-line no-case-declarations, vue/no-side-effects-in-computed-properties
              const newCustomer = {
                TypeName: value.touristTypeName,
                touristType: value.typeID,
                touristName: "",
                touristSex: "",
                touristDate: "",
                touristPrice: value.touristType_Prices,
                touristNote: "",
                servicesPrice: [],
              };
              this.customers.push(newCustomer); // Thêm khách hàng mới vào mảng customers
            }
          }
          break;
        case "-":
          // Tìm vị trí của khách hàng trong mảng customers dựa trên type
          // eslint-disable-next-line no-case-declarations
          const index = this.customers.findIndex(
            (customer) => customer.TypeName === type
          );
          // eslint-disable-next-line no-empty
          if (type == "Người lớn") {
            // Đếm số lượng phần tử "Người lớn" trong mảng customers
            const adultCount = this.customers.filter(
              (customer) => customer.TypeName === "Người lớn"
            ).length;
            if (adultCount > 1) {
              this.customers.splice(index, 1);
            }
          } else if (index !== -1) {
            this.customers.splice(index, 1); // Xóa khách hàng khỏi mảng customers
          }
          break;
        default:
          break;
      }
    },
    async submitOrder() {
      // Gọi action để cập nhật thông tin liên hệ trong Vuex store
      await this.setInfoContact({
        TourID: this.$route.query.tourID,
        ContactName: this.infoContact.ContactName,
        ContactEmail: this.infoContact.ContactEmail,
        ContactPhone: this.infoContact.ContactPhone,
        ContactAddress: this.infoContact.ContactAddress,
      }).then(() => {
        this.PlaceInfoContact()
          .then((response) => {
            console.log(response);
            // Xử lý phản hồi từ API sau khi đặt hàng thành công
          })
          .catch((error) => {
            console.error(error);
            // Xử lý lỗi nếu có
          });
      });

      for (const custum of this.customers) {
        await this.setTourist({
          touristType: custum.touristType,
          touristName: custum.touristName,
          touristSex: custum.touristSex,
          touristDate: custum.touristDate,
          touristPrice: custum.touristPrice,
          touristNote: custum.touristNote,
          servicesPrice: this.totaltouristPrice,
        }).then(() => {
          this.PlaceTourist()
            .then((response) => {
              console.log(response);
              // Xử lý phản hồi từ API sau khi đặt hàng thành công
            })
            .catch((error) => {
              console.error(error);
              // Xử lý lỗi nếu có
            });
        });

        // Xử lý phản hồi từ API sau khi đặt hàng thành công
      }
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_order.scss";
</style>
