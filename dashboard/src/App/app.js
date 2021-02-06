
var App = angular.module('App', []);

var MainController = ['$scope', '$http', function ($scope, $http) {

    $scope.searchOnApi = function(searchText) {
        $http.get('/api/purchaseOrder?searchText=' + searchText)
        .then(function (response) {
            $scope.purchaseOrders = response.data;
        }, function () {
            console.log('Erro ao buscar a url workforce');
        });
    }

    $scope.searchOnApi('');

}];

App.controller('MainController', MainController); 
