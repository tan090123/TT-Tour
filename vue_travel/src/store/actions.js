export default {
  fetchTourOrder({ commit }, { id }) {
    //----------Product By ID-----------
    // eslint-disable-next-line
    axios
      .get(`/api/Tour/${id}`)
      .then((response) => {
        // handle success
        commit("setTour", response.data);
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

    //---------TourServices------------
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
  },
  fetchTourDetails({ commit }, { id }) {
    //----------Product By ID-----------
    // eslint-disable-next-line
    axios
      .get(`/api/Tour/${id}`)
      .then((response) => {
        // handle success
        commit("setTour", response.data);
      })
      .catch((error) => {
        // handle error
        console.log(error);
      });

    //---------------------Get TourGuide-------------

    // eslint-disable-next-line no-undef
    axios
      .get(`/api/TourGuide/id?tourID=${id}`)
      .then((response) => {
        commit("setTourGuide", response.data);
      })
      .catch((error) => {
        // handle error
        console.log(error);
      });

    //---------------------Get TourServices-------------
    // eslint-disable-next-line no-undef
    axios
      .get(`/api/ServicesTour/id?tourID=${id}`)
      .then((response) => {
        commit("setServicesTour", response.data);
      })
      .catch((error) => {
        // handle error
        console.log(error);
      });

    //--------------------Get TourSchedule-------------
    // eslint-disable-next-line no-undef
    axios
      .get(`/api/TourSchedule/id?tourID=${id}`)
      .then((response) => {
        commit("setTourSchedule", response.data);
      })
      .catch((error) => {
        // handle error
        console.log(error);
      });
  },
  fetchTours({ commit }) {
    //----------Product By ID-----------
    // eslint-disable-next-line
    axios
      .get(`/api/Tour/`)
      .then((response) => {
        // handle success
        commit("setTours", response.data);
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
  async PlaceInfoContact({ state, commit }) {
    const InfoContactData = {
      TourID: state.infoContact.TourID,
      ContactName: state.infoContact.ContactName,
      ContactEmail: state.infoContact.ContactEmail,
      ContactPhone: state.infoContact.ContactPhone,
      ContactAddress: state.infoContact.ContactAddress,
    };

    // eslint-disable-next-line no-useless-catch
    try {
      // eslint-disable-next-line
      const InfoContact = await axios.post(`/api/InfoContact`, InfoContactData);
      // Xử lý phản hồi từ API sau khi đặt hàng thành công
      commit("SET_INFO_CONTACT", InfoContact.data);
    } catch (error) {
      // Xử lý lỗi nếu có
      throw error;
    }
  },
  async PlaceTourist({ state, commit }) {
    const TouristData = {
      touristType: state.Tourist.touristType,
      touristName: state.Tourist.touristName,
      touristSex: state.Tourist.touristSex,
      touristDate: state.Tourist.touristDate,
      touristPrice: state.Tourist.touristPrice,
      touristNote: state.Tourist.touristNote,
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
};
