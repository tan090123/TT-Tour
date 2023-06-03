import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router';
// import { VueRecaptchaPlugin } from 'vue-recaptcha';
import axios from 'axios';
window.axios = axios;


import "@/assets/scss/_reset.scss";

createApp(App)
    .use(router)
    .mount('#app')
