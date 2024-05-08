import {Layout, HomeView,NotFound,About } from '@/views/user';

export default {
    path: '',
    component: Layout,
    children: [
        {
            path: '',
            name: 'home',
            component: HomeView
          },
          {
            path:':pathMatch(.*)*',
            name:'not-found',
            component: NotFound
          },
          {
            path: 'about',
            name: 'about',
            component: About
          },
    ]
};