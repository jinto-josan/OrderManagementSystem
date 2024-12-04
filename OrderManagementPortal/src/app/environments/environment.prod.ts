export const environment = {
    production: true,
    msalConfig: {
      auth: {
        clientId: 'your-client-id',
        authority: 'https://login.microsoftonline.com/your-tenant-id',
        redirectUri: 'https://your-production-url.com'
      }
    }
  };
  