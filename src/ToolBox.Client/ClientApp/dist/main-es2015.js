(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/_directives/click-stop-propagation.ts":
/*!*******************************************************!*\
  !*** ./src/app/_directives/click-stop-propagation.ts ***!
  \*******************************************************/
/*! exports provided: ClickStopPropagation */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClickStopPropagation", function() { return ClickStopPropagation; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");


class ClickStopPropagation {
    onClick(event) {
        //     event.stopPropagation();
        //    event.preventDefault();
    }
}
ClickStopPropagation.ɵfac = function ClickStopPropagation_Factory(t) { return new (t || ClickStopPropagation)(); };
ClickStopPropagation.ɵdir = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineDirective"]({ type: ClickStopPropagation, selectors: [["", "click-stop-propagation", ""]], hostBindings: function ClickStopPropagation_HostBindings(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function ClickStopPropagation_click_HostBindingHandler($event) { return ctx.onClick($event); });
    } } });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](ClickStopPropagation, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Directive"],
        args: [{
                selector: "[click-stop-propagation]"
            }]
    }], null, { onClick: [{
            type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["HostListener"],
            args: ["click", ["$event"]]
        }] }); })();


/***/ }),

/***/ "./src/app/_helpers/auth-guard.ts":
/*!****************************************!*\
  !*** ./src/app/_helpers/auth-guard.ts ***!
  \****************************************/
/*! exports provided: AuthGuard */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthGuard", function() { return AuthGuard; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");




class AuthGuard {
    constructor(router, identityService) {
        this.router = router;
        this.identityService = identityService;
    }
    canActivate(route, state) {
        const currentUser = this.identityService.currentUserValue;
        if (currentUser) {
            return true;
        }
        this.router.navigate(['/login']);
        return false;
    }
}
AuthGuard.ɵfac = function AuthGuard_Factory(t) { return new (t || AuthGuard)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"])); };
AuthGuard.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: AuthGuard, factory: AuthGuard.ɵfac, providedIn: 'root' });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AuthGuard, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{ providedIn: 'root' }]
    }], function () { return [{ type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"] }, { type: _services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/_helpers/error-interceptor.ts":
/*!***********************************************!*\
  !*** ./src/app/_helpers/error-interceptor.ts ***!
  \***********************************************/
/*! exports provided: ErrorInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ErrorInterceptor", function() { return ErrorInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");





class ErrorInterceptor {
    constructor(identityService) {
        this.identityService = identityService;
    }
    intercept(request, next) {
        return next.handle(request).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["catchError"])(err => {
            if ([401, 403].indexOf(err.status) !== -1) {
                this.identityService.logout();
            }
            const error = err.error.message || err.statusText;
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_1__["throwError"])(error);
        }));
    }
}
ErrorInterceptor.ɵfac = function ErrorInterceptor_Factory(t) { return new (t || ErrorInterceptor)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_3__["IdentityService"])); };
ErrorInterceptor.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: ErrorInterceptor, factory: ErrorInterceptor.ɵfac });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](ErrorInterceptor, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"]
    }], function () { return [{ type: _services_identity_service__WEBPACK_IMPORTED_MODULE_3__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/_helpers/jwt-interceptor.ts":
/*!*********************************************!*\
  !*** ./src/app/_helpers/jwt-interceptor.ts ***!
  \*********************************************/
/*! exports provided: JwtInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "JwtInterceptor", function() { return JwtInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");




class JwtInterceptor {
    constructor(identityService) {
        this.identityService = identityService;
    }
    intercept(request, next) {
        // add auth header with jwt if user is logged in and request is to api url
        const currentUser = this.identityService.currentUserValue;
        const isLoggedIn = currentUser && this.identityService.accesTokenFromLocalStorage;
        const isApiUrl = request.url.startsWith(src_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].apiUrl);
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
JwtInterceptor.ɵfac = function JwtInterceptor_Factory(t) { return new (t || JwtInterceptor)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"])); };
JwtInterceptor.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: JwtInterceptor, factory: JwtInterceptor.ɵfac });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](JwtInterceptor, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"]
    }], function () { return [{ type: _services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/_models/User.ts":
/*!*********************************!*\
  !*** ./src/app/_models/User.ts ***!
  \*********************************/
/*! exports provided: User */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "User", function() { return User; });
class User {
    /**
     *
     */
    constructor(email, name) {
        this.email = (email !== null && email !== void 0 ? email : '');
        this.name = (name !== null && name !== void 0 ? name : '');
    }
}


/***/ }),

/***/ "./src/app/_models/refresh-token.ts":
/*!******************************************!*\
  !*** ./src/app/_models/refresh-token.ts ***!
  \******************************************/
/*! exports provided: RefreshToken */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RefreshToken", function() { return RefreshToken; });
class RefreshToken {
    /**
     *
     */
    constructor(refreshToken) {
        this.token = refreshToken;
    }
}


/***/ }),

/***/ "./src/app/_models/sign-in.ts":
/*!************************************!*\
  !*** ./src/app/_models/sign-in.ts ***!
  \************************************/
/*! exports provided: SignIn */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SignIn", function() { return SignIn; });
class SignIn {
    /**
     *
     */
    constructor(email, password) {
        this.email = email;
        this.password = password;
    }
}


/***/ }),

/***/ "./src/app/_services/identity.service.ts":
/*!***********************************************!*\
  !*** ./src/app/_services/identity.service.ts ***!
  \***********************************************/
/*! exports provided: IdentityService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IdentityService", function() { return IdentityService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _models_sign_in__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../_models/sign-in */ "./src/app/_models/sign-in.ts");
/* harmony import */ var _models_User__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../_models/User */ "./src/app/_models/User.ts");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _models_refresh_token__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../_models/refresh-token */ "./src/app/_models/refresh-token.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");










class IdentityService {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.currentUserSubject = new rxjs__WEBPACK_IMPORTED_MODULE_1__["BehaviorSubject"](this.userFromLocalStorage);
        this.currentUser = this.currentUserSubject.asObservable();
    }
    get currentUserValue() {
        return this.currentUserSubject.value;
    }
    get accesTokenFromLocalStorage() {
        var _a;
        let userToken = this.userTokenFromLocalStorage;
        let token = (_a = userToken) === null || _a === void 0 ? void 0 : _a.accessToken;
        if (!userToken || !token) {
            return null;
        }
        return token;
    }
    get refreshTokenFromLocalStorage() {
        var _a;
        let userToken = this.userTokenFromLocalStorage;
        return (_a = userToken) === null || _a === void 0 ? void 0 : _a.refreshToken;
    }
    get userFromLocalStorage() {
        var _a, _b, _c, _d;
        let userToken = this.userTokenFromLocalStorage;
        let userName = (_b = (_a = userToken) === null || _a === void 0 ? void 0 : _a.claims.name, (_b !== null && _b !== void 0 ? _b : ''));
        let userEmail = (_d = (_c = userToken) === null || _c === void 0 ? void 0 : _c.claims.email, (_d !== null && _d !== void 0 ? _d : ''));
        if (!userToken || !userName || !userEmail) {
            return null;
        }
        return new _models_User__WEBPACK_IMPORTED_MODULE_4__["User"](userEmail, userName);
    }
    get userTokenFromLocalStorage() {
        return JSON.parse(localStorage.getItem('userToken'));
    }
    signIn(email, password) {
        let signInModel = new _models_sign_in__WEBPACK_IMPORTED_MODULE_3__["SignIn"](email, password);
        return this.http.post(`${src_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl}/${src_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].identityService}/sign-in`, signInModel)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(token => {
            // login successful if there's a jwt token in the response
            if (token && token.accessToken) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('userToken', JSON.stringify(token));
                this.currentUserSubject.next(new _models_User__WEBPACK_IMPORTED_MODULE_4__["User"](token.claims.email, token.claims.name));
            }
            else {
                token = null;
            }
            return token;
        }));
    }
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('userToken');
        this.router.navigate(['login']);
        this.currentUserSubject.next(null);
    }
    refreshToken() {
        let refreshToken = new _models_refresh_token__WEBPACK_IMPORTED_MODULE_6__["RefreshToken"](this.refreshTokenFromLocalStorage);
        return this.http.post(`${src_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl}/${src_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].identityService}/token-refresh`, refreshToken)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(token => {
            if (token && token.accessToken) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('userToken', JSON.stringify(token));
                this.currentUserSubject.next(new _models_User__WEBPACK_IMPORTED_MODULE_4__["User"](token.claims.email, token.claims.name));
            }
            else {
                token = null;
            }
            return token;
        }));
    }
}
IdentityService.ɵfac = function IdentityService_Factory(t) { return new (t || IdentityService)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClient"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__["Router"])); };
IdentityService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: IdentityService, factory: IdentityService.ɵfac, providedIn: 'root' });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](IdentityService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{
                providedIn: 'root'
            }]
    }], function () { return [{ type: _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClient"] }, { type: _angular_router__WEBPACK_IMPORTED_MODULE_8__["Router"] }]; }, null); })();


/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./login/login.component */ "./src/app/login/login.component.ts");
/* harmony import */ var _helpers_auth_guard__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./_helpers/auth-guard */ "./src/app/_helpers/auth-guard.ts");






const routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', component: _login_login_component__WEBPACK_IMPORTED_MODULE_2__["LoginComponent"] },
    {
        path: 'dashboard',
        loadChildren: () => __webpack_require__.e(/*! import() | sql-monitor-sql-monitor-module */ "sql-monitor-sql-monitor-module").then(__webpack_require__.bind(null, /*! ./sql-monitor/sql-monitor.module */ "./src/app/sql-monitor/sql-monitor.module.ts")).then(m => m.SqlMonitorModule),
        data: { title: 'Dashboard' },
        canActivate: [_helpers_auth_guard__WEBPACK_IMPORTED_MODULE_3__["AuthGuard"]]
    }
];
class AppRoutingModule {
}
AppRoutingModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineNgModule"]({ type: AppRoutingModule });
AppRoutingModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjector"]({ factory: function AppRoutingModule_Factory(t) { return new (t || AppRoutingModule)(); }, imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
        _angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsetNgModuleScope"](AppRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]] }); })();
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AppRoutingModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"],
        args: [{
                imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
                exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
            }]
    }], null, null); })();


