<template lang="">
  <div class="TourDetails">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 col-md-6">
          <div class="TourDetails__ticket">
            <i class="fa fa-ticket" aria-hidden="true"></i>
            <span>{{ products.tourCode }}</span>
          </div>
          <div class="TourDetails__title">
            <p>{{ products.tourName }}</p>
          </div>
          <div class="TourDetails__rating">
            <span class="TourDetails__rating--point">9</span>
            <span class="TourDetails__rating--feedback">Tuyệt vời</span>
          </div>
        </div>
        <div class="col-12 col-md-6 text-end mt-5">
          <div class="row">
            <div class="col-6 col-md-9">
              <div class="TourDetails__discount">
                <p>
                  Giá <span>{{ formatter.format(products.price) }}</span
                  >/ khách
                </p>
              </div>
              <div class="TourDetails__price">
                <p>
                  <span>{{ formatter.format(products.promotionPrice) }}</span
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

      <div class="carousel mt-5">
        <div class="owl-carousel owl-theme p-0">
          <div class="item">
            <a href="#">
              <img src="@/../public/images/details/tq_1.jpg" alt="TQ1" />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_2.jpg"
                alt="Dai hoi han quoc"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_3.jpg"
                alt="Dai hoi han quoc 4 ngay 3 dem"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_4.jpg"
                alt="Trai nghiem mua he nuoc uc"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_5.jpg"
                alt="Trai nghiem mua he nuoc uc"
              />
            </a>
          </div>
          <div class="item">
            <a href="#">
              <img
                src="@/../public/images/details/tq_6.jpg"
                alt="Trai nghiem mua he nuoc uc"
              />
            </a>
          </div>
        </div>
      </div>

      <div class="TourDetails__section row">
        <div class="col-12 col-md-5">
          <div class="TourDetails__section--detail row">
            <div class="col-12 col-md-8">
              <p class="text">
                Khởi hành: <span>{{ products.tourCheckinDays }}</span>
              </p>
              <p class="text">Tập trung <span>12:25 ngày 30/05/2023</span></p>
              <p class="text">Thời gian <span>6 ngày</span></p>
              <p class="text">
                Nơi khởi hành <span>{{ products.departure }}</span>
              </p>
              <p class="text">
                Số chỗ còn nhận <span>{{ products.tourAvailableSit }}</span>
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
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/thoi_gian.png"
                  alt="Thời gian"
                />
                <h5>Thời gian</h5>
                <p>6 ngày 5 đêm</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/phuong_tien_di_chuyen.png"
                  alt="Phương tiện di chuyển"
                />
                <h5>Phương tiện di chuyển</h5>
                <p>Máy bay, Xe du lịch</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/map.png"
                  alt="Điểm tham quan"
                />
                <h5>Điểm tham quan</h5>
                <p>
                  Trung Quốc, Trương Gia Giới, Phượng Hoàng Cổ Trấn, Thiên Môn
                  Sơn, Bảo Phong Hồ
                </p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img src="@/../public/images/icon/am_thuc.png" alt="Ẩm thực" />
                <h5>Ẩm thực</h5>
                <p>Buffet sáng, Theo thực đơn</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/khach_san.png"
                  alt="Khách sạn"
                />
                <h5>Khách sạn</h5>
                <p>Khách sạn 4 sao</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/thoi_gian_ly_tuong.png"
                  alt="Thời gian lý tưởng"
                />
                <h5>Thời gian lý tưởng</h5>
                <p>Quanh năm</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/doi_tuong_thich_hop.png"
                  alt="Đối tượng thích "
                />
                <h5>Đối tượng thích hợp</h5>
                <p>Cặp đôi, Gia đình nhiều thế hệ, Thanh niên</p>
              </div>
              <div class="col-12 col-md-3 mb-3">
                <img
                  src="@/../public/images/icon/doi_tuong_thich_hop.png"
                  alt="Đối tượng thích "
                />
                <h5>Ưu đãi</h5>
                <p>Đã bao gồm ưu đãi trong giá tour</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="TourDetails__desc">
    <h3>Điểm nhấn</h3>
    <div class="TourDetails__desc--desc">
      <div class="container-fluid">
        <p>
          Phượng Hoàng Cổ Trấn nay đã không còn xa lạ với tín đồ yêu thích du
          lịch tại Việt Nam. Với vẻ đẹp huyền ảo như lạc vào cõi mộng Phượng
          Hoàng Cổ Trấn từ lâu đã là một địa điểm du lịch nổi tiếng của Trung
          Quốc và cũng là “Thiên Đường Sống Ảo” của các bạn trẻ Việt với nét cổ
          kính và trầm mặc cùng năm tháng không lẫn vào đâu. Lạc bước giữa
          Trương Gia Giới – cảnh sắc khiến du khách như lạc vào chốn bồng lai
          tiên cảnh và là phim trường của Tây Du Ký, Avatar nổi tiếng toàn thế
          giới, du khách sẽ trầm trồ trước khung cảnh hùng tráng của thiên nhiên
          nơi đây hay thử lòng can đảm khi dạo bước trên hành lang kính trong
          suốt bên dưới là vực sâu đầy thú vị. Đặc biệt đây là hành trình chuyến
          bay thẳng từ Tp Hồ Chí Minh đến Trương Gia Giới giúp tiết kiệm thời
          gian quá cảnh từ 4 – 6 tiếng so với hành trình thông thường.
        </p>
        <p class="mb-0">Điểm nhấn</p>
        <ul>
          <li>
            Khách sạn 5* theo chuẩn địa phương với tour khởi hành trong tháng 04
            & 05.
          </li>
          <li>Tham quan Thiên Môn Sơn cung đường với 99 khúc cua ngoạn mục.</li>
          <li>
            Cảm nhận vẻ đẹp hùng vĩ của Hành lang Quỷ Cốc, khám phá động Thiên
            Môn, chinh phục con đường 99 khúc quanh.
          </li>
          <li>Tham quan Núi Thiên Tử đây là một kỳ quan của Trương Gia giới</li>
          <li>
            Tham quan Khu bảo tồn quốc gia Trương Gia Giới (Viên Gia Giới + Núi
            Thiên Tử)
          </li>
          <li>Trải nghiệm đi thuyền ngắm cảnh hai bên dòng sông Đà Giang.</li>
          <li>Ngồi tàu lửa tham quan Thập Lý Họa Lang</li>
          <li>
            Thăm Hồ Bảo Phong là một hồ nước ngọt trên núi nằm trong khu thắng
            cảnh Vũ Lăng Nguyên
          </li>
        </ul>
      </div>
    </div>
  </div>

  <!-- <div class="TourDetails__calendar">
        <h2>Lịch trình</h2>
    </div> -->

  <div class="TourDetails__info">
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
                <tr>
                  <td>Người lớn (Từ 12 tuổi trở lên)</td>
                  <td class="price">16,990,000 đ</td>
                </tr>
                <tr>
                  <td>Trẻ em (Từ 2 tuổi đến dưới 12 tuổi)</td>
                  <td class="price">15,291,000 đ</td>
                </tr>
                <tr>
                  <td>Em bé (Dưới 2 tuổi)</td>
                  <td class="price">8,495,000 đ</td>
                </tr>
                <tr>
                  <td>Phụ thu phòng đơn</td>
                  <td class="price">0 đ</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="col-12 col-md-6">
          <h2>Thông tin hướng dẫn viên</h2>
          <div class="TourDetails__info--item">
            <p class="title">
              HDV dẫn đoàn
              <span>TẤT VĂN CƠ</span>
            </p>
            <p class="address">
              190 Pasteur, Vo Thi Sau Ward, District 3, HCM City, Viet Nam
            </p>
            <p class="mobile">0903704682</p>
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
          <h2 class='text-primary'>Danh sách lựa chọn</h2>
          <div class="col-12 my-2">
            <table class="table caption-top">
              <tbody>
                <tr>
                  <td colspan="2" class='fs-4 fst-italic'>
                    <span id="OptionName_1">
                      {{products.tourName}}
                    </span>
                  </td>
                  <td></td>
                  <td></td>
                  <td class="d-flex justify-content-end">
                    <span class="px-2 fs-4 fst-italic" id="optionPrice_1">{{ formatter.format(products.price) }}</span>
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
                <span class="px-2" id="TotalPriceService">{{ formatter.format(products.price) }}</span>
              </div>
            </div>
          </div>
          <div class="col-12 d-flex justify-content-center">
            <button
              type="submit"
              id="btn-order"
              class="btn btn-danger text-uppercase btn-lg"
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
export default {
  name: "details-id",
  data() {
    return {
      products: [],
      formatter: new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }),
    };
  },
  mounted() {
    // eslint-disable-next-line no-undef
    $(document).ready(function () {
      // eslint-disable-next-line no-undef
      $(".owl-carousel").owlCarousel({
        center: true,
        loop: true,
        margin: 20,
        responsive: {
          0: {
            items: 2,
          },
          600: {
            items: 2,
          },
          1000: {
            items: 5,
          },
        },
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
      });
    });
    this.getAllItem(this.$route.params.id);
    // console.log(this.$route.params.id);
  },
  methods: {
    getAllItem(id) {
      // eslint-disable-next-line
      axios
        .get(`/api/Tour/${id}`)
        .then((response) => {
          // handle success
          this.products = response.data;
          console.log(this.products);
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
@import "@/assets/scss/_details.scss";
@import "@/assets/scss/_carousel.scss";
</style>
