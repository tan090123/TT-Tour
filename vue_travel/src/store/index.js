import createPersistedState from "vuex-persistedstate";
import { createStore } from "vuex";

import TourDetails from "@/store/modules/TourDetails";
import Tours from "@/store/modules/Tours";
import TourOrder from "@/store/modules/TourOrder";
import ShowBooking from "./modules/ShowBooking";

// Create a new store instance.
const store = createStore({
  modules: {
    details: TourDetails,
    tourlist: Tours,
    order: TourOrder,
    showbooking: ShowBooking,
  },
  plugins: [
    createPersistedState(), // Sử dụng vuex-persistedstate
  ],
});
export default store;
