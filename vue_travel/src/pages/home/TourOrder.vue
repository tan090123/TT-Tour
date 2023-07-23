<template lang="">
  <div class="TourOrder">
    <div class="container-fluid">
      <div class="TourOrder__card">
        <div class="row">
          <div class="TourOrder__img col-12 col-md-4">
            <img :src="order.tour.tourImage" alt="{{ order.tour.tourName }}"  />
          </div>
          <div class="TourOrder__main col-12 col-md-8">
            <div class="TourOrder__rating">
              <span class="TourOrder__rating--point">9</span>
              <span class="TourOrder__rating--feedback">Tuyệt vời</span>
            </div>
            <div class="TourOrder__title">
              <h2>
                {{ order.tour.tourName }}
              </h2>
            </div>
            <div class="TourOrder__desc">
              <p class="text">
                Mã Tour: <span>{{ order.tour.tourCode }}</span>
              </p>
              <p class="text">
                Khởi hành:
                <span>{{ order.tour.tourCheckinDays.slice(0, 10) }}</span>
              </p>
              <p class="text">
                Thời gian: <span>{{ order.tour.tour_NumberDays }} ngày</span>
              </p>
              <p class="text">
                Nơi khởi hành: <span>{{ order.tour.departure }}</span>
              </p>
              <p class="text">
                Số chỗ còn nhận: <span>{{ order.tour.tourAvailableSit }}</span>
              </p>
            </div>
          </div>
        </div>
      </div>

      <div class="TourOrder__info">
        <div class="row">
          <div
            class="TourOrder__info--detail col-12 col-md-8"
            v-if="!tourPayment"
          >
            <h2>Tổng quan về chuyến đi</h2>
            <div class="customer-contact">
              <h3>Thông tin liên lạc</h3>
              <div class="row">
                <div class="name col-12 col-md-6">
                  <input
                    class="form-control"
                    type="hidden"
                    v-model="order.infoContact.contactID"
                  />
                  <input
                    class="form-control"
                    type="hidden"
                    v-model="order.infoContact.TourID"
                  />

                  <label>Họ và Tên <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="order.infoContact.ContactName"
                    v-bind:class="{
                      'is-invalid': error_infoContact.ContactName,
                    }"
                  />
                  <p class="text-danger">
                    {{ error_infoContact.ContactName }}
                  </p>
                </div>
                <div class="mail col-12 col-md-6">
                  <label>Email <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="order.infoContact.ContactEmail"
                    v-bind:class="{
                      'is-invalid': error_infoContact.ContactEmail,
                    }"
                  />
                  <p class="text-danger">
                    {{ error_infoContact.ContactEmail }}
                  </p>
                </div>
                <div class="phone col-12 col-md-6">
                  <label>Số điện thoại <b>*</b></label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="order.infoContact.ContactPhone"
                    v-bind:class="{
                      'is-invalid': error_infoContact.ContactPhone,
                    }"
                  />
                  <p class="text-danger">
                    {{ error_infoContact.ContactPhone }}
                  </p>
                </div>
                <div class="addess col-12 col-md-6">
                  <label>Địa chỉ</label>
                  <input
                    class="form-control"
                    type="text"
                    v-model="order.infoContact.ContactAddress"
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
                        <input type="hidden" v-model="customer.touristID" />
                        <input
                          type="text"
                          placeholder="Vui lòng nhập Họ tên"
                          v-model="customer.touristName"
                          v-bind:class="{
                            'is-invalid': error_tourist.touristName,
                          }"
                        />
                        <p class="text-danger">
                          {{ error_tourist.touristName }}
                        </p>
                      </td>
                      <td>
                        <select
                          class="form-control"
                          v-model="customer.touristSex"
                          v-bind:class="{
                            'is-invalid': error_tourist.touristSex,
                          }"
                        >
                          <option value="">Giới tính</option>
                          <option value="Nam">Nam</option>
                          <option value="Nữ">Nữ</option>
                        </select>
                        <p class="text-danger">
                          {{ error_tourist.touristSex }}
                        </p>
                      </td>
                      <td>
                        <input
                          type="date"
                          v-model="customer.touristDate"
                          v-bind:class="{
                            'is-invalid': error_tourist.touristDate,
                          }"
                        />
                        <p class="text-danger">
                          {{ error_tourist.touristDate }}
                        </p>
                      </td>
                      <td>
                        <div
                          v-for="tService in order.TServices"
                          :key="tService.tServicesID"
                        >
                          <input
                            type="checkbox"
                            :value="{
                              id: tService.tServicesID,
                              price: tService.servicesPrice,
                            }"
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
                  v-model="order.infoContact.ContactNote"
                ></textarea>
              </div>
            </div>
          </div>

          <!------------------------------------------------------------------------------>
          <div class="TourOrder__info--detail col-12 col-md-8" v-else>
            <h2>Thanh toán</h2>
            <div class="customer-contact">
              <h3>Các hình thức thanh toán</h3>

              <div id="accordion">
                <div class="row">
                  <div class="col-6">
                    <div
                      class="card bg-light col-12 px-5 py-4 mt-3"
                      v-for="(payment, index) in payments.slice(
                        0,
                        Math.ceil(payments.length / 2)
                      )"
                      :key="index"
                    >
                      <div
                        class="d-flex justify-content-between align-items-center"
                      >
                        <h4 class="fs-2 fw-lighter">
                          <i class="fa-sharp fa-solid fa-money-bill me-3"></i
                          >{{ payment.name }}
                        </h4>
                        <input
                          type="radio"
                          data-bs-toggle="collapse"
                          :href="payment.href"
                          :id="payment.name"
                          :value="payment.name"
                          name="paymentMethod"
                          v-model="SelectedPayment"
                          :checked="index === 0"
                        />
                      </div>
                      <div
                        :id="'collapse' + index"
                        :class="['collapse', { show: index === 0 }]"
                        data-bs-parent="#accordion"
                      >
                        <p>
                          {{ payment.content }}
                        </p>
                      </div>
                    </div>
                  </div>

                  <div class="col-6">
                    <div
                      class="card bg-light px-5 py-4 mt-3"
                      v-for="(payment, index) in payments.slice(
                        Math.ceil(payments.length / 2)
                      )"
                      :key="index + Math.ceil(payments.length / 2)"
                    >
                      <div
                        class="d-flex justify-content-between align-items-center"
                      >
                        <h4 class="fs-2 fw-lighter">
                          <i class="fa-sharp fa-solid fa-money-bill me-3"></i>
                          {{ payment.name }}
                        </h4>
                        <input
                          type="radio"
                          data-bs-toggle="collapse"
                          :href="payment.href"
                          :id="payment.name"
                          :value="payment.name"
                          name="paymentMethod"
                          v-model="SelectedPayment"
                        />
                      </div>
                      <div
                        :id="
                          'collapse' + (index + Math.ceil(payments.length / 2))
                        "
                        :class="['collapse', { show: index === 0 }]"
                        data-bs-parent="#accordion"
                      >
                        <p>
                          {{ payment.content }}
                        </p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div class="mt-5">
                <h3>Điều khoản bắt buộc khi đăng ký online</h3>
                <div
                  class="border border-2 border-light p-4"
                  style="height: 25em; overflow-y: scroll"
                >
                  <h5 class="text-center fw-bold fs-4">
                    NỘI DUNG ĐỌC, HIỂU VÀ ĐỒNG Ý TRƯỚC KHI ĐĂNG KÝ ONLINE CHƯƠNG
                    TRÌNH DU LỊCH TRONG NƯỚC
                  </h5>
                  <p class="fw-bold fs-4">
                    Tôi đã hiểu rõ và đồng ý với các nội dung liên quan đến
                    chương trình tour trong giai đoạn bình thường mới và điều
                    kiện bán tour như sau:
                  </p>
                  <p>
                    1. Trường hợp tour di chuyển bằng xe/tàu hỏa/tàu thủy thì
                    Khách phải đảm bảo đã hoàn thành tiêm 02 mũi vắc xin và có
                    giấy xác nhận tiêm chủng (mũi thứ 02 từ 14 ngày trở lên và
                    không quá 12 tháng) hoặc F0 đã khỏi bệnh COVID-19 trong vòng
                    06 tháng có giấy xác nhận của bệnh viện tính đến thời điểm
                    đi du lịch. Theo chính sách của cơ quan nhà nước, địa phương
                    nơi điểm đi, điểm đến, các điều kiện trên có thể thay đổi
                    tùy từng thời điểm cụ thể và Vietravel sẽ thông báo cho
                    Khách hàng để bổ sung theo yêu cầu.
                  </p>
                  <p>
                    2. Trẻ em (đi cùng ba mẹ) phải xét nghiệm COVID-19 và có
                    giấy xác nhận âm tính của cơ sở Y tế trước ngày khởi hành
                    24h (chi phí xét nghiệm tự túc).
                  </p>
                  <p>
                    3. Thông tin kiểm soát dịch bệnh tại các địa phương sẽ thay
                    đổi và Vietravel sẽ cập nhật phương án phòng chống dịch
                    thường xuyên đến khách hàng (nếu có).
                  </p>
                  <p>
                    4. Khách hàng sẽ phối hợp cùng Vietravel thực hiện đúng theo
                    hướng dẫn phòng chống dịch hoặc các biện pháp cách ly theo
                    chỉ đạo từ địa phương - nếu có với chi phí tự túc.
                  </p>
                  <p class="fw-bold fs-4">
                    Tôi đã hiểu rõ và đồng ý với các nội dung liên quan đến
                    chương trình tour trong giai đoạn bình thường mới và điều
                    kiện bán tour như sau:
                  </p>
                  <p>
                    1. Trường hợp tour di chuyển bằng xe/tàu hỏa/tàu thủy thì
                    Khách phải đảm bảo đã hoàn thành tiêm 02 mũi vắc xin và có
                    giấy xác nhận tiêm chủng (mũi thứ 02 từ 14 ngày trở lên và
                    không quá 12 tháng) hoặc F0 đã khỏi bệnh COVID-19 trong vòng
                    06 tháng có giấy xác nhận của bệnh viện tính đến thời điểm
                    đi du lịch. Theo chính sách của cơ quan nhà nước, địa phương
                    nơi điểm đi, điểm đến, các điều kiện trên có thể thay đổi
                    tùy từng thời điểm cụ thể và Vietravel sẽ thông báo cho
                    Khách hàng để bổ sung theo yêu cầu.
                  </p>
                  <p>
                    2. Trẻ em (đi cùng ba mẹ) phải xét nghiệm COVID-19 và có
                    giấy xác nhận âm tính của cơ sở Y tế trước ngày khởi hành
                    24h (chi phí xét nghiệm tự túc).
                  </p>
                  <p>
                    3. Thông tin kiểm soát dịch bệnh tại các địa phương sẽ thay
                    đổi và Vietravel sẽ cập nhật phương án phòng chống dịch
                    thường xuyên đến khách hàng (nếu có).
                  </p>
                  <p>
                    4. Khách hàng sẽ phối hợp cùng Vietravel thực hiện đúng theo
                    hướng dẫn phòng chống dịch hoặc các biện pháp cách ly theo
                    chỉ đạo từ địa phương - nếu có với chi phí tự túc.
                  </p>
                  <p class="fw-bold fs-4">
                    Tôi đã hiểu rõ và đồng ý với các nội dung liên quan đến
                    chương trình tour trong giai đoạn bình thường mới và điều
                    kiện bán tour như sau:
                  </p>
                  <p>
                    1. Trường hợp tour di chuyển bằng xe/tàu hỏa/tàu thủy thì
                    Khách phải đảm bảo đã hoàn thành tiêm 02 mũi vắc xin và có
                    giấy xác nhận tiêm chủng (mũi thứ 02 từ 14 ngày trở lên và
                    không quá 12 tháng) hoặc F0 đã khỏi bệnh COVID-19 trong vòng
                    06 tháng có giấy xác nhận của bệnh viện tính đến thời điểm
                    đi du lịch. Theo chính sách của cơ quan nhà nước, địa phương
                    nơi điểm đi, điểm đến, các điều kiện trên có thể thay đổi
                    tùy từng thời điểm cụ thể và Vietravel sẽ thông báo cho
                    Khách hàng để bổ sung theo yêu cầu.
                  </p>
                  <p>
                    2. Trẻ em (đi cùng ba mẹ) phải xét nghiệm COVID-19 và có
                    giấy xác nhận âm tính của cơ sở Y tế trước ngày khởi hành
                    24h (chi phí xét nghiệm tự túc).
                  </p>
                  <p>
                    3. Thông tin kiểm soát dịch bệnh tại các địa phương sẽ thay
                    đổi và Vietravel sẽ cập nhật phương án phòng chống dịch
                    thường xuyên đến khách hàng (nếu có).
                  </p>
                  <p>
                    4. Khách hàng sẽ phối hợp cùng Vietravel thực hiện đúng theo
                    hướng dẫn phòng chống dịch hoặc các biện pháp cách ly theo
                    chỉ đạo từ địa phương - nếu có với chi phí tự túc.
                  </p>
                  <p class="fw-bold fs-4">
                    Tôi đã hiểu rõ và đồng ý với các nội dung liên quan đến
                    chương trình tour trong giai đoạn bình thường mới và điều
                    kiện bán tour như sau:
                  </p>
                  <p>
                    1. Trường hợp tour di chuyển bằng xe/tàu hỏa/tàu thủy thì
                    Khách phải đảm bảo đã hoàn thành tiêm 02 mũi vắc xin và có
                    giấy xác nhận tiêm chủng (mũi thứ 02 từ 14 ngày trở lên và
                    không quá 12 tháng) hoặc F0 đã khỏi bệnh COVID-19 trong vòng
                    06 tháng có giấy xác nhận của bệnh viện tính đến thời điểm
                    đi du lịch. Theo chính sách của cơ quan nhà nước, địa phương
                    nơi điểm đi, điểm đến, các điều kiện trên có thể thay đổi
                    tùy từng thời điểm cụ thể và Vietravel sẽ thông báo cho
                    Khách hàng để bổ sung theo yêu cầu.
                  </p>
                  <p>
                    2. Trẻ em (đi cùng ba mẹ) phải xét nghiệm COVID-19 và có
                    giấy xác nhận âm tính của cơ sở Y tế trước ngày khởi hành
                    24h (chi phí xét nghiệm tự túc).
                  </p>
                  <p>
                    3. Thông tin kiểm soát dịch bệnh tại các địa phương sẽ thay
                    đổi và Vietravel sẽ cập nhật phương án phòng chống dịch
                    thường xuyên đến khách hàng (nếu có).
                  </p>
                  <p>
                    4. Khách hàng sẽ phối hợp cùng Vietravel thực hiện đúng theo
                    hướng dẫn phòng chống dịch hoặc các biện pháp cách ly theo
                    chỉ đạo từ địa phương - nếu có với chi phí tự túc.
                  </p>
                </div>
                <label class="d-flex align-items-center fs-3 mt-3">
                  <input type="checkbox" class="me-3" v-model="condition" />
                  Tôi đồng ý với các điều kiện trên
                </label>
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
                <b>{{ order.TourType.typeName }} </b>
                <span class="number"
                  >({{ order.tour.tourAvailableSit }} khách)</span
                >
              </p>
              <div class="group-product row my-4">
                <div class="img col-4">
                  <img :src="order.tour.tourImage" alt="{{ order.tour.tourName }}" class="w-100" />
                </div>
                <div class="title col-8">
                  <h4>
                    {{ order.tour.tourName }}
                  </h4>
                </div>
              </div>
              <div class="group-go my-5">
                <div class="start">
                  <h4>Bắt đầu chuyến đi</h4>
                  <p>{{ order.tour.tourCheckinDays.slice(0, 10) }}</p>
                </div>
                <div class="end">
                  <h4>Kết thúc chuyến đi</h4>
                  <p>{{ order.tour.tourCheckoutDays.slice(0, 10) }}</p>
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
                          <span class="mx-1">{{ TotalSit }}</span>
                          người
                        </div>

                        <p class="details">
                          <span class="mx-1">{{ adults }}</span
                          >Người lớn
                        </p>
                        <p class="details">
                          <span class="mx-1">{{ children }}</span
                          >Trẻ em
                        </p>
                        <p class="details">
                          <span class="mx-1">{{ young }}</span
                          >Trẻ nhỏ
                        </p>
                        <p class="details">
                          <span class="mx-1">{{ baby }}</span
                          >Em bé
                        </p>
                      </th>
                    </tr>
                    <tr>
                      <td>Người lớn</td>
                      <th>
                        <span>{{ adults }}</span> x
                        <span>{{
                          formatter.format(FilterTristType_price.touristPrice)
                        }}</span>
                      </th>
                    </tr>
                    <tr>
                      <td>Trẻ em</td>
                      <th>
                        <span>{{ children }}</span> x
                        <span v-if="children == 0">0đ</span>
                        <span v-else>{{
                          formatter.format(childrenPrice)
                        }}</span>
                      </th>
                    </tr>
                    <tr>
                      <td>Trẻ nhỏ</td>
                      <th>
                        <span>{{ young }}</span> x
                        <span v-if="young == 0">0đ</span>
                        <span v-else>{{ formatter.format(youngPrice) }}</span>
                      </th>
                    </tr>
                    <tr>
                      <td>Em bé</td>
                      <th>
                        <span>{{ baby }}</span> x
                        <span v-if="baby == 0">0đ</span>
                        <span v-else>{{ formatter.format(babyPrice) }}</span>
                      </th>
                    </tr>
                    <tr>
                      <th>Phụ thu Dịch Vụ</th>
                      <th>
                        <span>{{ formatter.format(totaltouristPrice) }}</span>
                      </th>
                    </tr>
                    <tr>
                      <th>Số chỗ</th>
                      <th>
                        <span
                          >còn {{ TotalSit }}/{{
                            order.tour.tourAvailableSit
                          }}
                          chỗ</span
                        >
                      </th>
                    </tr>
                    <tr class="price">
                      <th>Tổng cộng</th>
                      <th>
                        <p>
                          <span>{{ formatter.format(TotalPrice) }}</span>
                        </p>
                      </th>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div class="group-submit d-block py-3">
                <button
                  type="submit"
                  class="btn btn-danger w-100 fs-2 py-3"
                  @click="submitOrder"
                >
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
          servicesPrice: [],
        },
      ],
      error_infoContact: {
        ContactName: "",
        ContactEmail: "",
        ContactPhone: "",
      },
      isValid_infoContact: false,
      error_tourist: {
        touristName: "",
        touristSex: "",
        touristDate: "",
      },
      isValid_tourist: false,
      tourPayment: false,
      payments: [
        {
          href: "#collapse0",
          name: "Tiền mặt",
          content:
            "Quý khách vui lòng thanh toán tại bất kỳ văn phòng Vietravel trên toàn quốc và các chi nhánh tại nước ngoài. Xem chi tiết.",
        },
        {
          href: "#collapse1",
          name: "Chuyển khoản",
          content:
            "Quý khách sau khi thực hiện việc chuyển khoản vui lòng gửi email đến contactcenter@vietravel.com hoặc gọi tổng đài 19001839 để được xác nhận từ công ty chúng tôi. Tên Tài Khoản : Công ty CP Du lịch và Tiếp thị GTVT Việt Nam – Vietravel Tên tài khoản viết tắt : VIETRAVEL Số Tài khoản : 111 6977 27979 Ngân hàng : Vietinbank - Chi nhánh 7",
        },
        {
          href: "#collapse2",
          name: "ATM / Internet Banking",
          content:
            "Vietravel chấp nhận thanh toán bằng thẻ ATM qua cổng thanh toán ZaloPay. Hãy đảm bảo Quý khách đang sử dụng thẻ ATM do ngân hàng trong nước phát hành và đã được kích hoạt chức năng thanh toán trực tuyến. Hướng dẫn thanh toán thẻ qua cồng ZaloPay Tại đây",
        },
        {
          href: "#collapse3",
          name: "Thanh toán bằng ZaloPay",
          content: "Quý khách vui lòng thanh toán tại mã QR trong App ZaloPay.",
        },
        {
          href: "#collapse4",
          name: "Thẻ tín dụng",
          content:
            "Tất cả giao dịch của Quý khách được xử lý bảo mật theo giao thức SSL tại hệ thống của MasterCard. Vietravel không lưu giữ bất kì thông tin nào về thẻ của quý khách tại hệ thống của Vietravel. Do đó, quý khách có thể hoàn toàn an tâm rằng thông tin thẻ của Quý khách sẽ được bảo đảm an toàn tuyệt đối tại hệ thống của MasterCard và Ngân hàng Ngoại Thương Việt Nam (Vietcombank). Hiện tại hệ thống www.travel.com.vn chấp nhận cho Quý khách thanh toán bằng một trong các loại thẻ sau: VISA (Credit hoặc Debit), MasterCard (Credit), Diners Clup International (Credit), JCB (Credit) và American Express (Credit) của bất kỳ ngân hàng nào.",
        },
        {
          href: "#collapse5",
          name: "Thanh toán VNPAY",
          content:
            "Đây là cổng thanh toán cho phép Quý khách thanh toán từ tài khoản ngân hàng thông qua hình thức quét mã QR trên tính năng QR Pay trong ứng dụng Mobile Banking của các Ngân hàng. Sau khi Thông tin đặt tour của Quý khách được xác nhận, hệ thống sẽ hiển thị mã QR để Quý khách dùng thiết bị di động quét mã thanh toán.",
        },
        { href: "#collapse6", name: "Thanh toán bằng Momo", content: "" },
        { href: "#collapse7", name: "Thanh toán bằng ShopeePay", content: "" },
        {
          href: "#collapse8",
          name: "Thanh toán bằng MBbank",
          content:
            "Quý khách vui lòng thanh toán tại mã QR trong App MB Banking.",
        },
      ],
      SelectedPayment: null,
      condition: false,
      isValid_payment: false,
      userID: "",
    };
  },
  mounted() {
    this.customers[0] = this.FilterTristType_price;
    this.SelectedPayment = this.payments[0].name;
    this.userID = localStorage.getItem("userID");
    console.log(this.customers);
  },
  computed: {
    ...mapState(["order"]),
    totaltouristPrice() {
      let sum = 0;
      this.customers.forEach((customer) => {
        var price = customer.servicesPrice;
        for (const cus of price) {
          sum += cus.price;
        }
      });
      return sum;
    },
    FilterTristType_price() {
      for (const value of this.order.TristType_price) {
        if (value.touristTypeName == "Người lớn") {
          // eslint-disable-next-line no-case-declarations, vue/no-side-effects-in-computed-properties
          return {
            TypeName: value.touristTypeName,
            touristType: value.typeID,
            touristName: "",
            touristSex: "",
            touristDate: "",
            touristPrice: value.touristType_Prices,
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
    // eslint-disable-next-line vue/return-in-computed-property
    TotalSit() {
      let total = this.adults + this.children + this.young + this.baby;

      return total;
    },
    // eslint-disable-next-line vue/return-in-computed-property
    childrenPrice() {
      for (const value of this.order.TristType_price) {
        if (value.touristTypeName === "Trẻ em") {
          return value.touristType_Prices;
        }
      }
    },
    // eslint-disable-next-line vue/return-in-computed-property
    youngPrice() {
      for (const value of this.order.TristType_price) {
        if (value.touristTypeName === "Trẻ nhỏ") {
          return value.touristType_Prices;
        }
      }
    },
    // eslint-disable-next-line vue/return-in-computed-property
    babyPrice() {
      for (const value of this.order.TristType_price) {
        if (value.touristTypeName === "Em bé") {
          return value.touristType_Prices;
        }
      }
    },
    // eslint-disable-next-line vue/return-in-computed-property
    TotalPrice() {
      return (
        this.children * this.childrenPrice +
        this.young * this.youngPrice +
        this.baby * this.babyPrice +
        this.adults * this.FilterTristType_price.touristPrice +
        this.totaltouristPrice
      );
    },
  },
  methods: {
    ...mapActions([
      "setInfoContact",
      "setTourist",
      "setBooking",
      "setTourist_TouristServices",
      "PlaceInfoContact",
      "PlaceTourist",
      "PlaceBooking",
      "PlaceTourist_TouristServices",
    ]),
    ChangeCustomer(key, type) {
      switch (key) {
        case "+":
          for (const value of this.order.TristType_price) {
            if (value.touristTypeName == type) {
              // eslint-disable-next-line no-case-declarations, vue/no-side-effects-in-computed-properties
              const newCustomer = {
                TypeName: value.touristTypeName,
                touristID: this.order.Tourist.touristID,
                touristType: value.typeID,
                touristName: "",
                touristSex: "",
                touristDate: "",
                touristPrice: value.touristType_Prices,
                servicesPrice: [],
              };
              //--Số lượng người tham gia < số lượng quy định của tour
              if (this.customers.length < this.order.tour.tourAvailableSit) {
                this.customers.push(newCustomer); // Thêm khách hàng mới vào mảng customers
              }
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
      this.validate_infoContact();
      this.validate_Tourist();
      if (this.isValid_infoContact && this.isValid_tourist) {
        this.tourPayment = true;
        if (this.isValid_payment != this.condition) {
          this.CheckedPayment();
          if (this.isValid_payment) {
            try {
              // Gọi action để cập nhật thông tin liên hệ trong Vuex store
              await this.setInfoContact({
                contactID: this.order.infoContact.contactID,
                TourID: this.$route.query.tourID,
                ContactName: this.order.infoContact.ContactName,
                ContactEmail: this.order.infoContact.ContactEmail,
                ContactPhone: this.order.infoContact.ContactPhone,
                ContactAddress: this.order.infoContact.ContactAddress,
                ContactNote: this.order.infoContact.ContactNote,
              });
              await this.PlaceInfoContact();

              await this.setBooking({
                bookingID: this.order.Booking.bookingID,
                tourID: this.$route.query.tourID,
                infoContactID: this.order.infoContact.contactID,
                userID: !this.userID ? 21 : this.userID,
                extraPrice: this.totaltouristPrice,
                currentPrice: this.order.tour.promotionPrice,
                totalPrice:
                  this.order.tour.promotionPrice + this.totaltouristPrice,
                payment: this.SelectedPayment,
                status: "Chưa thanh toán",
                tourCheckinDays: this.order.tour.tourCheckinDays,
                tourCheckoutDays: this.order.tour.tourCheckoutDays,
                departure: this.order.tour.departure,
                destination: this.order.tour.destination,
                bookingName: this.order.tour.tourName,
                bookingDay: new Date().toISOString(),
              });
              await this.PlaceBooking();

              for (const custum of this.customers) {
                await this.setTourist({
                  bookingID: this.order.Booking.bookingID,
                  touristID: custum.touristID,
                  touristType: custum.touristType,
                  touristName: custum.touristName,
                  touristSex: custum.touristSex,
                  touristDate: custum.touristDate,
                  touristPrice: custum.touristPrice,
                  servicesPrice: this.EachtouristPrice(custum.servicesPrice),
                });
                await this.PlaceTourist();

                for (const cus of custum.servicesPrice) {
                  await this.setTourist_TouristServices({
                    servicesID: this.order.Tourist_TouristServices.servicesID,
                    touristID: this.order.Tourist.touristID,
                    tServicesID: cus.id,
                  });
                  await this.PlaceTourist_TouristServices();
                }
              }

              this.$store
                .dispatch("fetchBooking", {
                  bookingID: this.order.Booking.bookingID,
                  tourID: this.$route.query.tourID,
                  infoContactID: this.order.Booking.infoContactID,
                  touristID: this.order.Tourist.touristID,
                })
                .then(() => {
                  let timerInterval;
                  // eslint-disable-next-line no-undef
                  Swal.fire({
                    title: "Đặt Tour thành công!",
                    html: "Sẽ chuyển sang trang thông tin trong <b></b> milliseconds.",
                    timer: 3000,
                    width: 800,
                    padding: "5em",
                    timerProgressBar: true,
                    didOpen: () => {
                      // eslint-disable-next-line no-undef
                      Swal.showLoading();
                      // eslint-disable-next-line no-undef
                      const b = Swal.getHtmlContainer().querySelector("b");
                      timerInterval = setInterval(() => {
                        // eslint-disable-next-line no-undef
                        b.textContent = Swal.getTimerLeft();
                      }, 100);
                    },
                    willClose: () => {
                      clearInterval(timerInterval);
                    },
                  }).then((result) => {
                    /* Read more about handling dismissals below */
                    // eslint-disable-next-line no-undef
                    if (result.dismiss === Swal.DismissReason.timer) {
                      this.$router.push({
                        name: "inforBooking-id",
                        query: { bookingID: this.order.Booking.bookingID },
                      });
                    }
                  });
                });
              // .then(() => {});
            } catch (error) {
              console.error(error);
            }
          }
        }

        //--------------------
      }
    },
    EachtouristPrice(array) {
      return array.reduce((accumulator, item) => {
        return accumulator + item.price;
      }, 0);
    },
    validate_infoContact() {
      if (!this.order.infoContact.ContactEmail) {
        this.error_infoContact.ContactEmail = "Email không được để trống";
        this.isValid_infoContact = false;
      } else if (
        !/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(
          this.order.infoContact.ContactEmail
        )
      ) {
        this.error_infoContact.ContactEmail = "Vui lòng đúng định dạng email";
        this.isValid_infoContact = false;
      } else {
        this.error_infoContact.ContactEmail = "";
        this.isValid_infoContact = true;
      }

      if (!this.order.infoContact.ContactName) {
        this.error_infoContact.ContactName = "Tên không được để trống";
        this.isValid_infoContact = false;
      } else {
        this.error_infoContact.ContactName = "";
        this.isValid_infoContact = true;
      }

      if (!this.order.infoContact.ContactPhone) {
        this.error_infoContact.ContactPhone = "Sđt không được để trống";
        this.isValid_infoContact = false;
      } else if (
        !/(((\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\b/.test(
          this.order.infoContact.ContactPhone
        )
      ) {
        this.error_infoContact.ContactPhone = "Vui lòng đúng định dạng Sđt";
        this.isValid_infoContact = false;
      } else {
        this.error_infoContact.ContactPhone = "";
        this.isValid_infoContact = true;
      }
    },
    validate_Tourist() {
      for (const customer of this.customers) {
        if (customer.touristName.trim() === "") {
          this.error_tourist.touristName = "Tên không được để trống";
          this.isValid_tourist = false;
        } else {
          this.error_tourist.touristName = "";
          this.isValid_tourist = true;
        }

        if (!customer.touristSex) {
          this.error_tourist.touristSex = "Giới tính không được để trống";
          this.isValid_tourist = false;
        } else {
          this.error_tourist.touristSex = "";
          this.isValid_tourist = true;
        }

        if (!customer.touristDate) {
          this.error_tourist.touristDate = "Năm sinh không được để trống";
          this.isValid_tourist = false;
        } else {
          this.error_tourist.touristDate = "";
          this.isValid_tourist = true;
        }
      }
    },
    CheckedPayment() {
      if (this.condition) {
        this.isValid_payment = true;
      }
    },
  },
};
</script>
<style lang="scss">
@import "@/assets/scss/_order.scss";
</style>
