const ShowBooking = {
  state() {
    return {
      // Trạng thái của module
      tour: null,
      TServices: null,
      TristType_price: null,
      infoContact: {
        contactID: "",
        TourID: "",
        ContactName: "",
        ContactEmail: "",
        ContactPhone: "",
        ContactAddress: "",
        ContactNote: "",
      },
      Tourist: {
        touristID: "",
        touristType: "",
        touristName: "",
        touristSex: "",
        touristDate: "",
        touristPrice: "",
        servicesPrice: "",
        bookingID: "",
      },
      Booking: {
        bookingID: "",
        tourID: "",
        infoContactID: "",
        userID: "",
        extraPrice: "",
        currentPrice: "",
        totalPrice: "",
        payment: "",
        status: "",
        tourCheckinDays: "",
        tourCheckoutDays: "",
        departure: "",
        destination: "",
        bookingName: "",
        bookingDay: "",
      },
    };
  },
  mutations: {
    // Mutations để thay đổi trạng thái
    setTour(state, newTours) {
      state.tour = newTours;
    },
    SET_Booking(state, booking) {
      state.Booking = booking;
    },
    SET_INFO_CONTACT(state, infoContact) {
      state.infoContact = infoContact;
    },
    SET_Tourist(state, tourist) {
      state.Tourist = tourist;
    },
    setTristType_price(state, newTristType_price) {
      state.TristType_price = newTristType_price;
    },
  },
  actions: {
    // Actions để thực hiện các hoạt động bất đồng bộ

    async fetchBooking({ commit }, { bookingID, tourID, infoContactID }) {
      try {
        // eslint-disable-next-line no-undef
        const bookingResponse = await axios.get(`/api/Bookings/${bookingID}`);
        commit("SET_Booking", bookingResponse.data);

        // eslint-disable-next-line no-undef
        const tourResponse = await axios.get(`/api/Tour/${tourID}`);
        commit("setTour", tourResponse.data);

        // eslint-disable-next-line no-undef
        const infoContactResponse = await axios.get(
          `/api/InfoContact/${infoContactID}`
        );
        commit("SET_INFO_CONTACT", infoContactResponse.data);

        // eslint-disable-next-line no-undef
        const touristResponse = await axios.get(
          `/api/Tourist?bookingID=${bookingID}`
        );
        commit("SET_Tourist", touristResponse.data);

        // eslint-disable-next-line no-undef
        const touristTypePriceResponse = await axios.get(
          `/api/TouristType_price/id?tourID=${tourID}`
        );
        commit("setTristType_price", touristTypePriceResponse.data);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
export default ShowBooking;
