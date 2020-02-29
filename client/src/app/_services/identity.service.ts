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
    this.currentUserSubject = new BehaviorSubject<User>(this.userFromLocalStorage);
    this.currentUser = this.currentUserSubject.asObservable();
   }

   public get currentUserValue(): User {
    return this.currentUserSubject.value;
}

public get tokenFromLocalStorage():string{
  let userToken = this.userTokenFromLocalStorage;
  let token = userToken?.accessToken;
  if(!userToken || !token )
  {
    return null;
  }
return token;
}

private get userFromLocalStorage():User{
  let userToken = this.userTokenFromLocalStorage;
  let userName = userToken?.claims.name ??'';
  let userEmail =  userToken?.claims.email ?? '';
  if(!userToken || !userName || !userEmail)
  {
    return null;
  }
return new User(userName, userEmail);
}

private get userTokenFromLocalStorage():JsonWebToken{
  return JSON.parse(localStorage.getItem('userToken'));
}

  signIn(email:string, password:string) {
    let signInModel = new SignIn(email, password);
    return this.http.post<JsonWebToken>(`${environment.apiUrl}/${environment.identityService}/sign-in`, signInModel)
        .pipe(map(token => {
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

logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('userToken');
    this.currentUserSubject.next(null);
}
 }
