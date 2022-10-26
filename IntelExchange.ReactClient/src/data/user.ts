import { UserRole } from './enums/user-role';
import { UserType } from './enums/user-type';

export type UserLoginModel = {
    login: string;
    password: string;
};

export type User = UserLoginModel & {
    id: string;
    type: UserType;
    profile: IndividualProfile | CompanyProfile;
    roles: UserRole[];
};

export type UserProfile = {
    userId: string;
    email: string;
    phoneNumber: string;
};

export type IndividualProfile = UserProfile & {
    firstName: string;
    lastName: string;
};

export type CompanyProfile = UserProfile & {
    companyName: string;
    companyForm: string;
    postAddress: string;
    itin: string;
};
