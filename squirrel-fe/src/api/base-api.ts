import axios from 'axios';
import Cookies from 'js-cookie'
import type { AxiosResponse } from 'axios';

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Hàm để lấy token JWT từ localStorage
function getToken() {
  return Cookies.get('token');
}

export default {
  get: async ( endpoint: string): Promise<AxiosResponse> => {
    const token = getToken();
    return await apiClient.get(`${endpoint}`, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  post: async ( endpoint: string, body: any): Promise<AxiosResponse> => {
    const token =  getToken();
    return await apiClient.post(`${endpoint}`, body, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  postAuthenticate: async (endpoint: string, body: any): Promise<AxiosResponse> => {
    return await apiClient.post(`${endpoint}`, body);
  },

  put: async (endpoint: string, body: any): Promise<AxiosResponse> => {
    const token = getToken();
    return await apiClient.put(`${endpoint}`, body, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  delete: async (endpoint: string): Promise<AxiosResponse> => {
    const token = getToken();
    return await apiClient.delete(`${endpoint}`, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },
};