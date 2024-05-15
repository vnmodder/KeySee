import { createRouter, createWebHistory } from 'vue-router'
import {Login,RegisterView} from '@/views'
import adminRoutes from "./admin.router";
import userRoutes from "./user.router";


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login,
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView,
    },
    {...adminRoutes},
    {...userRoutes},
  ]
})

export default router
