import baseApi from '../base-api';

const userAPI ={
    getAllCourse: async () => {
        return await baseApi.get('Courcse/GetCourses');
      },
}

export{
    userAPI,
}