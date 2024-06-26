import type { UserInfoModel } from '@/models/user-model';
import { defineStore } from 'pinia';
import { ref } from 'vue'

export const userStore =  defineStore({
    id: 'auth',
    state: () => ({
        // initialize state from local storage to enable user to stay logged in
        user: JSON.parse(localStorage.getItem('user')?.toString()??"null") as UserInfoModel | null,
    }),
    actions: {
        async login(user:UserInfoModel) {
            try {
                this.user = user;
                localStorage.setItem('user', JSON.stringify(user));
            } catch (error) {
                alert(error);                
            }
        },
        async logout() {
            this.user = null;
            localStorage.removeItem('user');
        }
    }
});