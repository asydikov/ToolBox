import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IdentityService } from '../_services/identity.service';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private identityService: IdentityService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to api url
        const currentUser = this.identityService.currentUserValue;
        const isLoggedIn = currentUser && this.identityService.accesTokenFromLocalStorage;
        const isApiUrl = request.url.startsWith(environment.apiUrl);
        if (isLoggedIn && isApiUrl) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.identityService.accesTokenFromLocalStorage}`
                }
            });
        }

        return next.handle(request);
    }
}