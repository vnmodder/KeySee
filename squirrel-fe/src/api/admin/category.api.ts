import baseApi from "./../base-api";

const categoryApi = {
  getAllCategory: async () => {
    return await baseApi.get("Category/getCategories");
  },
  addAllCategory: async (data: any) => {
    return await baseApi.post("Category/addCategory", data);
  },
  deleteCategory: async (data: any) => {
    return await baseApi.post("Category/deleteCategory", data);
  },
}

export { categoryApi };
