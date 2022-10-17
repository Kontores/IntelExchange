import apiService from './api-service';
import { User, UserLoginData } from '../data/user';

export default class UserService {
    getAllUsers():Promise<User[]> {
        return apiService.get("users/getallusers")
            .then(result => { return result.data })
    }

    login(userLoginData: UserLoginData) {
        return apiService.post("account/login", userLoginData, {
            withCredentials: true
        });
    }

    getUserLogin(): Promise<string> {
        return apiService.get("account/getuserlogin", { withCredentials: true }).then(result => { return result.data as string });
    }
}
