import baseApi from './base-api';

export default {
    login: async (loginId: string, password: string) => {
      return await baseApi.postAuthenticate('Authenticate/Login', {
        loginId,
        password,
        rememberMe: true,
      });
    },

    logout:()=>{
        baseApi.postAuthenticate("Authenticate/Logout",null);
    }
};