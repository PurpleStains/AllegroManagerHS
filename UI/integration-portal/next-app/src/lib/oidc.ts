import axios from "axios";

const params = {
  client_id: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_ID || "",
  client_secret: process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT_SECRET || "",
  grant_type: "refresh_token",
};

export const oidc = axios.create({
  baseURL: `${process.env.NEXT_PUBLIC_KEYCLOAK_ISSUER}/protocol/openid-connect`,
  headers: {
    "Content-Type": "application/x-www-form-urlencoded",
  },
  withCredentials: true,
});

export const refreshTokenRequest = (refresh_token: string) => {
  return oidc({
    method: "POST",
    url: "/token",
    data: new URLSearchParams({
      refresh_token,
      ...params,
    }),
  });
};

export const logoutRequest = (refresh_token: string) => {
  return oidc({
    method: "POST",
    url: "/logout",
    data: new URLSearchParams({
      refresh_token,
      ...params,
    }),
  });
};