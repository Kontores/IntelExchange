import axios from 'axios';
import { RoutesEnum } from '../data/enums/routes';
import { history } from '../store/configureStore';

const apiService = axios.create({
    baseURL: process.env.REACT_APP_API_URL
});

apiService.interceptors.response.use((response) => { return response }, (error) => {
    if (axios.isAxiosError(error)) {
        if(error.response?.status === 401 || error.response?.status === 403) {
            history.replace(RoutesEnum.login);
        }
        if (error.response?.status === 404) {
            history.replace(RoutesEnum.home);
        }
    }

    return Promise.reject(error);
});


export default apiService;



