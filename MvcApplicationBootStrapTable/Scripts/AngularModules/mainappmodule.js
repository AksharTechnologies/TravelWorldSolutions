/// <reference path="../../Views/Shared/view1.html" />

var moduleForControllers = angular.module("TravelWorldSolutionsControllers", [])
moduleForControllers.controller("loginController", function($scope) {
    $scope.welcomeMessage = "Enter Your Credentials"
}).controller("hotelController", function ($scope) {
    $scope.pageName = "Hotel Master"
    console.log("adasda");
}).controller("quotationController", function ($scope) {

    $scope.$on('$viewContentLoaded', function () {
        //Here your view content is fully loaded !!
        $("#tblQuotation").DataTable().destroy();
        $("#hotelDetails").DataTable().destroy();
        $("#tblQuotation").DataTable({
            "order": [[1, "desc"]],
        });
        $("#hotelDetails").DataTable({
            "order": [[1, "desc"]],
        });
    });
})
var moduleForRouting = angular.module("moduleForRouting", ['ngRoute'])
angular.module("moduleForRouting").config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/createQuotation', {
        controller: "quotationController",
        templateUrl: "Quotation/ReturnQuotationPage"
    }).when('/editQuotation', {
        controller: "quotationController",
        templateUrl: "Quotation/ReturnViewEditQuotationPage"
    }).when('/', {
        controller: "quotationController",
        templateUrl: "Quotation/ReturnQuotationPage"
    }).when('/fetchHotelsForQuotation', {
        controller: "quotationController",
        templateUrl: "Quotation/FetchHotels"
    })
    //fetchHotelsForQuotation
    //$locationProvider.html5Mode(true);
})
var mainapp = angular.module("TravelWorldSolutionsApp", ["TravelWorldSolutionsControllers", "moduleForRouting"])
//console.log(mainapp);

