"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var primeng_1 = require("primeng/primeng");
var AppComponent = (function () {
    function AppComponent(confirmationService) {
        this.confirmationService = confirmationService;
        this.title = '';
        this.title = 'My First Angular App';
    }
    AppComponent.prototype.confirm = function () {
        var _this = this;
        this.confirmationService.confirm({
            message: 'Are you sure that you want to perform this action?',
            accept: function () {
                //Actual logic to perform a confirmation
                _this.title = "Deleted";
            },
            reject: function () {
                _this.title = "Reject";
            }
        });
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css'
        ],
        providers: [primeng_1.ConfirmationService]
    }),
    __metadata("design:paramtypes", [primeng_1.ConfirmationService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map