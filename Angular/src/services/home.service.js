"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var HomeService = (function () {
    function HomeService(http) {
        this.http = http;
    }
    HomeService.prototype.save = function () {
        return this.http.post('http://localhost:7265/home/Save', 'test').map(function (response) { return response.json().data; });
    };
    return HomeService;
}());
exports.HomeService = HomeService;
//# sourceMappingURL=home.service.js.map