import { AxiosError } from "axios";

export type ValidationErrorResponse = {
    name: string;
    errors: Record<string, string>;
};

export const isServerSideValidationError = (error: AxiosError) => {
    const validationErrorResponse = error.response?.data as ValidationErrorResponse;

    return (validationErrorResponse?.name?.toLowerCase() === "validation error");
}

export const getServerSideValidationErrors = (error: AxiosError) => {
    const response = error.response?.data as ValidationErrorResponse;
    return response.errors;
}

export type ValidationState = {
    isValid: boolean;
    errors: Record<string, string>;
}

export interface IValidator<T> {
    validate: (model: T) => ValidationState;
};