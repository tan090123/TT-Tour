export default {
  setTour(state, newTour) {
    state.tour = newTour;
  },
  setTServices(state, newTServices) {
    state.TServices = newTServices;
  },
  setTours(state, newTours) {
    state.tours = newTours;
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
  getInfoContact(state, newInfoContact) {
    state.infoContact = newInfoContact;
  },
};