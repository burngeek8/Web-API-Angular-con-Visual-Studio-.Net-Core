import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth';

const API_URL =
  'https://siscom-chd6bkbjfugxdpam.westcentralus-01.azurewebsites.net';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const token = inject(AuthService).getToken();

  if (token && req.url.startsWith(API_URL)) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  return next(req);
};
