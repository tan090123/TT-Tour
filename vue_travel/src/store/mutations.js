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
  setTourType(state, newTourType) {
    state.TourType = newTourType;
  },
  setServicesTour(state, newServicesTour) {
    state.ServicesTour = newServicesTour;
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
};
