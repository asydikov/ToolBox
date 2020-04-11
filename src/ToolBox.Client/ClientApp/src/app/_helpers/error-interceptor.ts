import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IdentityService } from '../_services/identity.service';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private  identityService: IdentityService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       return next.handle(request).pipe(catchError(err => {
            if ([401, 403].indexOf(err.status) !== -1) {
                this.identityService.logout();
            }

            const error = err.error.message || err.statusText;
            return throwError(error);
       }))
    }
}