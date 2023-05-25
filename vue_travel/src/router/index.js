import { createRouter, createWebHistory } from 'vue-router';

const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: () => import("@/Views/Page/HomePage.vue"),
        meta: { title: 'Du Lịch Vietravel - Vietravel' }
    },
    {
        path: '/order',
        name: 'contact',
        component: () => import("@/Views/Page/TourOrder.vue"),
        meta: { title: 'Thông tin - Vietravel ' }
    },
    // {
    //     path: '/contact',
    //     name: 'contact',
    //     component: () => import("@/Views/Page/Contact.vue"),
    //     meta: { title: 'Contact - Vietravel ' }
    // },
    {
        path: '/login',
        name: 'login_component',
        component: () => import("@/components/TheLogin.vue"),
        meta: { title: 'Đăng nhập - Vietravel' }
    },
    {
        path: '/register',
        name: 'register_component',
        component: () => import("@/components/TheRegister.vue"),
        meta: { title: 'Đăng ký - Vietravel' }
    },
    {
        path: '/tours',
        name: 'tours_page',
        component: () => import("@/Views/Page/TourPage.vue"),
        meta: { title: 'Danh sách các Tour - Vietravel' }
    },
    // {
    //     path: '/',
    //     name: 'HomePage',
    //     component: () => import("@/Views/Page/TourSearch.vue"),
    //     meta: { title: '- Vietravel' }
    // },
    // {
    //     path: '/tours/details',
    //     name: 'details',
    //     component: () => import("@/Views/Page/TourDetails.vue"),
    //     meta: { title: 'Du Lịch Vietravel - Vietravel' }
    // },
    {
        path: '/tours/details/:id',
        name: 'details',
        component: () => import("@/Views/Page/TourDetails.vue"),
        meta: { title: 'Du Lịch Vietravel - Vietravel' }
    },
]



const router = createRouter(
    {
        history: createWebHistory(),
        routes
    }
)

router.beforeEach((to, from, next) => {
    document.title = to.meta.title || 'Your Default Title';
    next();
});

export default router;