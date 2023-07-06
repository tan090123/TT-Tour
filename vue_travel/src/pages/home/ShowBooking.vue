<template>
  <main class="container-fluid">
    <div class="row">
      <aside class="col-12 col-md-8">
        <div class="left border border-1 p-5">
          <h1 class="text-danger pb-4">THÔNG TIN LIÊN LẠC</h1>
          <div class="left-inside d-flex border border-0 border-top py-5">
            <div class="w-50">
              <span>Họ tên:</span>
              <p>{{ showbooking.infoContact.contactName }}</p>
              <span>Địa chỉ:</span>
              <p>{{ showbooking.infoContact.contactAddress }}</p>
              <span>Ghi chú:</span>
              <p>
                {{ showbooking.infoContact.contactAddress }} ( Booking từ travel.com.vn)
              </p>
            </div>
            <div class="w-50">
              <span>Email:</span>
              <p>{{ showbooking.infoContact.contactEmail }}</p>
              <div class="d-flex">
                <div class="w-50">
                  <span> Di động:</span>
                  <p>{{ showbooking.infoContact.contactPhone }}</p>
                </div>
                <div class="w-50">
                  <span> Di động:</span>
                  <p>{{ showbooking.infoContact.contactPhone }}</p>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="left-bottom border border-1 p-5 my-5">
          <h1 class="text-danger pb-4">CHI TIẾT BOOKING</h1>
          <div class="border border-0 border-top py-5">
            <table>
              <tr>
                <th>Số booking:</th>
                <td>
                  <span class="text-danger fw-bold">{{
                    showbooking.Booking.bookingID
                  }}</span>
                  (Quý khách vui lòng nhớ số booking để thuận tiện cho các giao
                  dịch sau này)
                </td>
              </tr>
              <tr>
                <th>Trị giá booking:</th>
                <td>{{ formatter.format(showbooking.Booking.totalPrice) }}</td>
              </tr>
              <tr>
                <th>Số tiền đã thanh toán:</th>
                <td>0₫</td>
              </tr>
              <tr>
                <th>Số tiền còn lại:</th>
                <td>{{ formatter.format(showbooking.Booking.totalPrice) }}</td>
              </tr>
              <tr>
                <th>Ngày đăng ký:</th>
                <td>{{ showbooking.Booking.bookingDay.slice(0, 10) }}</td>
              </tr>
              <tr>
                <th>Hình thức thanh toán:</th>
                <td>{{ showbooking.Booking.payment }}</td>
              </tr>
              <tr>
                <th>Tình trạng:</th>
                <td>
                  {{ showbooking.Booking.status }}
                </td>
              </tr>
              <tr>
                <th>Thời hạn thanh toán:</th>
                <td>
                  {{ endDate }} (Theo giờ Việt Nam. Booking sẽ tự động hủy nếu
                  quá thời hạn thanh toán trên)
                </td>
              </tr>
            </table>
          </div>
        </div>
      </aside>

      <article class="col-12 col-md-4">
        <div class="border border-1 p-5">
          <h1 class="text-danger pb-4">PHIẾU XÁC NHẬN BOOKING</h1>
          <div class="inside border border-0 border-top py-5">
            <p>{{ showbooking.Booking.bookingName }}</p>
            <h4>
              Số booking:
              <span class="text-danger fw-bold"> {{ showbooking.Booking.bookingID }}</span>
            </h4>
          </div>
          <div class="border border-0 border-top py-5">
            <table>
              <tr>
                <th>Mã tour:</th>
                <td>{{ showbooking.tour.tourCode }}</td>
              </tr>
              <tr>
                <th>Hành trình:</th>
                <td>{{ showbooking.tour.departure }} - {{ showbooking.tour.destination }}</td>
              </tr>
              <tr>
                <th>Ngày đi:</th>
                <td>{{ showbooking.tour.tourCheckinDays.slice(0, 10) }}</td>
              </tr>
              <tr>
                <th>Ngày về:</th>
                <td>{{ showbooking.tour.tourCheckoutDays.slice(0, 10) }}</td>
              </tr>
              <tr>
                <th>Nơi khởi hành:</th>
                <td>{{ showbooking.tour.departure }}</td>
              </tr>
            </table>
          </div>
          <p>
            Để xem thông tin chương trình tour mới nhất Quý khách có thể dùng
            điện thoại để quét mã QR bên cạnh để truy cập vào website.
          </p>
          <p>
            Để cài phần mềm quét mã QR Code quý khách có thể tìm trong kho ứng
            dụng của điện thoại với từ khóa sau: QRCode Scanner, QRCode
            Reader,..
          </p>
        </div>
      </article>
    </div>

    <div class="tourist border border-1 p-5">
      <h1 class="text-danger pb-4">DANH SÁCH HÀNH KHÁCH</h1>
      <div class="list border border-0 border-top py-5">
        <table class="w-100">
          <thead class="bg-light">
            <tr>
              <th style="width: 20%">Họ tên</th>
              <th style="width: 20%">Ngày sinh</th>
              <th style="width: 20%">Giới tính</th>
              <th style="width: 20%">Độ tuổi</th>
              <th style="width: 20%">Tiền dịch vụ</th>
            </tr>
          </thead>
          <tbody>
            <tr
              class="border border-0 border-bottom"
              v-for="(tourist, index) in showbooking.Tourist"
              :key="index"
            >
              <td>{{ tourist.touristName }}</td>
              <td>{{ tourist.touristDate.slice(0, 10) }}</td>
              <td>{{ tourist.touristSex }}</td>
              <td>
                <table>
                  <tr
                    v-for="(item, itemIndex) in touristTypeName"
                    :key="itemIndex"
                  >
                    <td v-if="itemIndex === index">{{ item }}</td>
                  </tr>
                </table>
              </td>
              <td>
                {{ formatter.format(tourist.servicesPrice) }}
              </td>
            </tr>
          </tbody>
        </table>
        <h3 class="text-end m-3">
          Tổng cộng:
          <span class="text-danger fw-bold ms-3">{{
            formatter.format(showbooking.Booking.totalPrice)
          }}</span>
        </h3>
      </div>
    </div>
  </main>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "inforBooking-id",
  data() {
    return {
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
      endDate: null,
    };
  },
  mounted() {
    this.endDate = this.GetTimeOver();
    const currentTime = new Date();
    const endTime = new Date(this.endDate);
    const timeDifference = endTime - currentTime;

    if (timeDifference > 0) {
      setTimeout(() => {
        // Gọi hàm xóa API tại đây
        this.deleteBookingOver();
      }, timeDifference);
    }
  },
  computed: {
    ...mapState([
      "showbooking"
    ]),
    touristTypeName() {
      const inputArray = [];
      for (const value of this.showbooking.Tourist) {
        inputArray.push(value.touristType);
      }
      const filteredData = this.showbooking.TristType_price.filter((obj) =>
        inputArray.includes(obj.typeID)
      );

      const touristTypeName = filteredData.map((obj) => obj.touristTypeName);
      return touristTypeName;
    },
  },
  methods: {
    GetTimeOver() {
      const startDate = new Date(this.showbooking.Booking.bookingDay);
      startDate.setDate(startDate.getDate() + 2);
      startDate.setHours(0);
      startDate.setMinutes(0);
      startDate.setSeconds(0);

      const options = {
        year: "2-digit",
        month: "2-digit",
        day: "2-digit",
        hour: "2-digit",
        minute: "2-digit",
        second: "2-digit",
      };

      const formatter = new Intl.DateTimeFormat("en", options);
      const endDate = formatter.format(startDate);
      return endDate;
    },
    deleteBookingOver() {
      // Thực hiện việc xóa API tại đây
      try {
        // eslint-disable-next-line
        axios
          .delete(`/api/Bookings/${this.showbooking.Booking.bookingID}`)
          .then((response) => {
            // handle success
            console.log(response);
          })
          .catch((error) => {
            // handle error
            console.log(error);
          });
      } catch (error) {
        console.error(error);
        // Xử lý lỗi khi xóa không thành công
      }
    },
  },
};
</script>

<style>
main {
  margin-top: 10rem;
  margin-bottom: 6.7rem;
}
aside .left-bottom table tr {
  height: 4em;
}
aside .left-bottom table tr th {
  width: 18em;
  color: #2d4271;
}
aside .left-bottom table tr td {
  font-style: italic;
}
article table tr {
  height: 3em;
}
article table tr th {
  width: 50%;
  color: #2d4271;
}
.left .left-inside p,
article .inside p {
  color: #2d4271;
  font-weight: 700;
  margin-bottom: 3rem;
}
article table tr td {
  text-align: end;
  /* width: 100%; */
}
.tourist .list table {
  border-collapse: collapse;
}

.tourist .list th,
td {
  padding: 8px;
  text-align: left;
}

.tourist .list td {
  /* height: 1rem; */
  min-height: 1rem;
  max-height: 1rem;
}

.tourist .list th {
  background-color: #ff7675;
  color: #fff;
  /* width: 50px; */
}
</style>
