import baseApi from "./../base-api";

const courseApi = {
  getAllCourse: async () => {
    return await baseApi.get("Courcse/GetCourses");
  },
}

export { courseApi };
