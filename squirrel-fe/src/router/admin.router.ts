import {Layout, HomeView,AboutView,CategoryView, CourseView,TestDialog } from '@/views/admin';

export default {
    path: '/admin',
    component: Layout,
    children: [
        { path: '', component: HomeView },
        { path: 'about', component: AboutView },
        { path: 'category', component: CategoryView },
        { path: 'course', component: CourseView },
        { path: 'test', component: TestDialog },
    ]
};