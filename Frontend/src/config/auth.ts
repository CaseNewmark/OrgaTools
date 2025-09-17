import { PublicClientApplication, type AccountInfo, type RedirectRequest } from "@azure/msal-browser";
import { reactive } from "vue";

const msalConfig = {
    auth: {
        clientId: "<client-id-from-azure-ad-app-registration>",
        authority: "https://login.microsoftonline.com/<tenant-id-or-name>",
        redirectUri: "http://localhost:5173"
    },
    cache: {
        cacheLocation: "sessionStorage",
        storeAuthStateInCookie: true
    }
};

export const scopes: RedirectRequest = {
    scopes: ['user.read', 'profile', 'email']
};

export const state = reactive({
    isAuthenticated: false,
    user: null as AccountInfo | null
});

export const msalInstance = new PublicClientApplication(msalConfig);