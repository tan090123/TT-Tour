import createPersistedState from "vuex-persistedstate";
import { createStore } from "vuex";
import actions from "./actions";
import mutations from "./mutations";
import state from "./state";
import getters from "./getters";

// Create a new store instance.
const store = createStore({
  state,
  getters,
  mutations,
  actions,
  plugins: [
    createPersistedState(), // Sử dụng vuex-persistedstate
  ],
});
export default store;
