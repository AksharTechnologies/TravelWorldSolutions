/// <reference path="../../Views/Shared/view1.html" />

var moduleForControllers = angular.module("TravelWorldSolutionsControllers", [])
moduleForControllers.controller("loginController", function($scope) {
    $scope.welcomeMessage = "Enter Your Credentials"
}).controller("hotelController", function ($scope) {
    $scope.pageName = "Hotel Master"
    console.log("adasda");

 

}).controller("quotationController", function ($scope, $location, $http) {

    $scope.hideShow = { 'visibility': 'hidden' };

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

    $scope.fetchHotels = function () {
        $http({
            url: "Quotation/FetchHotels",
            method: "Get",
            params: { hotelName: $scope.hotelName, stateId: $scope.stateId, cityId: $scope.cityId }
        }).then(function success(response) {
         
            console.log(response.data.Data)
            $scope.lstHotels = response.data.Data
            console.log($scope.lstHotels);

        }, function error() {
        });
    }
    $scope.sendEmail = function () {

        $("#formGroupEmailID").checkValidity();

        $scope.hideShow = { 'visibility': 'visible' };
        $scope.progressMessage =" "

        $( 'input[ng-model]' ).each( function() {
            angular.element( this ).controller( 'ngModel' ).$setViewValue( $( this ).val() );
        });
        var arrEmailIds = [];
        $scope.emailid1.trim().length > 0 ? arrEmailIds.push($scope.emailid1) : '';
        $scope.emailid2.trim().length > 0 ? arrEmailIds.push($scope.emailid2) : '';
        $scope.emailid3.trim().length > 0 ? arrEmailIds.push($scope.emailid3) : '';
        $scope.emailid4.trim().length > 0 ? arrEmailIds.push($scope.emailid4) : '';
        $scope.emailid5.trim().length > 0 ? arrEmailIds.push($scope.emailid5) : '';
        $scope.emailid6.trim().length > 0 ? arrEmailIds.push($scope.emailid6) : '';

       
        $http({
            url: "Quotation/sendEmail",
            method: "Get",
            params: { body: $scope.emailBody, lstEmailIds: arrEmailIds, to: $scope.toEmailid }
        }).then(function success(response) {
            $scope.hideShow = { 'visibility': 'hidden' };
            $scope.messageStyle = {"color":"green" ,"font-weight":"bold"}
            $scope.progressMessage = "Email sent successfully";
        }, function error() {
            $scope.messageStyle = { "color": "red", "font-weight": "bold" }
            $scope.progressMessage = "Error while sending email";
            $scope.hideShow = { 'visibility': 'hidden' };
        }); 
    }
    $scope.clearEmailModal = function (){
        $scope.emailid1 = null;
        $scope.emailid2 = null;
        $scope.emailid3 = null;
        $scope.emailid4 = null;
        $scope.emailid5 = null;
        $scope.emailid6 = null;
        angular.element("input[type='file']").val(null);
        $scope.responseMessage = " ";
        $scope.emailBody = null;
        $scope.toEmailid = null;
        $scope.progressMessage = " ";


    }
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
        templateUrl: "Quotation/ReturnQuotationPage"
    })
    //fetchHotelsForQuotation
    //$locationProvider.html5Mode(true);
})
var mainapp = angular.module("TravelWorldSolutionsApp", ["TravelWorldSolutionsControllers", "moduleForRouting"])
//console.log(mainapp);

