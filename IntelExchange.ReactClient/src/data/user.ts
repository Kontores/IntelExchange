import { UserRole } from './enums/user-role';

export type UserLoginData = {
    login: string;
    password: string;
}

export type User = UserLoginData & {
    id: string;
    type: string;
    profile: IndividualProfile | CompanyProfile;
    roles: UserRole[];
};

export type UserProfile = {
    userId: string;
    email: string;
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
