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
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'QLDT_App',
    responseType: 'code',
    scope: "openid AuthServer IdentityService AdministrationService SaaSService ProjectService",
    requireHttps: true,
    dummyClientSecret: '',
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'QLDT',
    },
  },
} as Environment;
