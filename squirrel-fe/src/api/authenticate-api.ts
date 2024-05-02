import type { LoginModel, LoginResponseModel } from '@/models/user-model';
import baseApi from './base-api';

export default {
    login: async (model: LoginModel) : Promise<LoginResponseModel|undefined> => {
      const response= await baseApi.postAuthenticate('Authenticate/Login', model);
      if(response.status == 200){
        const loginResponse: LoginResponseModel = {
          userInfo: response.data.result.userInfo,
          email: response.data.result.email,
          token: response.data.result.token,
          expiration: response.data.result.expiration,
          roles: response.data.result.roles
      };

      return loginResponse;
      }
    },

    logout:()=>{
        baseApi.postAuthenticate("Authenticate/Logout",null);
    }
};