/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./_services/identity.service */ "./src/app/_services/identity.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _nav_nav_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./nav/nav.component */ "./src/app/nav/nav.component.ts");
/* harmony import */ var _horizontal_nav_horizontal_nav_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./horizontal-nav/horizontal-nav.component */ "./src/app/horizontal-nav/horizontal-nav.component.ts");







function AppComponent_app_nav_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "app-nav", 5);
} }
function AppComponent_app_horizontal_nav_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "app-horizontal-nav");
} }
const _c0 = function (a0, a1) { return { "col-lg-12": a0, "col-lg-10": a1 }; };
class AppComponent {
    constructor(identityService) {
        this.identityService = identityService;
        this.identityService.currentUser.subscribe(user => this.currentUser = user);
    }
}
AppComponent.ɵfac = function AppComponent_Factory(t) { return new (t || AppComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_1__["IdentityService"])); };
AppComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: AppComponent, selectors: [["app-root"]], decls: 6, vars: 6, consts: [[1, "row", "app-row"], ["class", "col-lg-2 horizontal-nav-container", 4, "ngIf"], [1, "body-container", 3, "ngClass"], [4, "ngIf"], [1, "router-outlet-container"], [1, "col-lg-2", "horizontal-nav-container"]], template: function AppComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](1, AppComponent_app_nav_1_Template, 1, 0, "app-nav", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](3, AppComponent_app_horizontal_nav_3_Template, 1, 0, "app-horizontal-nav", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "div", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](5, "router-outlet");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.currentUser);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngClass", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction2"](3, _c0, !ctx.currentUser, ctx.currentUser));
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.currentUser);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["NgIf"], _angular_common__WEBPACK_IMPORTED_MODULE_2__["NgClass"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["RouterOutlet"], _nav_nav_component__WEBPACK_IMPORTED_MODULE_4__["NavComponent"], _horizontal_nav_horizontal_nav_component__WEBPACK_IMPORTED_MODULE_5__["HorizontalNavComponent"]], styles: [".app-row[_ngcontent-%COMP%] {\n  margin-left: 0px !important;\n  margin-right: 0px !important;\n  height: 100%;\n}\n\n.router-outlet-container[_ngcontent-%COMP%] {\n  margin-left: 15px;\n  margin-right: 15px;\n}\n\n.horizontal-nav-container[_ngcontent-%COMP%], .body-container[_ngcontent-%COMP%] {\n  padding: 0;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvQzpcXE15RGF0YVxcUHJvamVjdHNcXFRvb2xCb3hcXHNlcnZlclxcVG9vbEJveC5DbGllbnRcXENsaWVudEFwcC9zcmNcXGFwcFxcYXBwLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSwyQkFBQTtFQUNBLDRCQUFBO0VBQ0EsWUFBQTtBQ0NKOztBREVBO0VBRUksaUJBQUE7RUFDQSxrQkFBQTtBQ0FKOztBRElBO0VBQ0ksVUFBQTtBQ0RKIiwiZmlsZSI6InNyYy9hcHAvYXBwLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmFwcC1yb3d7XHJcbiAgICBtYXJnaW4tbGVmdDogMHB4IWltcG9ydGFudDtcclxuICAgIG1hcmdpbi1yaWdodDogMHB4IWltcG9ydGFudDtcclxuICAgIGhlaWdodDogMTAwJTtcclxufVxyXG5cclxuLnJvdXRlci1vdXRsZXQtY29udGFpbmVye1xyXG5cclxuICAgIG1hcmdpbi1sZWZ0OiAxNXB4O1xyXG4gICAgbWFyZ2luLXJpZ2h0OiAxNXB4O1xyXG5cclxufVxyXG5cclxuLmhvcml6b250YWwtbmF2LWNvbnRhaW5lciwgLmJvZHktY29udGFpbmVye1xyXG4gICAgcGFkZGluZzowO1xyXG59XHJcblxyXG4iLCIuYXBwLXJvdyB7XG4gIG1hcmdpbi1sZWZ0OiAwcHggIWltcG9ydGFudDtcbiAgbWFyZ2luLXJpZ2h0OiAwcHggIWltcG9ydGFudDtcbiAgaGVpZ2h0OiAxMDAlO1xufVxuXG4ucm91dGVyLW91dGxldC1jb250YWluZXIge1xuICBtYXJnaW4tbGVmdDogMTVweDtcbiAgbWFyZ2luLXJpZ2h0OiAxNXB4O1xufVxuXG4uaG9yaXpvbnRhbC1uYXYtY29udGFpbmVyLCAuYm9keS1jb250YWluZXIge1xuICBwYWRkaW5nOiAwO1xufSJdfQ== */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AppComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-root',
                templateUrl: './app.component.html',
                styleUrls: ['./app.component.scss']
            }]
    }], function () { return [{ type: _services_identity_service__WEBPACK_IMPORTED_MODULE_1__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./login/login.component */ "./src/app/login/login.component.ts");
/* harmony import */ var _nav_nav_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./nav/nav.component */ "./src/app/nav/nav.component.ts");
/* harmony import */ var _helpers_jwt_interceptor__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./_helpers/jwt-interceptor */ "./src/app/_helpers/jwt-interceptor.ts");
/* harmony import */ var _helpers_error_interceptor__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./_helpers/error-interceptor */ "./src/app/_helpers/error-interceptor.ts");
/* harmony import */ var _horizontal_nav_horizontal_nav_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./horizontal-nav/horizontal-nav.component */ "./src/app/horizontal-nav/horizontal-nav.component.ts");
/* harmony import */ var _directives_click_stop_propagation__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./_directives/click-stop-propagation */ "./src/app/_directives/click-stop-propagation.ts");













