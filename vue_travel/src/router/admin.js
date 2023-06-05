const admin = [
    {
        path: '/admin',
        name: 'HomeAdmin',
        component: () => import("@/layout/Admin.vue"),
        meta: { title: 'Trang admin - Vietravel' },
        children: [
            {
                path: '/admin',
                name: 'HomeAdmin',
                component: () => import("@/pages/admin/AdminHome.vue"),
                meta: { title: 'Trang admin - Vietravel' }
            },
            {
                path: 'user',
                name: 'user',
                component: () => import("@/pages/admin/User.vue"),
                meta: { title: 'Thông tin - Vietravel ' }
            },
        ]
    }
]

export default admin;