<template lang="">
  <div class="TourOrder">
    <div class="container-fluid">
      <div class="TourOrder__card">
        <div class="row">
          <div class="TourOrder__img col-12 col-md-4">
            <img
              :src="'/images/card/' + products.tourImage"
              alt="{{ products.tourName }}"
            />
            <!-- <img
              :src="require(`@/../public/images/card/${products.tourImage}`)"
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
                {{ products.tourName }}
              </h2>
            </div>
            <div class="TourOrder__desc">
              <p class="text">
                Mã Tour <span>{{ products.tourCode }}</span>
              </p>
              <p class="text">
                Khởi hành <span>{{ products.tourCheckinDays }}</span>
              </p>
              <p class="text">Thời gian <span>4 ngày</span></p>
              <p class="text">
                Nơi khởi hành <span>{{ products.departure }}</span>
              </p>
              <p class="text">
                Số chỗ còn nhận <span>{{ products.tourAvailableSit }}</span>
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
              <form action="#">
                <div class="row">
                  <div class="name col-12 col-md-6">
                    <label>Họ và Tên <b>*</b></label>
                    <input
                      class="form-control"
                      id="contact_name"
                      name="Fullname"
                      type="text"
                      value=""
                    />
                  </div>
                  <div class="mail col-12 col-md-6">
                    <label>Email <b>*</b></label>
                    <input
                      class="form-control"
                      id="email"
                      name="Email"
                      type="text"
                      value=""
                    />
                  </div>
                  <div class="phone col-12 col-md-6">
                    <label>Số điện thoại <b>*</b></label>
                    <input
                      class="form-control"
                      id="mobilephone"
                      name="Telephone"
                      type="text"
                      value=""
                    />
                  </div>
                  <div class="addess col-12 col-md-6">
                    <label>Địa chỉ</label>
                    <input
                      class="form-control"
                      id="address"
                      name="Address"
                      type="text"
                      value=""
                    />
                  </div>
                </div>
              </form>
            </div>
            <h3>Hành khách</h3>
            <div class="customer-quantity">
              <div class="change">
                <div class="change-title">
                  <h4>Người lớn</h4>
                  <p>&gt; 12 tuổi</p>
                </div>
                <div class="change-number">
                  <span class="minus btn-click">
                    <i class="fa fa-minus-circle" aria-hidden="true"></i>
                  </span>
                  <span class="number" id="adult">1</span>
                  <span class="plus btn-click">
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
                  <span class="minus btn-click"
                    ><i class="fa fa-minus-circle" id="childrenMinus"></i
                  ></span>
                  <span class="number" id="children">0</span>
                  <span class="plus btn-click"
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
                  <span class="minus btn-click"
                    ><i class="fa fa-minus-circle" id="smallchildrenMinus"></i
                  ></span>
                  <span class="number" id="smallchildren">0</span>
                  <span class="plus btn-click"
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
                  <span class="minus btn-click"
                    ><i class="fa fa-minus-circle" id="babyMinus"></i
                  ></span>
                  <span class="number" id="baby">0</span>
                  <span class="plus btn-click"
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
              <h5>Người lớn</h5>
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
                      <input type="text" placeholder="Vui lòng nhập Họ tên" />
                    </td>
                    <td>
                      <select class="form-control" name="" id="">
                        <option value="">Giới tính</option>
                        <option value="nam">Nam</option>
                        <option value="nu">Nữ</option>
                      </select>
                    </td>
                    <td>
                      <input type="date" name="" id="" />
                    </td>
                    <td>
                      <select class="form-control" name="" id="">
                        <option value="">Không sử dụng</option>
                        <option
                          v-for="tService in TServices"
                          :key="tService.tServicesID"
                          :value="tService.tServicesID"
                        >
                          {{ tService.servicesName }} -
                          {{ formatter.format(tService.servicesPrice) }}
                        </option>
                      </select>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div class="customer-help">
              <h5>Quý khách có ghi chú lưu ý gì, hãy nói với chúng tôi !</h5>
              <div class="help">
                <textarea
                  rows="5"
                  cols="20"
                  placeholder="Vui lòng nhập nội dung lời nhắn bằng tiếng việt hoặc tiếng anh..."
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
                ><span class="number"
                  >({{ products.tourAvailableSit }} khách)</span
                >
              </p>
              <div class="group-product row my-4">
                <div class="img col-4">
                  <img
                    :src="'/images/card/' + products.tourImage"
                    alt="{{ products.tourName }}"
                    class='w-100'
                  />
                </div>
                <div class="title col-8">
                  <h4>
                    {{ products.tourName }}
                  </h4>
                </div>
              </div>
              <div class="group-go my-5">
                <div class="start">
                  <h4>Bắt đầu chuyến đi</h4>
                  <p>{{ products.tourCheckinDays }}</p>
                </div>
                <div class="end">
                  <h4>Kết thúc chuyến đi</h4>
                  <p>{{ products.tourCheckinDays }}</p>
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
                          <span class="mx-1">1</span> người
                        </div>

                        <p class="details">
                          <span class="mx-1">1</span>người lớn
                        </p>
                      </th>
                    </tr>
                    <tr>
                      <td>Người lớn</td>
                      <th><span>1</span>x <span>4,390,000</span>đ</th>
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
                    </tr>
                    <tr>
                      <th>Phụ thu phòng riêng</th>
                      <th><span>1,500,000</span>đ</th>
                    </tr>
                    <tr>
                      <th>Mã giảm giá</th>
                      <td class="pb-3">
                        <button class="btn btn-light fs-3 me-2">Thêm Mã</button>
                        <button class="btn btn-success fs-3">Áp dụng</button>
                      </td>
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
                <button type="submit" class="btn btn-danger w-100 fs-2 py-3">
                  ĐẶT NGAY
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "booking-id",
  data() {
    return {
      products: [],
      TServices: [],
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
    };
  },
  mounted() {
    this.getProductByID(this.$route.params.id);
    this.getServicesTourist();
  },
  methods: {
    getProductByID(id) {
      // eslint-disable-next-line
      axios
        .get(`/api/Tour/${id}`)
        .then((response) => {
          // handle success
          this.products = response.data;
          //   console.log(this.products);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });
    },
    getServicesTourist() {
      // eslint-disable-next-line
      axios
        .get(`/api/TServices`)
        .then((response) => {
          // handle success
          this.TServices = response.data;
          console.log(this.TServices);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_order.scss";
</style>