class AppModule {
}
AppModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineNgModule"]({ type: AppModule, bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"]] });
AppModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjector"]({ factory: function AppModule_Factory(t) { return new (t || AppModule)(); }, providers: [
        { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"], useClass: _helpers_jwt_interceptor__WEBPACK_IMPORTED_MODULE_8__["JwtInterceptor"], multi: true },
        { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"], useClass: _helpers_error_interceptor__WEBPACK_IMPORTED_MODULE_9__["ErrorInterceptor"], multi: true },
    ], imports: [[
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
            _app_routing_module__WEBPACK_IMPORTED_MODULE_4__["AppRoutingModule"]
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵsetNgModuleScope"](AppModule, { declarations: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"],
        _login_login_component__WEBPACK_IMPORTED_MODULE_6__["LoginComponent"],
        _nav_nav_component__WEBPACK_IMPORTED_MODULE_7__["NavComponent"],
        _horizontal_nav_horizontal_nav_component__WEBPACK_IMPORTED_MODULE_10__["HorizontalNavComponent"],
        _directives_click_stop_propagation__WEBPACK_IMPORTED_MODULE_11__["ClickStopPropagation"]], imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
        _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
        _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
        _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
        _app_routing_module__WEBPACK_IMPORTED_MODULE_4__["AppRoutingModule"]] }); })();
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](AppModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"],
        args: [{
                declarations: [
                    _app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"],
                    _login_login_component__WEBPACK_IMPORTED_MODULE_6__["LoginComponent"],
                    _nav_nav_component__WEBPACK_IMPORTED_MODULE_7__["NavComponent"],
                    _horizontal_nav_horizontal_nav_component__WEBPACK_IMPORTED_MODULE_10__["HorizontalNavComponent"],
                    _directives_click_stop_propagation__WEBPACK_IMPORTED_MODULE_11__["ClickStopPropagation"],
                ],
                imports: [
                    _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                    _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                    _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                    _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                    _app_routing_module__WEBPACK_IMPORTED_MODULE_4__["AppRoutingModule"]
                ],
                providers: [
                    { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"], useClass: _helpers_jwt_interceptor__WEBPACK_IMPORTED_MODULE_8__["JwtInterceptor"], multi: true },
                    { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HTTP_INTERCEPTORS"], useClass: _helpers_error_interceptor__WEBPACK_IMPORTED_MODULE_9__["ErrorInterceptor"], multi: true },
                ],
                bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"]]
            }]
    }], null, null); })();


/***/ }),

/***/ "./src/app/horizontal-nav/horizontal-nav.component.ts":
/*!************************************************************!*\
  !*** ./src/app/horizontal-nav/horizontal-nav.component.ts ***!
  \************************************************************/
