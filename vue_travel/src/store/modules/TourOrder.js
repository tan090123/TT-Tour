const TourOrder = {
  state() {
    return {
      // Trạng thái của module
      TServices: null,
      TristType_price: null,
      TourType: null,
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
      Tourist_TouristServices: {
        servicesID: "",
        touristID: "",
        tServicesID: "",
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
    setTour(state, newTour) {
      state.tour = newTour;
    },
    setTourType(state, newTourType) {
      state.TourType = newTourType;
    },
    setTristType_price(state, newTristType_price) {
      state.TristType_price = newTristType_price;
    },
    SET_INFO_CONTACT(state, infoContact) {
      state.infoContact = infoContact;
    },
    SET_Tourist(state, tourist) {
      state.Tourist = tourist;
    },
    SET_Tourist_TouristServices(state, newTourist_TouristServices) {
      state.Tourist_TouristServices = newTourist_TouristServices;
    },
    SET_Booking(state, booking) {
      state.Booking = booking;
    },
    setTServices(state, newTServices) {
      state.TServices = newTServices;
    },
  },
  actions: {
    // Actions để thực hiện các hoạt động bất đồng bộ
    fetchTourOrder({ commit }, { id, tourtype }) {
      //----------Product By ID-----------
      // eslint-disable-next-line
      axios
        .get(`/api/Tour/${id}`)
        .then((response) => {
          // handle success
          const ResponseData = response.data;
          const img = `http://localhost:8080/api/Upload/${ResponseData.tourImage}`;
          ResponseData.tourImage = img;
          commit("setTour", ResponseData);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });

      // eslint-disable-next-line
      axios
        .get(`/api/TServices`)
        .then((response) => {
          // handle success
          commit("setTServices", response.data);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });

      //----------TouristType_price-----------
      // eslint-disable-next-line
      axios
        .get(`/api/TouristType_price/id?tourID=${id}`)
        .then((response) => {
          // handle success
          commit("setTristType_price", response.data);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });

      //---------TourType------------
      // eslint-disable-next-line
      axios
        .get(`/api/TourType/${tourtype}`)
        .then((response) => {
          // handle success
          commit("setTourType", response.data);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });
    },

    //------------------------Order-----------------------

    //---Info Contact---------
    setInfoContact({ commit }, infoContact) {
      commit("SET_INFO_CONTACT", infoContact);
    },
    //-----Tourist-------
    setTourist({ commit }, tourist) {
      commit("SET_Tourist", tourist);
    },
    //-----Booking-------
    setBooking({ commit }, booking) {
      commit("SET_Booking", booking);
    },
    //---------Tourist_TouristServices--------
    setTourist_TouristServices({ commit }, tourist_TouristServices) {
      commit("SET_Tourist_TouristServices", tourist_TouristServices);
    },
    async PlaceInfoContact({ state, commit }) {
      const InfoContactData = {
        contactID: state.infoContact.contactID,
        TourID: state.infoContact.TourID,
        ContactName: state.infoContact.ContactName,
        ContactEmail: state.infoContact.ContactEmail,
        ContactPhone: state.infoContact.ContactPhone,
        ContactAddress: state.infoContact.ContactAddress,
        ContactNote: state.infoContact.ContactNote,
      };

      // eslint-disable-next-line no-useless-catch
      try {
        // eslint-disable-next-line
        const InfoContact = await axios.post(
          `/api/InfoContact`,
          InfoContactData
        );
        // Xử lý phản hồi từ API sau khi đặt hàng thành công
        commit("SET_INFO_CONTACT", InfoContact.data);
      } catch (error) {
        // Xử lý lỗi nếu có
        throw error;
      }
    },
    async PlaceTourist({ state, commit }) {
      const TouristData = {
        touristID: state.Tourist.touristID,
        bookingID: state.Tourist.bookingID,
        touristType: state.Tourist.touristType,
        touristName: state.Tourist.touristName,
        touristSex: state.Tourist.touristSex,
        touristDate: state.Tourist.touristDate,
        touristPrice: state.Tourist.touristPrice,
        servicesPrice: state.Tourist.servicesPrice,
      };

      // eslint-disable-next-line no-useless-catch
      try {
        // eslint-disable-next-line
        const Tourist = await axios.post(`/api/Tourist`, TouristData);
        // Xử lý phản hồi từ API sau khi đặt hàng thành công
        commit("SET_Tourist", Tourist.data);
      } catch (error) {
        // Xử lý lỗi nếu có
        throw error;
      }
    },
    async PlaceBooking({ state, commit }) {
      const BookingData = {
        bookingID: state.Booking.bookingID,
        tourID: state.Booking.tourID,
        infoContactID: state.Booking.infoContactID,
        userID: state.Booking.userID,
        extraPrice: state.Booking.extraPrice,
        currentPrice: state.Booking.currentPrice,
        totalPrice: state.Booking.totalPrice,
        payment: state.Booking.payment,
        status: state.Booking.status,
        tourCheckinDays: state.Booking.tourCheckinDays,
        tourCheckoutDays: state.Booking.tourCheckoutDays,
        departure: state.Booking.departure,
        destination: state.Booking.destination,
        bookingName: state.Booking.bookingName,
        bookingDay: state.Booking.bookingDay,
      };

      // eslint-disable-next-line no-useless-catch
      try {
        // eslint-disable-next-line
        const Booking = await axios.post(`/api/Bookings`, BookingData);
        // Xử lý phản hồi từ API sau khi đặt hàng thành công
        commit("SET_Booking", Booking.data);
      } catch (error) {
        // Xử lý lỗi nếu có
        throw error;
      }
    },
    async PlaceTourist_TouristServices({ state, commit }) {
      const Tourist_TouristServicesData = {
        servicesID: state.Tourist_TouristServices.servicesID,
        touristID: state.Tourist_TouristServices.touristID,
        tServicesID: state.Tourist_TouristServices.tServicesID,
      };

      // eslint-disable-next-line no-useless-catch
      try {
        // eslint-disable-next-line
        const Tourist_TouristServices = await axios.post(
          `/api/TouristServices`,
          Tourist_TouristServicesData
        );
        // Xử lý phản hồi từ API sau khi đặt hàng thành công
        commit("SET_Tourist_TouristServices", Tourist_TouristServices.data);
      } catch (error) {
        // Xử lý lỗi nếu có
        throw error;
      }
    },
  },
};
export default TourOrder;
