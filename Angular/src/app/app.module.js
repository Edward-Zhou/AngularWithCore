"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var animations_1 = require("@angular/platform-browser/animations");
var app_component_1 = require("./app.component");
var dialogWindow_1 = require("../component/dialog/dialogWindow");
var dialog_button_1 = require("../component/dialog/dialog.button");
var material_1 = require("@angular/material");
var primeng_1 = require("primeng/primeng");
var control_component_1 = require("../component/control.component/control.component");
var jquery_1 = require("../component/jquery.component/jquery");
var appRoutes = [
    { path: 'app', component: app_component_1.AppComponent },
    { path: 'control', component: control_component_1.ControlComponent },
    { path: 'jquery', component: jquery_1.JqueryComponent },
    { path: '', component: app_component_1.AppComponent }
];
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
            dialogWindow_1.DialogWindowComponent,
            dialog_button_1.DialogButtonComponent,
            control_component_1.ControlComponent,
            jquery_1.JqueryComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            animations_1.BrowserAnimationsModule,
            material_1.MaterialModule,
            primeng_1.CalendarModule,
            primeng_1.ConfirmDialogModule,
            router_1.RouterModule.forRoot(appRoutes, { enableTracing: true })
        ],
        entryComponents: [dialogWindow_1.DialogWindowComponent],
        providers: [],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map