/*! exports provided: HorizontalNavComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HorizontalNavComponent", function() { return HorizontalNavComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");






class HorizontalNavComponent {
    constructor(router, activatedRoute, identityService) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.identityService = identityService;
        this.title = 'Dashboard';
        this.identityService.currentUser.subscribe(user => this.currentUser = user);
    }
    ngOnInit() {
        this.router.events.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["filter"])((event) => event instanceof _angular_router__WEBPACK_IMPORTED_MODULE_1__["NavigationEnd"]), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(() => this.activatedRoute), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])((route) => {
            while (route.firstChild)
                route = route.firstChild;
            return route;
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["filter"])((route) => route.outlet === 'primary'), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["mergeMap"])((route) => route.data)).subscribe((data) => {
            this.title = data['title'];
        });
    }
}
HorizontalNavComponent.ɵfac = function HorizontalNavComponent_Factory(t) { return new (t || HorizontalNavComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_3__["IdentityService"])); };
HorizontalNavComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: HorizontalNavComponent, selectors: [["app-horizontal-nav"]], decls: 9, vars: 2, consts: [["role", "alert", 1, "alert", "alert-dark", "horizontal-nav", 2, "background-color", "black", "opacity", "0.85", "border", "0px", "color", "white"], [1, "row", "justify-content-between"], [1, "ml-4"], [1, "d-flex", "align-items-center"], [1, "mr-4", 2, "font-size", "19px"], [2, "font-weight", "bold"]], template: function HorizontalNavComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "h3", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "div", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "span", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6, " Welcome ");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "span", 5);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](8);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", ctx.title, "");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](5);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](ctx.currentUser.name);
    } }, styles: [".horizontal-nav[_ngcontent-%COMP%] {\n  border-radius: 0;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaG9yaXpvbnRhbC1uYXYvQzpcXE15RGF0YVxcUHJvamVjdHNcXFRvb2xCb3hcXHNlcnZlclxcVG9vbEJveC5DbGllbnRcXENsaWVudEFwcC9zcmNcXGFwcFxcaG9yaXpvbnRhbC1uYXZcXGhvcml6b250YWwtbmF2LmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9ob3Jpem9udGFsLW5hdi9ob3Jpem9udGFsLW5hdi5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNBLGdCQUFBO0FDQ0EiLCJmaWxlIjoic3JjL2FwcC9ob3Jpem9udGFsLW5hdi9ob3Jpem9udGFsLW5hdi5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5ob3Jpem9udGFsLW5hdntcclxuYm9yZGVyLXJhZGl1czogMDtcclxufSIsIi5ob3Jpem9udGFsLW5hdiB7XG4gIGJvcmRlci1yYWRpdXM6IDA7XG59Il19 */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](HorizontalNavComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-horizontal-nav',
                templateUrl: './horizontal-nav.component.html',
                styleUrls: ['./horizontal-nav.component.scss']
            }]
    }], function () { return [{ type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"] }, { type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"] }, { type: _services_identity_service__WEBPACK_IMPORTED_MODULE_3__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/login/login.component.ts":
/*!******************************************!*\
  !*** ./src/app/login/login.component.ts ***!
  \******************************************/
/*! exports provided: LoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginComponent", function() { return LoginComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");








function LoginComponent_div_6_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Please enter email");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function LoginComponent_div_6_div_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Email is required");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function LoginComponent_div_6_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 10);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](1, LoginComponent_div_6_div_1_Template, 2, 0, "div", 11);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](2, LoginComponent_div_6_div_2_Template, 2, 0, "div", 11);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx_r0.form.email.errors.email);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx_r0.form.email.errors.required);
} }
function LoginComponent_div_9_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Password is required");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function LoginComponent_div_9_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 10);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](1, LoginComponent_div_9_div_1_Template, 2, 0, "div", 11);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx_r1.form.password.errors.required);
} }
function LoginComponent_span_11_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "span", 12);
} }
function LoginComponent_div_13_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 13);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](ctx_r3.error);
} }
const _c0 = function (a0) { return { "is-invalid": a0 }; };
class LoginComponent {
    constructor(formBuilder, router, identityService) {
        this.formBuilder = formBuilder;
        this.router = router;
        this.identityService = identityService;
        this.submitted = false;
        this.loading = false;
        this.error = '';
    }
    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].compose([_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].email])],
            password: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]
        });
        this.identityService.logout();
    }
    // convenience getter for easy access to form fields
    get form() { return this.loginForm.controls; }
    onSubmit() {
        this.submitted = true;
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        this.loading = true;
        this.identityService.signIn(this.form.email.value, this.form.password.value)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["first"])())
            .subscribe(data => {
            this.router.navigate(['dashboard']);
        }, error => {
            this.error = error;
            this.loading = false;
        });
    }
}
LoginComponent.ɵfac = function LoginComponent_Factory(t) { return new (t || LoginComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_4__["IdentityService"])); };
LoginComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: LoginComponent, selectors: [["app-login"]], decls: 14, vars: 12, consts: [[1, "text-monospace", "font-weight-bold", "text-center", "col-sm-12", "mb-4", 2, "padding-top", "100px"], [1, "d-flex", "justify-content-center", "login-container", "col-sm-12"], [1, "col-sm-4", 3, "formGroup", "ngSubmit"], [1, "form-group"], ["type", "email", "placeholder", "Email address", "formControlName", "email", 1, "form-control", 3, "ngClass"], ["class", "invalid-feedback", 4, "ngIf"], ["type", "password", "placeholder", "Password", "formControlName", "password", 1, "form-control", 3, "ngClass"], [1, "btn", "btn-outline-primary", "col-sm-12", 3, "disabled"], ["class", "spinner-border spinner-border-sm mr-1", 4, "ngIf"], ["class", "alert alert-danger mt-3 mb-0", 4, "ngIf"], [1, "invalid-feedback"], [4, "ngIf"], [1, "spinner-border", "spinner-border-sm", "mr-1"], [1, "alert", "alert-danger", "mt-3", "mb-0"]], template: function LoginComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "h2", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "ToolBox");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "form", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("ngSubmit", function LoginComponent_Template_form_ngSubmit_3_listener() { return ctx.onSubmit(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "div", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](5, "input", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](6, LoginComponent_div_6_Template, 3, 2, "div", 5);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "div", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](8, "input", 6);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](9, LoginComponent_div_9_Template, 2, 1, "div", 5);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](10, "button", 7);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](11, LoginComponent_span_11_Template, 1, 0, "span", 8);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](12, " Sign in ");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](13, LoginComponent_div_13_Template, 2, 1, "div", 9);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("formGroup", ctx.loginForm);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngClass", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](8, _c0, ctx.submitted && ctx.form.email.errors));
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.submitted && ctx.form.email.errors);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngClass", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](10, _c0, ctx.submitted && ctx.form.password.errors));
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.submitted && ctx.form.password.errors);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("disabled", ctx.loading);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.loading);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.error);
    } }, directives: [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["ɵangular_packages_forms_forms_y"], _angular_forms__WEBPACK_IMPORTED_MODULE_1__["NgControlStatusGroup"], _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroupDirective"], _angular_forms__WEBPACK_IMPORTED_MODULE_1__["DefaultValueAccessor"], _angular_forms__WEBPACK_IMPORTED_MODULE_1__["NgControlStatus"], _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControlName"], _angular_common__WEBPACK_IMPORTED_MODULE_5__["NgClass"], _angular_common__WEBPACK_IMPORTED_MODULE_5__["NgIf"]], styles: [".login-container[_ngcontent-%COMP%] {\n  height: 100%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbG9naW4vQzpcXE15RGF0YVxcUHJvamVjdHNcXFRvb2xCb3hcXHNlcnZlclxcVG9vbEJveC5DbGllbnRcXENsaWVudEFwcC9zcmNcXGFwcFxcbG9naW5cXGxvZ2luLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9sb2dpbi9sb2dpbi5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUVJLFlBQUE7QUNBSiIsImZpbGUiOiJzcmMvYXBwL2xvZ2luL2xvZ2luLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmxvZ2luLWNvbnRhaW5lcntcclxuXHJcbiAgICBoZWlnaHQ6IDEwMCU7XHJcblxyXG59IiwiLmxvZ2luLWNvbnRhaW5lciB7XG4gIGhlaWdodDogMTAwJTtcbn0iXX0= */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](LoginComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-login',
                templateUrl: './login.component.html',
                styleUrls: ['./login.component.scss']
            }]
    }], function () { return [{ type: _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"] }, { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"] }, { type: _services_identity_service__WEBPACK_IMPORTED_MODULE_4__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/nav/nav.component.ts":
/*!**************************************!*\
  !*** ./src/app/nav/nav.component.ts ***!
  \**************************************/
/*! exports provided: NavComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavComponent", function() { return NavComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _services_identity_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../_services/identity.service */ "./src/app/_services/identity.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");





function NavComponent_nav_0_Template(rf, ctx) { if (rf & 1) {
    const _r37 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "nav", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](3, "i", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "h2", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](5, "ToolBox");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](6, "ul", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "li", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](8, "a", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](9, "span", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](10, " Dashboard");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](11, "li");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](12, "a", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](13, "span", 10);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](14, " Add Server");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](15, "li");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](16, "li");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](17, "a", 11);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function NavComponent_nav_0_Template_a_click_17_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵrestoreView"](_r37); const ctx_r36 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"](); return ctx_r36.logout(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](18, "span", 12);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](19, " Sign Out");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](8);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", "dashboard");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", "dashboard/servers/add");
} }
class NavComponent {
    constructor(router, identityService) {
        this.router = router;
        this.identityService = identityService;
        this.identityService.currentUser.subscribe(user => this.currentUser = user);
    }
    ngOnInit() {
    }
    logout() {
        this.identityService.logout();
        this.router.navigate(['/login']);
    }
}
NavComponent.ɵfac = function NavComponent_Factory(t) { return new (t || NavComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"])); };
NavComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: NavComponent, selectors: [["app-nav"]], decls: 1, vars: 1, consts: [["id", "sidebar", 4, "ngIf"], ["id", "sidebar"], [1, "img", "bg-wrap", "text-center", "py-4"], [1, "user-logo"], [1, "fa", "fa-database", "fa-5x", "mb-3", 2, "color", "red"], [1, "text-monospace", 2, "color", "white"], [1, "list-unstyled", "components", "mb-5"], [1, "active"], [3, "routerLink"], [1, "fa", "fa-home", "mr-3"], [1, "fa", "fa-server", "mr-3", "notif"], [3, "routerLink", "click"], [1, "fa", "fa-sign-out", "mr-3"]], template: function NavComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](0, NavComponent_nav_0_Template, 20, 2, "nav", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.currentUser);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_3__["NgIf"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterLinkWithHref"]], styles: ["a[_ngcontent-%COMP%] {\n  -webkit-transition: 0.3s all ease;\n  transition: 0.3s all ease;\n  color: #2f89fc;\n}\na[_ngcontent-%COMP%]:hover, a[_ngcontent-%COMP%]:focus {\n  text-decoration: none !important;\n  outline: none !important;\n  box-shadow: none;\n}\nbutton[_ngcontent-%COMP%] {\n  -webkit-transition: 0.3s all ease;\n  transition: 0.3s all ease;\n}\nbutton[_ngcontent-%COMP%]:hover, button[_ngcontent-%COMP%]:focus {\n  text-decoration: none !important;\n  outline: none !important;\n  box-shadow: none !important;\n}\nh1[_ngcontent-%COMP%], h2[_ngcontent-%COMP%], h3[_ngcontent-%COMP%], h4[_ngcontent-%COMP%], h5[_ngcontent-%COMP%], .h1[_ngcontent-%COMP%], .h2[_ngcontent-%COMP%], .h3[_ngcontent-%COMP%], .h4[_ngcontent-%COMP%], .h5[_ngcontent-%COMP%] {\n  line-height: 1.5;\n  font-weight: 400;\n  font-family: \"Poppins\", Arial, sans-serif;\n  color: black;\n}\n.img[_ngcontent-%COMP%] {\n  background-size: cover;\n  background-repeat: no-repeat;\n  background-position: center center;\n}\n.wrapper[_ngcontent-%COMP%] {\n  width: 100%;\n}\n#sidebar[_ngcontent-%COMP%] {\n  height: 100%;\n  background: #32373d;\n  color: #fff;\n  -webkit-transition: all 0.3s;\n  transition: all 0.3s;\n  position: relative;\n}\n#sidebar[_ngcontent-%COMP%]   .h6[_ngcontent-%COMP%] {\n  color: white;\n}\n#sidebar[_ngcontent-%COMP%]   h1[_ngcontent-%COMP%] {\n  margin-bottom: 20px;\n  font-weight: 700;\n  font-size: 20px;\n}\n#sidebar[_ngcontent-%COMP%]   h1[_ngcontent-%COMP%]   .logo[_ngcontent-%COMP%] {\n  color: white;\n  display: block;\n  padding: 10px 30px;\n  background: #2f89fc;\n}\n#sidebar[_ngcontent-%COMP%]   ul.components[_ngcontent-%COMP%] {\n  padding: 0;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%] {\n  font-size: 16px;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]    > ul[_ngcontent-%COMP%] {\n  margin-left: 10px;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]    > ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%] {\n  font-size: 14px;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]   a[_ngcontent-%COMP%] {\n  padding: 15px 30px;\n  display: block;\n  color: rgba(255, 255, 255, 0.6);\n  border-bottom: 1px solid rgba(255, 255, 255, 0.05);\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]   span.notif[_ngcontent-%COMP%] {\n  position: relative;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]   span.notif[_ngcontent-%COMP%]   small[_ngcontent-%COMP%] {\n  position: absolute;\n  top: -3px;\n  bottom: 0;\n  right: -3px;\n  width: 12px;\n  height: 12px;\n  content: \"\";\n  background: red;\n  border-radius: 50%;\n  font-family: \"Poppins\", Arial, sans-serif;\n  font-size: 8px;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]:hover {\n  color: white;\n  background: #2f89fc;\n  border-bottom: 1px solid #2f89fc;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li.active[_ngcontent-%COMP%]    > a[_ngcontent-%COMP%] {\n  background: transparent;\n  color: white;\n}\n#sidebar[_ngcontent-%COMP%]   ul[_ngcontent-%COMP%]   li.active[_ngcontent-%COMP%]    > a[_ngcontent-%COMP%]:hover {\n  background: #2f89fc;\n  border-bottom: 1px solid #2f89fc;\n}\n.bg-wrap[_ngcontent-%COMP%] {\n  width: 100%;\n  position: relative;\n  z-index: 0;\n}\n.bg-wrap[_ngcontent-%COMP%]:after {\n  z-index: -1;\n  position: absolute;\n  top: 0;\n  left: 0;\n  right: 0;\n  bottom: 0;\n  content: \"\";\n  background: black;\n  opacity: 0.3;\n}\n.bg-wrap[_ngcontent-%COMP%]   .user-logo[_ngcontent-%COMP%]   .img[_ngcontent-%COMP%] {\n  width: 100px;\n  height: 100px;\n  border-radius: 50%;\n  margin: 0 auto;\n  margin-bottom: 10px;\n}\n.bg-wrap[_ngcontent-%COMP%]   .user-logo[_ngcontent-%COMP%]   h3[_ngcontent-%COMP%] {\n  color: white;\n  font-size: 18px;\n}\n#content[_ngcontent-%COMP%] {\n  width: 100%;\n  padding: 0;\n  min-height: 100vh;\n  -webkit-transition: all 0.3s;\n  transition: all 0.3s;\n}\n.btn.btn-primary[_ngcontent-%COMP%] {\n  background: #2f89fc;\n  border-color: #2f89fc;\n}\n.btn.btn-primary[_ngcontent-%COMP%]:hover, .btn.btn-primary[_ngcontent-%COMP%]:focus {\n  background: #2f89fc !important;\n  border-color: #2f89fc !important;\n}\n.footer[_ngcontent-%COMP%]   p[_ngcontent-%COMP%] {\n  color: rgba(255, 255, 255, 0.5);\n}\n.form-control[_ngcontent-%COMP%] {\n  height: 40px !important;\n  background: white;\n  color: black;\n  font-size: 13px;\n  border-radius: 4px;\n  box-shadow: none !important;\n  border: transparent;\n}\n.form-control[_ngcontent-%COMP%]:focus, .form-control[_ngcontent-%COMP%]:active {\n  border-color: black;\n}\n.form-control[_ngcontent-%COMP%]::-webkit-input-placeholder {\n  \n  color: rgba(255, 255, 255, 0.5);\n}\n.form-control[_ngcontent-%COMP%]::-moz-placeholder {\n  \n  color: rgba(255, 255, 255, 0.5);\n}\n.form-control[_ngcontent-%COMP%]:-ms-input-placeholder {\n  \n  color: rgba(255, 255, 255, 0.5);\n}\n.form-control[_ngcontent-%COMP%]:-moz-placeholder {\n  \n  color: rgba(255, 255, 255, 0.5);\n}\n.subscribe-form[_ngcontent-%COMP%]   .form-control[_ngcontent-%COMP%] {\n  background: #4897fc;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbmF2L0M6XFxNeURhdGFcXFByb2plY3RzXFxUb29sQm94XFxzZXJ2ZXJcXFRvb2xCb3guQ2xpZW50XFxDbGllbnRBcHAvc3JjXFxhcHBcXG5hdlxcbmF2LmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9uYXYvbmF2LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUVBO0VBQ0MsaUNBQUE7RUFBQSx5QkFBQTtFQUNBLGNBQUE7QUNERDtBREVDO0VBQ0MsZ0NBQUE7RUFDQSx3QkFBQTtFQUNBLGdCQUFBO0FDQUY7QURHQTtFQUNDLGlDQUFBO0VBQUEseUJBQUE7QUNBRDtBRENDO0VBQ0MsZ0NBQUE7RUFDQSx3QkFBQTtFQUNBLDJCQUFBO0FDQ0Y7QURFQTs7RUFFQyxnQkFBQTtFQUNBLGdCQUFBO0VBQ0EseUNBdkJjO0VBd0JkLFlBQUE7QUNDRDtBRElBO0VBQ0Msc0JBQUE7RUFDQSw0QkFBQTtFQUNBLGtDQUFBO0FDREQ7QURNQTtFQUNFLFdBQUE7QUNIRjtBRE1BO0VBQ0ksWUFBQTtFQUVGLG1CQUFBO0VBQ0EsV0FBQTtFQUNBLDRCQUFBO0VBQUEsb0JBQUE7RUFDQSxrQkFBQTtBQ0pGO0FES0U7RUFDQyxZQUFBO0FDSEg7QURNRTtFQUNDLG1CQUFBO0VBQ0EsZ0JBQUE7RUFDQSxlQUFBO0FDSkg7QURLRztFQUNDLFlBQUE7RUFDQSxjQUFBO0VBQ0Esa0JBQUE7RUFDQSxtQkFBQTtBQ0hKO0FETUU7RUFDQyxVQUFBO0FDSkg7QURPSTtFQUNDLGVBQUE7QUNMTDtBRE1LO0VBQ0MsaUJBQUE7QUNKTjtBREtNO0VBQ0MsZUFBQTtBQ0hQO0FETUs7RUFDQyxrQkFBQTtFQUNBLGNBQUE7RUFDQSwrQkFBQTtFQUNBLGtEQUFBO0FDSk47QURNTztFQUNDLGtCQUFBO0FDSlI7QURLUTtFQUNDLGtCQUFBO0VBQ0EsU0FBQTtFQUNBLFNBQUE7RUFDQSxXQUFBO0VBQ0EsV0FBQTtFQUNBLFlBQUE7RUFDQSxXQUFBO0VBQ0EsZUFBQTtFQUNBLGtCQUFBO0VBQ0EseUNBN0ZNO0VBOEZOLGNBQUE7QUNIVDtBRE9NO0VBQ0MsWUFBQTtFQUNBLG1CQUFBO0VBQ0EsZ0NBQUE7QUNMUDtBRFNNO0VBQ0MsdUJBQUE7RUFDQSxZQUFBO0FDUFA7QURRTztFQUNDLG1CQUFBO0VBQ0EsZ0NBQUE7QUNOUjtBRGVBO0VBQ0MsV0FBQTtFQUNBLGtCQUFBO0VBQ0EsVUFBQTtBQ1pEO0FEYUM7RUFDQyxXQUFBO0VBQ0Esa0JBQUE7RUFDQSxNQUFBO0VBQ0EsT0FBQTtFQUNBLFFBQUE7RUFDQSxTQUFBO0VBQ0EsV0FBQTtFQUNBLGlCQUFBO0VBQ0EsWUFBQTtBQ1hGO0FEY0U7RUFDQyxZQUFBO0VBQ0EsYUFBQTtFQUNBLGtCQUFBO0VBQ0EsY0FBQTtFQUNBLG1CQUFBO0FDWkg7QURjRTtFQUNDLFlBQUE7RUFDQSxlQUFBO0FDWkg7QURpQkE7RUFDRSxXQUFBO0VBQ0EsVUFBQTtFQUNBLGlCQUFBO0VBQ0EsNEJBQUE7RUFBQSxvQkFBQTtBQ2RGO0FEbUJDO0VBQ0MsbUJBQUE7RUFDQSxxQkFBQTtBQ2hCRjtBRGlCRTtFQUNDLDhCQUFBO0VBQ0EsZ0NBQUE7QUNmSDtBRHFCQztFQUNDLCtCQUFBO0FDbEJGO0FEd0JBO0VBQ0MsdUJBQUE7RUFDQSxpQkFBQTtFQUNBLFlBQUE7RUFDQSxlQUFBO0VBQ0Esa0JBQUE7RUFDQSwyQkFBQTtFQUNBLG1CQUFBO0FDckJEO0FEc0JDO0VBQ0MsbUJBQUE7QUNwQkY7QURzQkM7RUFBK0Isd0JBQUE7RUFDN0IsK0JBQUE7QUNuQkg7QURxQkM7RUFBc0IsZ0JBQUE7RUFDcEIsK0JBQUE7QUNsQkg7QURvQkM7RUFBMEIsV0FBQTtFQUN4QiwrQkFBQTtBQ2pCSDtBRG1CQztFQUFxQixnQkFBQTtFQUNuQiwrQkFBQTtBQ2hCSDtBRHNCQztFQUNDLG1CQUFBO0FDbkJGIiwiZmlsZSI6InNyYy9hcHAvbmF2L25hdi5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIiRmb250LXByaW1hcnk6ICdQb3BwaW5zJyxBcmlhbCwgc2Fucy1zZXJpZjtcclxuXHJcbmEge1xyXG5cdHRyYW5zaXRpb246IC4zcyBhbGwgZWFzZTtcclxuXHRjb2xvcjogIzJmODlmYztcclxuXHQmOmhvdmVyLCAmOmZvY3VzIHtcclxuXHRcdHRleHQtZGVjb3JhdGlvbjogbm9uZSAhaW1wb3J0YW50O1xyXG5cdFx0b3V0bGluZTogbm9uZSAhaW1wb3J0YW50O1xyXG5cdFx0Ym94LXNoYWRvdzogbm9uZTtcclxuXHR9XHJcbn1cclxuYnV0dG9uIHtcclxuXHR0cmFuc2l0aW9uOiAuM3MgYWxsIGVhc2U7XHJcblx0Jjpob3ZlciwgJjpmb2N1cyB7XHJcblx0XHR0ZXh0LWRlY29yYXRpb246IG5vbmUgIWltcG9ydGFudDtcclxuXHRcdG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcclxuXHRcdGJveC1zaGFkb3c6IG5vbmUgIWltcG9ydGFudDtcclxuXHR9XHJcbn1cclxuaDEsIGgyLCBoMywgaDQsIGg1LFxyXG4uaDEsIC5oMiwgLmgzLCAuaDQsIC5oNSB7XHJcblx0bGluZS1oZWlnaHQ6IDEuNTtcclxuXHRmb250LXdlaWdodDogNDAwO1xyXG5cdGZvbnQtZmFtaWx5OiAkZm9udC1wcmltYXJ5O1xyXG5cdGNvbG9yOiBibGFjaztcclxufVxyXG5cclxuXHJcbi8vQ09WRVIgQkdcclxuLmltZ3tcclxuXHRiYWNrZ3JvdW5kLXNpemU6IGNvdmVyO1xyXG5cdGJhY2tncm91bmQtcmVwZWF0OiBuby1yZXBlYXQ7XHJcblx0YmFja2dyb3VuZC1wb3NpdGlvbjogY2VudGVyIGNlbnRlcjtcclxufVxyXG5cclxuXHJcbi8vU0lERUJBUlxyXG4ud3JhcHBlciB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbiNzaWRlYmFyIHtcclxuICAgIGhlaWdodDogMTAwJTtcclxuIFxyXG4gIGJhY2tncm91bmQ6ICMzMjM3M2Q7XHJcbiAgY29sb3I6ICNmZmY7XHJcbiAgdHJhbnNpdGlvbjogYWxsIDAuM3M7XHJcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gIC5oNntcclxuICBcdGNvbG9yOiB3aGl0ZTtcclxuICB9XHJcblxyXG4gIGgxe1xyXG4gIFx0bWFyZ2luLWJvdHRvbTogMjBweDtcclxuICBcdGZvbnQtd2VpZ2h0OiA3MDA7XHJcbiAgXHRmb250LXNpemU6IDIwcHg7XHJcbiAgXHQubG9nb3tcclxuICBcdFx0Y29sb3I6IHdoaXRlO1xyXG4gIFx0XHRkaXNwbGF5OiBibG9jaztcclxuICBcdFx0cGFkZGluZzogMTBweCAzMHB4O1xyXG4gIFx0XHRiYWNrZ3JvdW5kOiAjMmY4OWZjO1xyXG4gIFx0fVxyXG4gIH1cclxuICB1bC5jb21wb25lbnRze1xyXG4gIFx0cGFkZGluZzogMDtcclxuICB9XHJcbiAgdWx7XHJcbiAgICBsaXtcclxuICAgIFx0Zm9udC1zaXplOiAxNnB4O1xyXG4gICAgXHQ+dWx7XHJcbiAgICBcdFx0bWFyZ2luLWxlZnQ6IDEwcHg7XHJcbiAgICBcdFx0bGl7XHJcbiAgICBcdFx0XHRmb250LXNpemU6IDE0cHg7XHJcbiAgICBcdFx0fVxyXG4gICAgXHR9XHJcbiAgICBcdGF7XHJcbiAgICBcdFx0cGFkZGluZzogMTVweCAzMHB4O1xyXG5cdFx0ICAgIGRpc3BsYXk6IGJsb2NrO1xyXG5cdFx0ICAgIGNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LC42KTtcclxuXHRcdCAgICBib3JkZXItYm90dG9tOiAxcHggc29saWQgcmdiYSgyNTUsMjU1LDI1NSwuMDUpO1xyXG5cdFx0ICAgIHNwYW57XHJcblx0XHQgICAgXHQmLm5vdGlme1xyXG5cdFx0ICAgIFx0XHRwb3NpdGlvbjogcmVsYXRpdmU7XHJcblx0XHQgICAgXHRcdHNtYWxse1xyXG5cdFx0ICAgIFx0XHRcdHBvc2l0aW9uOiBhYnNvbHV0ZTtcclxuXHRcdCAgICBcdFx0XHR0b3A6IC0zcHg7XHJcblx0XHQgICAgXHRcdFx0Ym90dG9tOiAwO1xyXG5cdFx0ICAgIFx0XHRcdHJpZ2h0OiAtM3B4O1xyXG5cdFx0ICAgIFx0XHRcdHdpZHRoOiAxMnB4O1xyXG5cdFx0ICAgIFx0XHRcdGhlaWdodDogMTJweDtcclxuXHRcdCAgICBcdFx0XHRjb250ZW50OiAnJztcclxuXHRcdCAgICBcdFx0XHRiYWNrZ3JvdW5kOiByZWQ7XHJcblx0XHQgICAgXHRcdFx0Ym9yZGVyLXJhZGl1czogNTAlO1xyXG5cdFx0ICAgIFx0XHRcdGZvbnQtZmFtaWx5OiAkZm9udC1wcmltYXJ5O1xyXG5cdFx0ICAgIFx0XHRcdGZvbnQtc2l6ZTogOHB4O1xyXG5cdFx0ICAgIFx0XHR9XHJcblx0XHQgICAgXHR9XHJcblx0XHQgICAgfVxyXG5cdFx0ICAgICY6aG92ZXJ7XHJcblx0XHQgICAgXHRjb2xvcjogd2hpdGU7XHJcblx0XHQgICAgXHRiYWNrZ3JvdW5kOiAjMmY4OWZjO1xyXG5cdFx0ICAgIFx0Ym9yZGVyLWJvdHRvbTogMXB4IHNvbGlkICMyZjg5ZmM7XHJcblx0XHQgICAgfVxyXG4gICAgXHR9XHJcbiAgICBcdCYuYWN0aXZle1xyXG4gICAgXHRcdD4gYXtcclxuICAgIFx0XHRcdGJhY2tncm91bmQ6IHRyYW5zcGFyZW50O1xyXG4gICAgXHRcdFx0Y29sb3I6IHdoaXRlO1xyXG4gICAgXHRcdFx0Jjpob3ZlcntcclxuICAgIFx0XHRcdFx0YmFja2dyb3VuZDogIzJmODlmYztcclxuXHRcdFx0ICAgIFx0Ym9yZGVyLWJvdHRvbTogMXB4IHNvbGlkICMyZjg5ZmM7XHJcbiAgICBcdFx0XHR9XHJcbiAgICBcdFx0fVxyXG4gICAgXHR9XHJcbiAgICB9XHJcbiAgfVxyXG59XHJcblxyXG5cclxuLmJnLXdyYXB7XHJcblx0d2lkdGg6IDEwMCU7XHJcblx0cG9zaXRpb246IHJlbGF0aXZlO1xyXG5cdHotaW5kZXg6IDA7XHJcblx0JjphZnRlcntcclxuXHRcdHotaW5kZXg6IC0xO1xyXG5cdFx0cG9zaXRpb246IGFic29sdXRlO1xyXG5cdFx0dG9wOiAwO1xyXG5cdFx0bGVmdDogMDtcclxuXHRcdHJpZ2h0OiAwO1xyXG5cdFx0Ym90dG9tOiAwO1xyXG5cdFx0Y29udGVudDogJyc7XHJcblx0XHRiYWNrZ3JvdW5kOiBibGFjaztcclxuXHRcdG9wYWNpdHk6IC4zO1xyXG5cdH1cdFxyXG5cdC51c2VyLWxvZ297XHJcblx0XHQuaW1ne1xyXG5cdFx0XHR3aWR0aDogMTAwcHg7XHJcblx0XHRcdGhlaWdodDogMTAwcHg7XHJcblx0XHRcdGJvcmRlci1yYWRpdXM6IDUwJTtcclxuXHRcdFx0bWFyZ2luOiAwIGF1dG87XHJcblx0XHRcdG1hcmdpbi1ib3R0b206IDEwcHg7XHJcblx0XHR9XHJcblx0XHRoM3tcclxuXHRcdFx0Y29sb3I6IHdoaXRlO1xyXG5cdFx0XHRmb250LXNpemU6IDE4cHg7XHJcblx0XHR9XHJcblx0fVxyXG59XHJcblxyXG4jY29udGVudCB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbiAgcGFkZGluZzogMDtcclxuICBtaW4taGVpZ2h0OiAxMDB2aDtcclxuICB0cmFuc2l0aW9uOiBhbGwgMC4zcztcclxufVxyXG5cclxuXHJcbi5idG57XHJcblx0Ji5idG4tcHJpbWFyeXtcclxuXHRcdGJhY2tncm91bmQ6ICMyZjg5ZmM7XHJcblx0XHRib3JkZXItY29sb3I6ICMyZjg5ZmM7XHJcblx0XHQmOmhvdmVyLCAmOmZvY3Vze1xyXG5cdFx0XHRiYWNrZ3JvdW5kOiAjMmY4OWZjICFpbXBvcnRhbnQ7XHJcblx0XHRcdGJvcmRlci1jb2xvcjogIzJmODlmYyAhaW1wb3J0YW50O1xyXG5cdFx0fVxyXG5cdH1cclxufVxyXG5cclxuLmZvb3RlcntcclxuXHRwe1xyXG5cdFx0Y29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjUpO1xyXG5cdH1cclxufVxyXG5cclxuXHJcblxyXG4uZm9ybS1jb250cm9sIHtcclxuXHRoZWlnaHQ6IDQwcHghaW1wb3J0YW50O1xyXG5cdGJhY2tncm91bmQ6IHdoaXRlO1xyXG5cdGNvbG9yOiBibGFjaztcclxuXHRmb250LXNpemU6IDEzcHg7XHJcblx0Ym9yZGVyLXJhZGl1czogNHB4O1xyXG5cdGJveC1zaGFkb3c6IG5vbmUgIWltcG9ydGFudDtcclxuXHRib3JkZXI6IHRyYW5zcGFyZW50O1xyXG5cdCY6Zm9jdXMsICY6YWN0aXZlIHtcclxuXHRcdGJvcmRlci1jb2xvcjogYmxhY2s7XHJcblx0fVxyXG5cdCY6Oi13ZWJraXQtaW5wdXQtcGxhY2Vob2xkZXIgeyAvKiBDaHJvbWUvT3BlcmEvU2FmYXJpICovXHJcblx0ICBjb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwuNSk7XHJcblx0fVxyXG5cdCY6Oi1tb3otcGxhY2Vob2xkZXIgeyAvKiBGaXJlZm94IDE5KyAqL1xyXG5cdCAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjUpO1xyXG5cdH1cclxuXHQmOi1tcy1pbnB1dC1wbGFjZWhvbGRlciB7IC8qIElFIDEwKyAqL1xyXG5cdCAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjUpO1xyXG5cdH1cclxuXHQmOi1tb3otcGxhY2Vob2xkZXIgeyAvKiBGaXJlZm94IDE4LSAqL1xyXG5cdCAgY29sb3I6IHJnYmEoMjU1LDI1NSwyNTUsLjUpO1xyXG5cdH1cclxufVxyXG5cclxuXHJcbi5zdWJzY3JpYmUtZm9ybXtcclxuXHQuZm9ybS1jb250cm9se1xyXG5cdFx0YmFja2dyb3VuZDogbGlnaHRlbigjMmY4OWZjLDUlKTtcclxuXHR9XHJcbn0iLCJhIHtcbiAgdHJhbnNpdGlvbjogMC4zcyBhbGwgZWFzZTtcbiAgY29sb3I6ICMyZjg5ZmM7XG59XG5hOmhvdmVyLCBhOmZvY3VzIHtcbiAgdGV4dC1kZWNvcmF0aW9uOiBub25lICFpbXBvcnRhbnQ7XG4gIG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcbiAgYm94LXNoYWRvdzogbm9uZTtcbn1cblxuYnV0dG9uIHtcbiAgdHJhbnNpdGlvbjogMC4zcyBhbGwgZWFzZTtcbn1cbmJ1dHRvbjpob3ZlciwgYnV0dG9uOmZvY3VzIHtcbiAgdGV4dC1kZWNvcmF0aW9uOiBub25lICFpbXBvcnRhbnQ7XG4gIG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcbiAgYm94LXNoYWRvdzogbm9uZSAhaW1wb3J0YW50O1xufVxuXG5oMSwgaDIsIGgzLCBoNCwgaDUsXG4uaDEsIC5oMiwgLmgzLCAuaDQsIC5oNSB7XG4gIGxpbmUtaGVpZ2h0OiAxLjU7XG4gIGZvbnQtd2VpZ2h0OiA0MDA7XG4gIGZvbnQtZmFtaWx5OiBcIlBvcHBpbnNcIiwgQXJpYWwsIHNhbnMtc2VyaWY7XG4gIGNvbG9yOiBibGFjaztcbn1cblxuLmltZyB7XG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XG4gIGJhY2tncm91bmQtcmVwZWF0OiBuby1yZXBlYXQ7XG4gIGJhY2tncm91bmQtcG9zaXRpb246IGNlbnRlciBjZW50ZXI7XG59XG5cbi53cmFwcGVyIHtcbiAgd2lkdGg6IDEwMCU7XG59XG5cbiNzaWRlYmFyIHtcbiAgaGVpZ2h0OiAxMDAlO1xuICBiYWNrZ3JvdW5kOiAjMzIzNzNkO1xuICBjb2xvcjogI2ZmZjtcbiAgdHJhbnNpdGlvbjogYWxsIDAuM3M7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcbn1cbiNzaWRlYmFyIC5oNiB7XG4gIGNvbG9yOiB3aGl0ZTtcbn1cbiNzaWRlYmFyIGgxIHtcbiAgbWFyZ2luLWJvdHRvbTogMjBweDtcbiAgZm9udC13ZWlnaHQ6IDcwMDtcbiAgZm9udC1zaXplOiAyMHB4O1xufVxuI3NpZGViYXIgaDEgLmxvZ28ge1xuICBjb2xvcjogd2hpdGU7XG4gIGRpc3BsYXk6IGJsb2NrO1xuICBwYWRkaW5nOiAxMHB4IDMwcHg7XG4gIGJhY2tncm91bmQ6ICMyZjg5ZmM7XG59XG4jc2lkZWJhciB1bC5jb21wb25lbnRzIHtcbiAgcGFkZGluZzogMDtcbn1cbiNzaWRlYmFyIHVsIGxpIHtcbiAgZm9udC1zaXplOiAxNnB4O1xufVxuI3NpZGViYXIgdWwgbGkgPiB1bCB7XG4gIG1hcmdpbi1sZWZ0OiAxMHB4O1xufVxuI3NpZGViYXIgdWwgbGkgPiB1bCBsaSB7XG4gIGZvbnQtc2l6ZTogMTRweDtcbn1cbiNzaWRlYmFyIHVsIGxpIGEge1xuICBwYWRkaW5nOiAxNXB4IDMwcHg7XG4gIGRpc3BsYXk6IGJsb2NrO1xuICBjb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjYpO1xuICBib3JkZXItYm90dG9tOiAxcHggc29saWQgcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjA1KTtcbn1cbiNzaWRlYmFyIHVsIGxpIGEgc3Bhbi5ub3RpZiB7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcbn1cbiNzaWRlYmFyIHVsIGxpIGEgc3Bhbi5ub3RpZiBzbWFsbCB7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgdG9wOiAtM3B4O1xuICBib3R0b206IDA7XG4gIHJpZ2h0OiAtM3B4O1xuICB3aWR0aDogMTJweDtcbiAgaGVpZ2h0OiAxMnB4O1xuICBjb250ZW50OiBcIlwiO1xuICBiYWNrZ3JvdW5kOiByZWQ7XG4gIGJvcmRlci1yYWRpdXM6IDUwJTtcbiAgZm9udC1mYW1pbHk6IFwiUG9wcGluc1wiLCBBcmlhbCwgc2Fucy1zZXJpZjtcbiAgZm9udC1zaXplOiA4cHg7XG59XG4jc2lkZWJhciB1bCBsaSBhOmhvdmVyIHtcbiAgY29sb3I6IHdoaXRlO1xuICBiYWNrZ3JvdW5kOiAjMmY4OWZjO1xuICBib3JkZXItYm90dG9tOiAxcHggc29saWQgIzJmODlmYztcbn1cbiNzaWRlYmFyIHVsIGxpLmFjdGl2ZSA+IGEge1xuICBiYWNrZ3JvdW5kOiB0cmFuc3BhcmVudDtcbiAgY29sb3I6IHdoaXRlO1xufVxuI3NpZGViYXIgdWwgbGkuYWN0aXZlID4gYTpob3ZlciB7XG4gIGJhY2tncm91bmQ6ICMyZjg5ZmM7XG4gIGJvcmRlci1ib3R0b206IDFweCBzb2xpZCAjMmY4OWZjO1xufVxuXG4uYmctd3JhcCB7XG4gIHdpZHRoOiAxMDAlO1xuICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gIHotaW5kZXg6IDA7XG59XG4uYmctd3JhcDphZnRlciB7XG4gIHotaW5kZXg6IC0xO1xuICBwb3NpdGlvbjogYWJzb2x1dGU7XG4gIHRvcDogMDtcbiAgbGVmdDogMDtcbiAgcmlnaHQ6IDA7XG4gIGJvdHRvbTogMDtcbiAgY29udGVudDogXCJcIjtcbiAgYmFja2dyb3VuZDogYmxhY2s7XG4gIG9wYWNpdHk6IDAuMztcbn1cbi5iZy13cmFwIC51c2VyLWxvZ28gLmltZyB7XG4gIHdpZHRoOiAxMDBweDtcbiAgaGVpZ2h0OiAxMDBweDtcbiAgYm9yZGVyLXJhZGl1czogNTAlO1xuICBtYXJnaW46IDAgYXV0bztcbiAgbWFyZ2luLWJvdHRvbTogMTBweDtcbn1cbi5iZy13cmFwIC51c2VyLWxvZ28gaDMge1xuICBjb2xvcjogd2hpdGU7XG4gIGZvbnQtc2l6ZTogMThweDtcbn1cblxuI2NvbnRlbnQge1xuICB3aWR0aDogMTAwJTtcbiAgcGFkZGluZzogMDtcbiAgbWluLWhlaWdodDogMTAwdmg7XG4gIHRyYW5zaXRpb246IGFsbCAwLjNzO1xufVxuXG4uYnRuLmJ0bi1wcmltYXJ5IHtcbiAgYmFja2dyb3VuZDogIzJmODlmYztcbiAgYm9yZGVyLWNvbG9yOiAjMmY4OWZjO1xufVxuLmJ0bi5idG4tcHJpbWFyeTpob3ZlciwgLmJ0bi5idG4tcHJpbWFyeTpmb2N1cyB7XG4gIGJhY2tncm91bmQ6ICMyZjg5ZmMgIWltcG9ydGFudDtcbiAgYm9yZGVyLWNvbG9yOiAjMmY4OWZjICFpbXBvcnRhbnQ7XG59XG5cbi5mb290ZXIgcCB7XG4gIGNvbG9yOiByZ2JhKDI1NSwgMjU1LCAyNTUsIDAuNSk7XG59XG5cbi5mb3JtLWNvbnRyb2wge1xuICBoZWlnaHQ6IDQwcHggIWltcG9ydGFudDtcbiAgYmFja2dyb3VuZDogd2hpdGU7XG4gIGNvbG9yOiBibGFjaztcbiAgZm9udC1zaXplOiAxM3B4O1xuICBib3JkZXItcmFkaXVzOiA0cHg7XG4gIGJveC1zaGFkb3c6IG5vbmUgIWltcG9ydGFudDtcbiAgYm9yZGVyOiB0cmFuc3BhcmVudDtcbn1cbi5mb3JtLWNvbnRyb2w6Zm9jdXMsIC5mb3JtLWNvbnRyb2w6YWN0aXZlIHtcbiAgYm9yZGVyLWNvbG9yOiBibGFjaztcbn1cbi5mb3JtLWNvbnRyb2w6Oi13ZWJraXQtaW5wdXQtcGxhY2Vob2xkZXIge1xuICAvKiBDaHJvbWUvT3BlcmEvU2FmYXJpICovXG4gIGNvbG9yOiByZ2JhKDI1NSwgMjU1LCAyNTUsIDAuNSk7XG59XG4uZm9ybS1jb250cm9sOjotbW96LXBsYWNlaG9sZGVyIHtcbiAgLyogRmlyZWZveCAxOSsgKi9cbiAgY29sb3I6IHJnYmEoMjU1LCAyNTUsIDI1NSwgMC41KTtcbn1cbi5mb3JtLWNvbnRyb2w6LW1zLWlucHV0LXBsYWNlaG9sZGVyIHtcbiAgLyogSUUgMTArICovXG4gIGNvbG9yOiByZ2JhKDI1NSwgMjU1LCAyNTUsIDAuNSk7XG59XG4uZm9ybS1jb250cm9sOi1tb3otcGxhY2Vob2xkZXIge1xuICAvKiBGaXJlZm94IDE4LSAqL1xuICBjb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjUpO1xufVxuXG4uc3Vic2NyaWJlLWZvcm0gLmZvcm0tY29udHJvbCB7XG4gIGJhY2tncm91bmQ6ICM0ODk3ZmM7XG59Il19 */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](NavComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-nav',
                templateUrl: './nav.component.html',
                styleUrls: ['./nav.component.scss']
            }]
    }], function () { return [{ type: _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"] }, { type: _services_identity_service__WEBPACK_IMPORTED_MODULE_2__["IdentityService"] }]; }, null); })();


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
const environment = {
    production: false,
    apiUrl: 'http://localhost:5000/api',
    identityService: 'identity',
    sqlmonitoryService: 'sqlmonitor'
};


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
_angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["platformBrowser"]().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(err => console.error(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\MyData\Projects\ToolBox\server\ToolBox.Client\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main-es2015.js.map