import { defineStore } from 'pinia';
import { ref } from 'vue'

export const userStore = defineStore('user-store', () => {
    const user = ref(localStorage.getItem('user'));

    const setUserStore = (user: any) => {
        user.value = user;
        localStorage.setItem('user', user);
    }

    const removeUserStore = () => {
        user.value = null;
        localStorage.removeItem('user');
    }

    const checkLogin = ()=>{
        user.value = localStorage.getItem('user')
        return user.value
    }

    return { user, setUserStore, removeUserStore, checkLogin }
});