export const environment = {
    production: false,
    msalConfig: {
      auth: {
        clientId: 'your-client-id',
        authority: 'https://login.microsoftonline.com/your-tenant-id',
        redirectUri: 'http://localhost:4200'
      }
    }
  };
  