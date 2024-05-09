<template>
    
</template>

<script  setup lang="ts">
import Cookies from 'js-cookie'
import { userStore } from '../../stores/auth';
import { useRouter } from 'vue-router';
import { storeToRefs } from 'pinia';

const router = useRouter();


const userSt = userStore();
const { user } = storeToRefs(userSt);

const logout = async () => {
    await userSt.logout();
    Cookies.remove('token')
    //router.push('/login')
};

</script>