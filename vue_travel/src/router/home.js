

const home = [
    {
        path: '/',
        name: 'Home',
        component: () => import("@/layout/Home.vue"),
        meta: { title: 'Du Lịch Vietravel - Vietravel' },
        children: [
            {
                path: '/',
                name: 'HomePage',
                component: () => import("@/pages/home/HomePage.vue"),
                meta: { title: 'Du Lịch Vietravel - Vietravel' }
            },
            {
                path: '/order',
                name: 'contact',
                component: () => import("@/pages/home/TourOrder.vue"),
                meta: { title: 'Thông tin - Vietravel ' }
            },
            // {
            //     path: '/contact',
            //     name: 'contact',
            //     component: () => import("@/pages/home/Contact.vue"),
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
                component: () => import("@/pages/home/TourPage.vue"),
                meta: { title: 'Danh sách các Tour - Vietravel' }
            },
            // {
            //     path: '/',
            //     name: 'HomePage',
            //     component: () => import("@/pages/home/TourSearch.vue"),
            //     meta: { title: '- Vietravel' }
            // },
            // {
            //     path: '/tours/details',
            //     name: 'details',
            //     component: () => import("@/pages/home/TourDetails.vue"),
            //     meta: { title: 'Du Lịch Vietravel - Vietravel' }
            // },
            {
                path: '/tours/details/:id',
                name: 'details-id',
                component: () => import("@/pages/home/TourDetails.vue"),
                meta: { title: 'Du Lịch Vietravel - Vietravel' }
            },
        ]
    }
]



export default home;