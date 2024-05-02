import { createRouter, createWebHistory } from 'vue-router'
import {HomeView,NotFound,About,Login,RegisterView} from '@/views'



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path:'/:path(.*)*',
      name:'not-found',
      component: NotFound
    },
    {
      path: '/about',
      name: 'about',
      component: About
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
      // meta:{
      //   layout: 'empty'
      // }
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView,
    }
  ]
})

export default router
