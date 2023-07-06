const Tours = {
  state() {
    return {
      // Trạng thái của module
      tours: null,
    };
  },
  mutations: {
    // Mutations để thay đổi trạng thái
    setTours(state, newTours) {
      state.tours = newTours;
    },
  },
  actions: {
    // Actions để thực hiện các hoạt động bất đồng bộ
    fetchTours({ commit }) {
      //----------Product By ID-----------
      // eslint-disable-next-line
      axios
        .get(`/api/Tour/`)
        .then((response) => {
          // handle success
          const tours = response.data;
          tours.forEach((tour) => {
            tour.tourImage = `http://localhost:8080/api/Upload/${tour.tourImage}`;
          });
          commit("setTours", tours);
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });
    },
  },
};
export default Tours;
