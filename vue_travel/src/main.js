import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/index.js';
// import { VueRecaptchaPlugin } from 'vue-recaptcha';
import axios from 'axios';
window.axios = axios;

import "@/assets/scss/_reset.scss";

const app = createApp(App);
app.use(router)
app.mount('#app')
