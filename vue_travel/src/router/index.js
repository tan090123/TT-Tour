import { createRouter, createWebHistory } from 'vue-router';
import home from './home.js';
import admin from './admin.js';

const routes = [...home,...admin]

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