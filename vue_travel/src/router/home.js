const home = [
  {
    path: "/",
    name: "Home",
    component: () => import("@/layout/Home.vue"),
    meta: { title: "Du Lịch Vietravel - Vietravel" },
    children: [
      {
        path: "/",
        name: "HomePage",
        component: () => import("@/pages/home/HomePage.vue"),
        meta: { title: "Du Lịch Vietravel - Vietravel" },
      },
      {
        path: "/booking",
        name: "booking-id",
        component: () => import("@/pages/home/TourOrder.vue"),
        meta: { title: "Thông tin - Vietravel " },
        children: [
          {
            path: "tourID=:tourID",
            name: "booking-id",
            //
          },
        ],
      },
      {
        path: "/booking/ShowBooking",
        name: "inforBooking-id",
        component: () => import("@/pages/home/ShowBooking.vue"),
        meta: { title: "Thông tin chi tiết Booking - Vietravel" },
        children: [
          {
            path: "bookingID=:bookingID",
            name: "inforBooking-id",
            //
          },
        ],
      },

      {
        path: "/contact",
        name: "contact",
        component: () => import("@/pages/home/Contact.vue"),
        meta: { title: "Contact - Vietravel " },
      },
      {
        path: "/login",
        name: "login_component",
        component: () => import("@/components/TheLogin.vue"),
        meta: { title: "Đăng nhập - Vietravel" },
      },
      {
        path: "/register",
        name: "register_component",
        component: () => import("@/components/TheRegister.vue"),
        meta: { title: "Đăng ký - Vietravel" },
      },
      {
        path: "/forgot_password",
        name: "forgotPass_component",
        component: () => import("@/components/ForgotPass.vue"),
        meta: { title: "Đăng ký - Vietravel" },
      },
      {
        path: "/tours",
        name: "tours_page",
        component: () => import("@/pages/home/TourPage.vue"),
        meta: { title: "Danh sách các Tour - Vietravel" },
      },
      {
        path: "/user/password",
        name: "password",
        component: () => import("@/components/AppPassword.vue"),
        meta: { title: "Thay đổi mật khẩu - Vietravel" },
      },
      {
        path: "/search/:departure/:destination/:datetime/:numberDay",
        name: "tours_search",
        component: () => import("@/pages/home/TourSearch.vue"),
        meta: { title: "Kết quả tìm kiếm - Vietravel" },
        children: [
          {
            path: "tourtype=:tourtype",
            name: "tours_search",
            children: [
              {
                path: "SoNguoi=:people",
                name: "tours_search",
                //
              },
            ],
          },
        ],
      },
      {
        path: "/tours/details/:id",
        name: "details-id",
        component: () => import("@/pages/home/TourDetails.vue"),
        meta: { title: "Du Lịch Vietravel - Vietravel" },
      },
    ],
  },
];

export default home;
