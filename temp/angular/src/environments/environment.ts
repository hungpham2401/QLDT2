import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Tasky',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385/',
    redirectUri: baseUrl,
    clientId: 'Tasky_App',
    responseType: 'code',
    scope: 'offline_access Tasky',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44386',
      rootNamespace: 'Tasky',
    },
  },
} as Environment;
