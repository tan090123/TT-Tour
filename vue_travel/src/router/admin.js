const admin = [
    { path: '/admin', redirect: '/admin/dashboard' },
    {
        path: '/admin',
        name: 'admin',
        component: () => import("@/layout/Admin.vue"),
        meta: { title: 'Trang chủ admin - Vietravel' },
        children: [
            {
                path: 'dashboard',
                name: 'HomeAdmin',
                component: () => import("@/pages/admin/AdminHome.vue"),
                meta: { title: 'Trang chủ admin - Vietravel' }
            },
            {
                path: 'user',
                name: 'user-admin',
                component: () => import("@/pages/admin/User.vue"),
                meta: { title: 'Quản lý thông tin người dùng - Vietravel ' }
            },
            {
                path: 'tour',
                name: 'tour-admin',
                component: () => import("@/pages/admin/Tour.vue"),
                meta: { title: 'Quản lý danh sách Tour - Vietravel ' }
            },
            {
                path: 'tour/create',
                name: 'create-tour',
                component: () => import("@/pages/admin/CreateTour.vue"),
                meta: { title: 'Trang tạo tour - Vietravel ' }
            },
        ]
    }
]

export default admin;