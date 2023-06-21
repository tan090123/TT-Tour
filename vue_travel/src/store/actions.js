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
  fetchTServices({ commit }) {
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
  GetTInfoContact({ commit },{info}) {
    //---------TourServices------------
    // eslint-disable-next-line
    axios
      .post(`/api/TServices`, info)
      .then((response) => {
        // handle success
        commit("getInfoContact", response.data);
      })
      .catch((error) => {
        // handle error
        console.log(error);
      });
  },
};
