import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router';
// import { createRouter, createWebHistory } from 'vue-router';


import "./scss/_reset.scss"

// const router = createRouter(
//     {
//         history: createWebHistory(),
//         routes: [
//             {
//                 path: '/',
//                 name: 'HomePage',
//                 component: () => import("@/Views/Page/HomePage.vue"),
//             },
//             {
//                 path: '/contact',
//                 name: 'Contact',
//                 component: () => import("@/Views/Page/Contact.vue"),
//             }
//         ]
//     }
// )

createApp(App)
    .use(router)
    .mount('#app')
