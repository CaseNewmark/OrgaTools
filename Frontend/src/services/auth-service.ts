import { ref } from "vue";
import { msalInstance, state } from "../config/auth";

export const isAuthenticated = ref(false);

export const login = async() => {
    if (!msalInstance) {
        throw new Error("MSAL instance is not initialized.");
    }
    await msalInstance.loginRedirect();
    isAuthenticated.value = true;
}

export const logout = () => {
    if (!msalInstance) {
        throw new Error("MSAL instance is not initialized.");
    }
    msalInstance.logoutRedirect();
    isAuthenticated.value = false;
}

export const handleRedirect = async () => {
    if (!msalInstance) {
        throw new Error("MSAL instance is not initialized.");
    }
    await msalInstance.handleRedirectPromise();
    const accounts = msalInstance.getAllAccounts();
    if (accounts.length > 0) {
        state.isAuthenticated = true;
        state.user = accounts[0];
    }
    else {
        state.isAuthenticated = false;
    }
}