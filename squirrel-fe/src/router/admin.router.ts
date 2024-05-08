import {Layout, HomeView,AboutView } from '@/views/admin';

export default {
    path: '/admin',
    component: Layout,
    children: [
        { path: '', component: HomeView },
        { path: 'about', component: AboutView },

    ]
};