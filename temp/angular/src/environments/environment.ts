import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'QLDT',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385/',
    redirectUri: baseUrl,
    clientId: 'QLDT_App',
    responseType: 'code',
    scope: 'offline_access QLDT',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44386',
      rootNamespace: 'QLDT',
    },
  },
} as Environment;
