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
var home_service_1 = require("../../services/home.service");
var ControlComponent = (function () {
    function ControlComponent(confirmationSvc, homeSvc) {
        this.confirmationSvc = confirmationSvc;
        this.homeSvc = homeSvc;
        this.message = '';
    }
    ControlComponent.prototype.confirm = function () {
        var _this = this;
        this.confirmationSvc.confirm({
            message: 'Are you sure that you want to perform this action?',
            accept: function () {
                //Actual logic to perform a confirmation
                _this.message = "Deleted";
            },
            reject: function () {
                _this.message = "Reject";
            }
        });
    };
    ControlComponent.prototype.save = function () {
        this.homeSvc.save().subscribe(function (result) {
            console.log(result);
        });
    };
    return ControlComponent;
}());
ControlComponent = __decorate([
    core_1.Component({
        selector: 'control-component',
        templateUrl: './control.component.html',
        styleUrls: ['./control.component.css'],
        providers: [primeng_1.ConfirmationService,
            home_service_1.HomeService]
    }),
    __metadata("design:paramtypes", [primeng_1.ConfirmationService, home_service_1.HomeService])
], ControlComponent);
exports.ControlComponent = ControlComponent;
//# sourceMappingURL=control.component.js.map