import { defineStore } from 'pinia';
import { ref } from 'vue'

export const userStore =  defineStore({
    id: 'auth',
    state: () => ({
        // initialize state from local storage to enable user to stay logged in
        user: JSON.parse(localStorage.getItem('user')?.toString()??"null"),
    }),
    actions: {
        async login(user:any) {
            try {
                this.user = user;
                localStorage.setItem('user', JSON.stringify(user));
            } catch (error) {
                alert(error);                
            }
        },
        logout() {
            this.user = null;
            localStorage.removeItem('user');
        }
    }
});