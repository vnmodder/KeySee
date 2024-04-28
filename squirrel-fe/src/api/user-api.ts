import baseApi from './base-api';

export default {
    getAllUser: async () => {
      return await baseApi.get('User/user-information-list');
    },
};