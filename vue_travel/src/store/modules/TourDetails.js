const TourDetails = {
  state() {
    return {
      // Trạng thái của module
      tour: null,
      TourSchedule: null,
      TourGuide: null,
      ServicesTour: null,
      TristType_price: null,
    };
  },
  mutations: {
    // Mutations để thay đổi trạng thái
    setTour(state, newTour) {
      state.tour = newTour;
    },
    setTourSchedule(state, newTourSchedule) {
      state.TourSchedule = newTourSchedule;
    },
    setTourGuide(state, newTourGuide) {
      state.TourGuide = newTourGuide;
    },
    setServicesTour(state, newServicesTour) {
      state.ServicesTour = newServicesTour;
    },
    setTristType_price(state, newTristType_price) {
      state.TristType_price = newTristType_price;
    },
  },
  actions: {
    // Actions để thực hiện các hoạt động bất đồng bộ
    async fetchTourDetails({ commit }, { id }) {
      try {
        // eslint-disable-next-line no-undef
        const tourResponse = await axios.get(`/api/Tour/${id}`);
        const ResponseData = tourResponse.data;
        const tourImage = `http://localhost:8080/api/Upload/${ResponseData.tourImage}`;
        ResponseData.tourImage = tourImage;
        commit("setTour", ResponseData);

        // eslint-disable-next-line no-undef
        const tourGuideResponse = await axios.get(
          `/api/TourGuide/id?tourID=${id}`
        );
        commit("setTourGuide", tourGuideResponse.data);

        // eslint-disable-next-line no-undef
        const servicesTourResponse = await axios.get(
          `/api/ServicesTour/id?tourID=${id}`
        );
        commit("setServicesTour", servicesTourResponse.data);

        // eslint-disable-next-line no-undef
        const tourScheduleResponse = await axios.get(
          `/api/TourSchedule/id?tourID=${id}`
        );
        commit("setTourSchedule", tourScheduleResponse.data);

        // eslint-disable-next-line no-undef
        const touristTypePriceResponse = await axios.get(
          `/api/TouristType_price/id?tourID=${id}`
        );
        commit("setTristType_price", touristTypePriceResponse.data);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
export default TourDetails;
