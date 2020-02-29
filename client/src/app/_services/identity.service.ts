import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { SignIn } from '../_models/sign-in';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';
import { JsonWebToken } from '../_models/json-web-token';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
   }

  signIn(email:string, password:string) {
    debugger
    let signInModel = new SignIn(email, password);
    return this.http.post<JsonWebToken>(`${environment.apiUrl}/${environment.identityService}/sign-in`, signInModel)
        .pipe(map(token => {
          debugger
            // login successful if there's a jwt token in the response
            if (token && token.accessToken) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('userToken', JSON.stringify(token));
                this.currentUserSubject.next(new User(token.claims.email, token.claims.name));
            } else {
              token = null;
            }
            return token;
        }));
}

// register(email: string, password: string, name: string) {
//     let user = new User();
//     user.email = email;
//     user.name = name;
//     user.password = password;
//     return this.http.post<User>(`${environment.apiUrl}${UrlEnum.User}user`, user)
//         .pipe(map(user => {
//             // login successful if there's a jwt token in the response
//             if (user && user.token) {
//                 // store user details and jwt token in local storage to keep user logged in between page refreshes
//                 localStorage.setItem('currentUser', JSON.stringify(user));
//                 this.currentUserSubject.next(user);
//             } else {
//                 user.token = null;
//             }
//             return user;
//         }));
// }

// logout() {
//     // remove user from local storage to log user out
//     localStorage.removeItem('currentUser');
//     this.currentUserSubject.next(null);
// }
 }
