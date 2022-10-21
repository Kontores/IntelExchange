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

    getLoggedUser(): Promise<User> {
        return apiService.get("account/getloggeduser", { withCredentials: true }).then(result => { return result.data as User });
    }

    checkAdminPermission(): Promise<string> {
        return apiService.get("account/checkadminpermission", { withCredentials: true }).then(result => { return result.data as string });
    }
}
